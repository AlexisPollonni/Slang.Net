using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISlangMutableFileSystem.xml' path='doc/member[@name="ISlangMutableFileSystem"]/*' />
[NativeTypeName("struct ISlangMutableFileSystem : ISlangFileSystemExt")]
public unsafe partial struct ISlangMutableFileSystem
{
    public Vtbl* lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return lpVtbl->queryInterface((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return lpVtbl->addRef((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return lpVtbl->release((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangCastable.castAs" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* castAs([NativeTypeName("const SlangUUID &")] SlangUUID* guid)
    {
        return lpVtbl->castAs((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), guid);
    }

    /// <inheritdoc cref="ISlangFileSystem.loadFile" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int loadFile([NativeTypeName("const char *")] sbyte* path, ISlangBlob** outBlob)
    {
        return lpVtbl->loadFile((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, outBlob);
    }

    /// <inheritdoc cref="ISlangFileSystemExt.getFileUniqueIdentity" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getFileUniqueIdentity([NativeTypeName("const char *")] sbyte* path, ISlangBlob** outUniqueIdentity)
    {
        return lpVtbl->getFileUniqueIdentity((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, outUniqueIdentity);
    }

    /// <inheritdoc cref="ISlangFileSystemExt.calcCombinedPath" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int calcCombinedPath(SlangPathType fromPathType, [NativeTypeName("const char *")] sbyte* fromPath, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** pathOut)
    {
        return lpVtbl->calcCombinedPath((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), fromPathType, fromPath, path, pathOut);
    }

    /// <inheritdoc cref="ISlangFileSystemExt.getPathType" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getPathType([NativeTypeName("const char *")] sbyte* path, SlangPathType* pathTypeOut)
    {
        return lpVtbl->getPathType((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, pathTypeOut);
    }

    /// <inheritdoc cref="ISlangFileSystemExt.getPath" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getPath(PathKind kind, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** outPath)
    {
        return lpVtbl->getPath((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), kind, path, outPath);
    }

    /// <inheritdoc cref="ISlangFileSystemExt.clearCache" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void clearCache()
    {
        lpVtbl->clearCache((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangFileSystemExt.enumeratePathContents" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int enumeratePathContents([NativeTypeName("const char *")] sbyte* path, [NativeTypeName("FileSystemContentsCallBack")] delegate* unmanaged[Cdecl]<SlangPathType, sbyte*, void*, void> callback, void* userData)
    {
        return lpVtbl->enumeratePathContents((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, callback, userData);
    }

    /// <inheritdoc cref="ISlangFileSystemExt.getOSPathKind" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public OSPathKind getOSPathKind()
    {
        return lpVtbl->getOSPathKind((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangMutableFileSystem.xml' path='doc/member[@name="ISlangMutableFileSystem.saveFile"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int saveFile([NativeTypeName("const char *")] sbyte* path, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint size)
    {
        return lpVtbl->saveFile((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, data, size);
    }

    /// <include file='ISlangMutableFileSystem.xml' path='doc/member[@name="ISlangMutableFileSystem.saveFileBlob"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int saveFileBlob([NativeTypeName("const char *")] sbyte* path, ISlangBlob* dataBlob)
    {
        return lpVtbl->saveFileBlob((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, dataBlob);
    }

    /// <include file='ISlangMutableFileSystem.xml' path='doc/member[@name="ISlangMutableFileSystem.remove"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int remove([NativeTypeName("const char *")] sbyte* path)
    {
        return lpVtbl->remove((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path);
    }

    /// <include file='ISlangMutableFileSystem.xml' path='doc/member[@name="ISlangMutableFileSystem.createDirectory"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int createDirectory([NativeTypeName("const char *")] sbyte* path)
    {
        return lpVtbl->createDirectory((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, uint> release;

        [NativeTypeName("void *(const SlangUUID &) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, SlangUUID*, void*> castAs;

        [NativeTypeName("SlangResult (const char *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, ISlangBlob**, int> loadFile;

        [NativeTypeName("SlangResult (const char *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, ISlangBlob**, int> getFileUniqueIdentity;

        [NativeTypeName("SlangResult (SlangPathType, const char *, const char *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, SlangPathType, sbyte*, sbyte*, ISlangBlob**, int> calcCombinedPath;

        [NativeTypeName("SlangResult (const char *, SlangPathType *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, SlangPathType*, int> getPathType;

        [NativeTypeName("SlangResult (PathKind, const char *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, PathKind, sbyte*, ISlangBlob**, int> getPath;

        [NativeTypeName("void () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, void> clearCache;

        [NativeTypeName("SlangResult (const char *, FileSystemContentsCallBack, void *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, delegate* unmanaged[Thiscall]<SlangPathType, sbyte*, void*, void>, void*, int> enumeratePathContents;

        [NativeTypeName("OSPathKind () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, OSPathKind> getOSPathKind;

        [NativeTypeName("SlangResult (const char *, const void *, size_t) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, void*, nuint, int> saveFile;

        [NativeTypeName("SlangResult (const char *, ISlangBlob *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, ISlangBlob*, int> saveFileBlob;

        [NativeTypeName("SlangResult (const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, int> remove;

        [NativeTypeName("SlangResult (const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangMutableFileSystem*, sbyte*, int> createDirectory;
    }
}
