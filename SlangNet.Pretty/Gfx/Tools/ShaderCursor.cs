using System;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance;
using SlangNet.ComWrappers.Descriptions;
using SlangNet.ComWrappers.Gfx.Descriptions;
using SlangNet.ComWrappers.Gfx.Interfaces;
using Unmanaged = SlangNet.Bindings.Generated;
using IShaderObject = SlangNet.ComWrappers.Gfx.Interfaces.IShaderObject;
using TypeLayoutReflection = SlangNet.ComWrappers.Reflection.TypeLayoutReflection;

namespace SlangNet.Gfx.Tools;

/// <summary>
/// Represents a "pointer" to the storage for a shader parameter of a (dynamically) known type.
///
/// A `ShaderCursor` serves as a pointer-like type for things stored inside a `ShaderObject`.
///
/// A cursor that points to the entire content of a shader object can be formed as
/// `ShaderCursor(someObject)`. A cursor pointing to a structure field or array element can be
/// formed from another cursor using `getField` or `getElement` respectively.
///
/// Given a cursor pointing to a value of some "primitive" type, we can set or get the value
/// using operations like `setResource`, `getResource`, etc.
///
/// Because type information for shader parameters is being reflected dynamically, all type
/// checking for shader cursors occurs at runtime, and errors may occur when attempting to
/// set a parameter using a value of an inappropriate type. As much as possible, `ShaderCursor`
/// attempts to protect against these cases and return an error `Result` or an invalid
/// cursor, rather than allowing operations to proceed with incorrect types.
/// </summary>
public struct ShaderCursor
{
    public IShaderObject? BaseObject { get; private set; }
    public TypeLayoutReflection? TypeLayout { get; private set; }
    public Unmanaged.ShaderObjectContainerType ContainerType { get; private set; }
    public ShaderOffset Offset { get; private set; }

    public readonly bool IsValid => BaseObject is not null;

    public ShaderCursor(IShaderObject obj)
    {
        BaseObject = obj;
        TypeLayout = obj.GetElementTypeLayout();
        ContainerType = obj.GetContainerType();
        Offset = new();
    }

    public readonly SlangResult SetData(ReadOnlySpan<byte> data)
    {
        //TODO: This is really ugly, see if cannot find another way, either by changing the api or marshalling
        ref var spanRef = ref data.DangerousGetReference();
        return BaseObject?.SetData(Offset, MemoryMarshal.CreateSpan(ref spanRef, data.Length), (nuint)data.Length) ?? SlangResult.InvalidArg;
    }

    public readonly SlangResult SetData<T>(ReadOnlySpan<T> data) where T : unmanaged
    {
        return SetData(data.AsBytes());
    }

    public readonly SlangResult SetData<T>(in T data) where T : unmanaged
    {
        return SetData(MemoryMarshal.CreateReadOnlySpan(in data, 1));
    }

    public readonly SlangResult SetObject(IShaderObject obj)
    {
        return BaseObject?.SetObject(Offset, obj) ?? SlangResult.InvalidArg;
    }

    public readonly SlangResult SetSpecializationArgs(ReadOnlySpan<SpecializationArgument> args)
    {
        //TODO: This is really ugly, see if cannot find another way, either by changing the api or marshalling
        ref var spanRef = ref args.DangerousGetReference();
        return BaseObject?.SetSpecializationArgs(Offset, MemoryMarshal.CreateSpan(ref spanRef, args.Length), args.Length) ?? SlangResult.InvalidArg;
    }

    public readonly SlangResult SetResource(IResourceView resourceView)
    {
        return BaseObject?.SetResource(Offset, resourceView) ?? SlangResult.InvalidArg;
    }

    public readonly SlangResult SetSampler(ISamplerState sampler)
    {
        return BaseObject?.SetSampler(Offset, sampler) ?? SlangResult.InvalidArg;
    }

    public readonly SlangResult SetCombinedTextureSampler(IResourceView textureView, ISamplerState sampler)
    {
        return BaseObject?.SetCombinedTextureSampler(Offset, textureView, sampler) ?? SlangResult.InvalidArg;
    }

    /// <summary>
    /// Produce a cursor to the field with the given `name`.
    ///
    /// This is a convenience wrapper around `getField()`.
    /// </summary>
    public readonly ShaderCursor this[string name] => GetField(name, out var cursor) ? cursor!.Value : new();

    /// <summary>
    /// Produce a cursor to the element or field with the given `index`.
    ///
    /// This is a convenience wrapper around `getElement()`.
    /// </summary>
    public readonly ShaderCursor this[int index] => GetElement(index);

    public readonly SlangResult GetDereferenced(out ShaderCursor? outCursor)
    {
        switch (TypeLayout?.Kind)
        {
            case Unmanaged.TypeKind.ConstantBuffer:
            case Unmanaged.TypeKind.ParameterBlock:
            {
                IShaderObject? subObject = null;
                BaseObject?.GetObject(Offset, out subObject);
                outCursor = subObject is null ? null : new ShaderCursor(subObject);

                return subObject is null ? SlangResult.InvalidHandle : SlangResult.Ok;
            }
            default:
            {
                outCursor = null;
                return SlangResult.InvalidArg;
            }
        }
    }

    /// <summary>
    /// Some resources such as RWStructuredBuffer, AppendStructuredBuffer and
    /// ConsumeStructuredBuffer need to have their counter explicitly bound on
    /// APIs other than DirectX, this will return a valid ShaderCursor pointing
    /// to that resource if that is the case.
    /// Otherwise, this returns an invalid cursor.
    /// </summary>
    public readonly ShaderCursor GetExplicitCounter()
    {
        //Similar to GetField below

        // The alternative to handling this here would be to augment IResourceView
        // with a `getCounterResourceView()`, and set that also in `setResource`
        var counterVarLayout = TypeLayout?.ExplicitCounter;
        if (counterVarLayout is not null)
        {
            var counterCursor = new ShaderCursor
            {
                // The counter cursor will point into the same parent object.
                BaseObject = BaseObject,

                // The type being pointed to is the type of the field.
                TypeLayout = counterVarLayout.Value.TypeLayout,


                Offset = new(
                    // The byte offset is the current offset plus the relative offset of the counter.
                    // The offset in binding ranges is computed similarly.
                    Offset.UniformOffset + (long)counterVarLayout.Value.GetOffset(),
                    (int)(Offset.BindingRangeIndex + TypeLayout?.ExplicitCounterBindingRangeOffset ?? 0),

                    // The index of the counter within any binding ranges will be the same
                    // as the index computed for the parent structure.
                    //
                    // Note: this case would arise for an array of structured buffers
                    //
                    //      AppendStructuredBuffer g[4];
                    //
                    // In this scenario, `g` holds two binding ranges:
                    //
                    // * Range #0 comprises 4 element buffers, representing `g[...].elements`
                    // * Range #1 comprises 4 counter buffers, representing `g[...].counter`
                    //
                    // A cursor for `g[2]` would have a `bindingRangeIndex` of zero but
                    // a `bindingArrayIndex` of 2, indicating that we could end up
                    // referencing either range, but no matter what we know the index
                    // is 2. Thus when we form a cursor for `g[2].counter` we want to
                    // apply the binding range offset to get a `bindingRangeIndex` of
                    // 1, while the `bindingArrayIndex` is unmodified.
                    //
                    // The result is that `g[2].counter` is stored in range #1 at array index 2.
                    //
                    Offset.BindingArrayIndex)
            };

            return counterCursor;
        }

        return new();
    }

    public readonly SlangResult GetField(string name, out ShaderCursor? outCursor)
    {
        // If this cursor is invalid, then can't possibly fetch a field.
        //
        if (!IsValid)
        {
            outCursor = null;
            return SlangResult.InvalidArg;
        }

        switch (TypeLayout?.Kind)
        {
            case Unmanaged.TypeKind.Struct:
                if (TypeLayout is null) break;
                var fieldIndex = TypeLayout.Value.FindFieldIndexByName(name);
                if (fieldIndex == -1) break;

                var fieldLayout = TypeLayout.Value.Fields[(int)fieldIndex];

                var fieldCursor = new ShaderCursor
                {
                    BaseObject = BaseObject,
                    TypeLayout = fieldLayout.TypeLayout,
                    Offset = new(Offset.UniformOffset + (long)fieldLayout.GetOffset(),
                                 (int)(Offset.BindingRangeIndex + TypeLayout.Value.GetFieldBindingRangeOffset(fieldIndex)),
                                 Offset.BindingArrayIndex)
                };

                outCursor = fieldCursor;
                return SlangResult.Ok;

            case Unmanaged.TypeKind.ConstantBuffer:
            case Unmanaged.TypeKind.ParameterBlock:
                GetDereferenced(out var d).ThrowIfFailed();
                return d!.Value.GetField(name, out outCursor);
        }

        var entryPointCount = BaseObject!.GetEntryPointCount();
        for (var e = 0; e < entryPointCount; e++)
        {
            BaseObject.GetEntryPoint(e, out var entryPoint);

            var entryPointCursor = new ShaderCursor(entryPoint);

            var result = entryPointCursor.GetField(name, out outCursor);
            if (result) return result;
        }

        outCursor = null;
        return SlangResult.InvalidArg;
    }

    public readonly ShaderCursor GetElement(int index)
    {
        if (ContainerType != Unmanaged.ShaderObjectContainerType.None)
        {
            var elementCursor = this with
            {
                TypeLayout = TypeLayout?.ElementTypeLayout,
                Offset = new(index * (int)TypeLayout?.GetStride()!, 0, index)
            };
            return elementCursor;
        }

        switch (TypeLayout?.Kind)
        {
            case Unmanaged.TypeKind.Array:
                var elementCursor = new ShaderCursor
                {
                    BaseObject = BaseObject,
                    TypeLayout = TypeLayout?.ElementTypeLayout,
                    Offset = new(Offset.UniformOffset + index * (int)TypeLayout?.GetElementStride(ParameterCategory.Uniform)!,
                                 Offset.BindingRangeIndex,
                                 Offset.BindingArrayIndex * (int)TypeLayout?.Type.ElementCount!)
                };
                return elementCursor;

            case Unmanaged.TypeKind.Struct:
            {
                if (index >= TypeLayout?.Fields.Count) return new();

                var fieldLayout = TypeLayout?.Fields[index];

                var fieldCursor = new ShaderCursor
                {
                    BaseObject = BaseObject,
                    TypeLayout = fieldLayout?.TypeLayout,
                    Offset = new(Offset.UniformOffset + (long)fieldLayout?.GetOffset()!,
                                 (int)(Offset.BindingRangeIndex + TypeLayout?.GetFieldBindingRangeOffset(index)!),
                                 Offset.BindingArrayIndex)
                };

                return fieldCursor;
            }

            case Unmanaged.TypeKind.Vector:
            case Unmanaged.TypeKind.Matrix:
            {
                var fieldCursor = new ShaderCursor
                {
                    BaseObject = BaseObject,
                    TypeLayout = TypeLayout?.ElementTypeLayout,
                    Offset = new(Offset.UniformOffset + index * (int)TypeLayout?.GetElementStride(ParameterCategory.Uniform)!,
                                 Offset.BindingRangeIndex,
                                 Offset.BindingArrayIndex)
                };
                return fieldCursor;
            }
        }

        return new();
    }

    public readonly ShaderCursor GetPath(string path)
    {
        var cursor = this;
        FollowPath(path, ref cursor).ThrowIfFailed();
        return cursor;
    }
    
    public static SlangResult FollowPath(string path, ref ShaderCursor ioCursor)
    {
        var cursor = ioCursor;

        const int ALLOW_NAME = 0x1;
        const int ALLOW_SUBSCRIPT = 0x2;
        const int ALLOW_DOT = 0x4;
        var state = ALLOW_NAME | ALLOW_SUBSCRIPT;

        var rest = path.AsSpan();
        while (rest.Length > 0)
        {
            var c = rest[0];

            if (c == '.')
            {
                if ((state & ALLOW_DOT) == 0) return SlangResult.InvalidArg;

                rest = rest[1..];
                state = ALLOW_NAME;
            }
            else if (c == '[')
            {
                if ((state & ALLOW_SUBSCRIPT) == 0) return SlangResult.InvalidArg;

                rest = rest[1..];
                var index = 0;
                while (rest.Length > 0 && rest[0] != ']')
                {
                    var d = rest[0];
                    if (d >= '0' && d <= '9')
                    {
                        index = index * 10 + (d - '0');
                    }
                    else
                    {
                        return SlangResult.InvalidArg;
                    }

                    rest = rest[1..];
                }

                if (rest.Length == 0 || rest[0] != ']') return SlangResult.InvalidArg;
                rest = rest[1..];

                cursor = cursor.GetElement(index);
                state = ALLOW_DOT | ALLOW_SUBSCRIPT;
            }
            else
            {
                var nameBegin = rest;
                while (rest.Length > 0)
                {
                    switch (rest[0])
                    {
                        case '.':
                        case '[':
                            goto breakNameLoop;
                        default:
                            rest = rest[1..];
                            continue;
                    }
                }

                breakNameLoop:

                var nameEnd = rest;
                var name = nameBegin[..(nameEnd.Length == 0 ? nameBegin.Length : nameBegin.Length - nameEnd.Length)]
                    .ToString();

                var result = cursor.GetField(name, out var newCursor);
                if (!result) return result;

                cursor = newCursor!.Value;
                state = ALLOW_DOT | ALLOW_SUBSCRIPT;
            }
        }

        ioCursor = cursor;
        return SlangResult.Ok;
    }
}