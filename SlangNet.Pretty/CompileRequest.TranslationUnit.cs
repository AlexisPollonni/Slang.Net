﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SlangNet;

unsafe partial class CompileRequest
{
    [GenerateThrowingMethods]
    public readonly partial struct TranslationUnit : IEquatable<TranslationUnit>
    {
        private readonly ICompileRequest* pointer;
        public int Index { get; }

        internal TranslationUnit(ICompileRequest* pointer, int index)
        {
            this.pointer = pointer;
            Index = index;
        }

        public bool Equals(TranslationUnit other) => pointer == other.pointer && Index == other.Index;
        public override bool Equals(object? obj) => obj is TranslationUnit other && Equals(other);
        public static bool operator ==(TranslationUnit a, TranslationUnit b) => a.Equals(b);
        public static bool operator !=(TranslationUnit a, TranslationUnit b) => !a.Equals(b);
        public override int GetHashCode() => InteropUtils.CombineHash(new IntPtr(pointer), Index);

        public void AddTranslationUnitPreprocessorDefine(ReadOnlySpan<byte> key, ReadOnlySpan<byte> value)
        {
            fixed (byte* keyPtr = key)
            fixed (byte* valuePtr = value)
                pointer->addTranslationUnitPreprocessorDefine(Index, (sbyte*)keyPtr, (sbyte*)valuePtr);
        }

        public void AddTranslationUnitPreprocessorDefine(string key, string value)
        {
            using var keyStr = new Utf8String(key);
            using var valueStr = new Utf8String(value);
            pointer->addTranslationUnitPreprocessorDefine(Index, keyStr, valueStr);
        }

        public void AddTranslationUnitSourceFile(ReadOnlySpan<byte> path)
        {
            fixed (byte* pathPtr = path)
                pointer->addTranslationUnitSourceFile(Index, (sbyte*)pathPtr);
        }

        public void AddTranslationUnitSourceFile(string path)
        {
            using var pathStr = new Utf8String(path);
            pointer->addTranslationUnitSourceFile(Index, pathStr);
        }

        public void AddTranslationUnitSourceString(ReadOnlySpan<byte> path, ReadOnlySpan<byte> source)
        {
            fixed (byte* pathPtr = path)
            fixed (byte* sourcePtr = source)
                pointer->addTranslationUnitSourceStringSpan(Index, (sbyte*)pathPtr, (sbyte*)sourcePtr, (sbyte*)sourcePtr + source.Length);
        }

        public void AddTranslationUnitSourceString(string path, string source)
        {
            using var pathStr = new Utf8String(path);
            using var sourceStr = new Utf8String(source);
            pointer->addTranslationUnitSourceString(Index, pathStr, sourceStr);
        }

        // skipping SourceStringSpan and SourceBlob

        public int AddEntryPoint(ReadOnlySpan<byte> name, Stage stage)
        {
            fixed (byte* namePtr = name)
                return pointer->addEntryPoint(Index, (sbyte*)namePtr, stage);
        }

        public int AddEntryPoint(string name, Stage stage)
        {
            using var nameStr = new Utf8String(name);
            return pointer->addEntryPoint(Index, nameStr, stage);
        }

        public int AddEntryPointEx(string name, Stage stage, IEnumerable<string> genericArgs)
        {
            using var nameStr = new Utf8String(name);
            using var genericArgsArray = new Utf8StringArray(genericArgs);
            return pointer->addEntryPointEx(Index, nameStr, stage, genericArgsArray.Count, genericArgsArray.Memory);
        }

        public SlangResult TryGetModule([NotNullWhen(true)] out Module? module)
        {
            IModule* modulePtr = null;
            var result = pointer->getModule(Index, &modulePtr);
            module = modulePtr == null ? null : new(modulePtr);
            return new(result);
        }
    }

    public struct TranslationUnitList : IReadOnlyList<TranslationUnit>
    {
        private readonly NativeBoundedReadOnlyList<ICompileRequest, TranslationUnit> list;

        public TranslationUnitList(ICompileRequest* request)
        {
            list = new()
            {
                Container = request,
                GetCount = request1 => request1->getTranslationUnitCount(),
                TryGetAt = (ICompileRequest* request1, nint index, out TranslationUnit unit) =>
                {
                    unit = new(request1, checked((int)index));
                    return true;
                }
            };
        }

        public TranslationUnit Add(SourceLanguage language, string? name = null)
        {
            using var nameStr = new Utf8String(name);
            return new(list.Container, list.Container->addTranslationUnit(language, nameStr));
        }

        public TranslationUnit this[int index] => list[index];
        public int Count => (int)list.Count;
        public IEnumerator<TranslationUnit> GetEnumerator() => list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
