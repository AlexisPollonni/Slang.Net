using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt"]/*' />
[NativeTypeName("struct ISlangFileSystemExt : ISlangFileSystem")]
public unsafe partial struct ISlangFileSystemExt
{
    public Vtbl* lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return lpVtbl->queryInterface((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return lpVtbl->addRef((ISlangFileSystemExt*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return lpVtbl->release((ISlangFileSystemExt*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangCastable.castAs" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* castAs([NativeTypeName("const SlangUUID &")] SlangUUID* guid)
    {
        return lpVtbl->castAs((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), guid);
    }

    /// <inheritdoc cref="ISlangFileSystem.loadFile" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int loadFile([NativeTypeName("const char *")] sbyte* path, ISlangBlob** outBlob)
    {
        return lpVtbl->loadFile((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), path, outBlob);
    }

    /// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt.getFileUniqueIdentity"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getFileUniqueIdentity([NativeTypeName("const char *")] sbyte* path, ISlangBlob** outUniqueIdentity)
    {
        return lpVtbl->getFileUniqueIdentity((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), path, outUniqueIdentity);
    }

    /// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt.calcCombinedPath"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int calcCombinedPath(SlangPathType fromPathType, [NativeTypeName("const char *")] sbyte* fromPath, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** pathOut)
    {
        return lpVtbl->calcCombinedPath((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), fromPathType, fromPath, path, pathOut);
    }

    /// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt.getPathType"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getPathType([NativeTypeName("const char *")] sbyte* path, SlangPathType* pathTypeOut)
    {
        return lpVtbl->getPathType((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), path, pathTypeOut);
    }

    /// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt.getPath"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getPath(PathKind kind, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** outPath)
    {
        return lpVtbl->getPath((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), kind, path, outPath);
    }

    /// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt.clearCache"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void clearCache()
    {
        lpVtbl->clearCache((ISlangFileSystemExt*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt.enumeratePathContents"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int enumeratePathContents([NativeTypeName("const char *")] sbyte* path, [NativeTypeName("FileSystemContentsCallBack")] delegate* unmanaged[Cdecl]<SlangPathType, sbyte*, void*, void> callback, void* userData)
    {
        return lpVtbl->enumeratePathContents((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), path, callback, userData);
    }

    /// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt.getOSPathKind"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public OSPathKind getOSPathKind()
    {
        return lpVtbl->getOSPathKind((ISlangFileSystemExt*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, uint> release;

        [NativeTypeName("void *(const SlangUUID &) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, SlangUUID*, void*> castAs;

        [NativeTypeName("SlangResult (const char *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, sbyte*, ISlangBlob**, int> loadFile;

        [NativeTypeName("SlangResult (const char *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, sbyte*, ISlangBlob**, int> getFileUniqueIdentity;

        [NativeTypeName("SlangResult (SlangPathType, const char *, const char *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, SlangPathType, sbyte*, sbyte*, ISlangBlob**, int> calcCombinedPath;

        [NativeTypeName("SlangResult (const char *, SlangPathType *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, sbyte*, SlangPathType*, int> getPathType;

        [NativeTypeName("SlangResult (PathKind, const char *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, PathKind, sbyte*, ISlangBlob**, int> getPath;

        [NativeTypeName("void () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, void> clearCache;

        [NativeTypeName("SlangResult (const char *, FileSystemContentsCallBack, void *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, sbyte*, delegate* unmanaged[Thiscall]<SlangPathType, sbyte*, void*, void>, void*, int> enumeratePathContents;

        [NativeTypeName("OSPathKind () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangFileSystemExt*, OSPathKind> getOSPathKind;
    }
}
