using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='ISlangMutableFileSystem.xml' path='doc/member[@name="ISlangMutableFileSystem"]/*' />
[Guid("A058675C-1D65-452A-8458-CCDED1427105")]
[NativeTypeName("struct ISlangMutableFileSystem : ISlangFileSystemExt")]
[NativeInheritance("ISlangFileSystemExt")]
public unsafe partial struct ISlangMutableFileSystem
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ISlangMutableFileSystem* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ISlangMutableFileSystem* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ISlangMutableFileSystem* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void* _castAs(ISlangMutableFileSystem* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* guid);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _loadFile(ISlangMutableFileSystem* pThis, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** outBlob);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getFileUniqueIdentity(ISlangMutableFileSystem* pThis, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** outUniqueIdentity);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _calcCombinedPath(ISlangMutableFileSystem* pThis, [NativeTypeName("SlangPathType")] PathType fromPathType, [NativeTypeName("const char *")] sbyte* fromPath, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** pathOut);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getPathType(ISlangMutableFileSystem* pThis, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("SlangPathType *")] PathType* pathTypeOut);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getPath(ISlangMutableFileSystem* pThis, PathKind kind, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** outPath);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _clearCache(ISlangMutableFileSystem* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _enumeratePathContents(ISlangMutableFileSystem* pThis, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("FileSystemContentsCallBack")] IntPtr callback, void* userData);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate OSPathKind _getOSPathKind(ISlangMutableFileSystem* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _saveFile(ISlangMutableFileSystem* pThis, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint size);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _saveFileBlob(ISlangMutableFileSystem* pThis, [NativeTypeName("const char *")] sbyte* path, ISlangBlob* dataBlob);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _remove(ISlangMutableFileSystem* pThis, [NativeTypeName("const char *")] sbyte* path);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _createDirectory(ISlangMutableFileSystem* pThis, [NativeTypeName("const char *")] sbyte* path);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangCastable.castAs" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* castAs([NativeTypeName("const SlangUUID &")] SlangUUID* guid)
    {
        return Marshal.GetDelegateForFunctionPointer<_castAs>(lpVtbl->castAs)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), guid);
    }

    /// <inheritdoc cref="ISlangFileSystem.loadFile" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int loadFile([NativeTypeName("const char *")] sbyte* path, ISlangBlob** outBlob)
    {
        return Marshal.GetDelegateForFunctionPointer<_loadFile>(lpVtbl->loadFile)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, outBlob);
    }

    /// <inheritdoc cref="ISlangFileSystemExt.getFileUniqueIdentity" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getFileUniqueIdentity([NativeTypeName("const char *")] sbyte* path, ISlangBlob** outUniqueIdentity)
    {
        return Marshal.GetDelegateForFunctionPointer<_getFileUniqueIdentity>(lpVtbl->getFileUniqueIdentity)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, outUniqueIdentity);
    }

    /// <inheritdoc cref="ISlangFileSystemExt.calcCombinedPath" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int calcCombinedPath([NativeTypeName("SlangPathType")] PathType fromPathType, [NativeTypeName("const char *")] sbyte* fromPath, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** pathOut)
    {
        return Marshal.GetDelegateForFunctionPointer<_calcCombinedPath>(lpVtbl->calcCombinedPath)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), fromPathType, fromPath, path, pathOut);
    }

    /// <inheritdoc cref="ISlangFileSystemExt.getPathType" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getPathType([NativeTypeName("const char *")] sbyte* path, [NativeTypeName("SlangPathType *")] PathType* pathTypeOut)
    {
        return Marshal.GetDelegateForFunctionPointer<_getPathType>(lpVtbl->getPathType)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, pathTypeOut);
    }

    /// <inheritdoc cref="ISlangFileSystemExt.getPath" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getPath(PathKind kind, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** outPath)
    {
        return Marshal.GetDelegateForFunctionPointer<_getPath>(lpVtbl->getPath)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), kind, path, outPath);
    }

    /// <inheritdoc cref="ISlangFileSystemExt.clearCache" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void clearCache()
    {
        Marshal.GetDelegateForFunctionPointer<_clearCache>(lpVtbl->clearCache)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangFileSystemExt.enumeratePathContents" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int enumeratePathContents([NativeTypeName("const char *")] sbyte* path, [NativeTypeName("FileSystemContentsCallBack")] IntPtr callback, void* userData)
    {
        return Marshal.GetDelegateForFunctionPointer<_enumeratePathContents>(lpVtbl->enumeratePathContents)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, callback, userData);
    }

    /// <inheritdoc cref="ISlangFileSystemExt.getOSPathKind" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public OSPathKind getOSPathKind()
    {
        return Marshal.GetDelegateForFunctionPointer<_getOSPathKind>(lpVtbl->getOSPathKind)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangMutableFileSystem.xml' path='doc/member[@name="ISlangMutableFileSystem.saveFile"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int saveFile([NativeTypeName("const char *")] sbyte* path, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint size)
    {
        return Marshal.GetDelegateForFunctionPointer<_saveFile>(lpVtbl->saveFile)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, data, size);
    }

    /// <include file='ISlangMutableFileSystem.xml' path='doc/member[@name="ISlangMutableFileSystem.saveFileBlob"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int saveFileBlob([NativeTypeName("const char *")] sbyte* path, ISlangBlob* dataBlob)
    {
        return Marshal.GetDelegateForFunctionPointer<_saveFileBlob>(lpVtbl->saveFileBlob)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path, dataBlob);
    }

    /// <include file='ISlangMutableFileSystem.xml' path='doc/member[@name="ISlangMutableFileSystem.remove"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int remove([NativeTypeName("const char *")] sbyte* path)
    {
        return Marshal.GetDelegateForFunctionPointer<_remove>(lpVtbl->remove)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path);
    }

    /// <include file='ISlangMutableFileSystem.xml' path='doc/member[@name="ISlangMutableFileSystem.createDirectory"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int createDirectory([NativeTypeName("const char *")] sbyte* path)
    {
        return Marshal.GetDelegateForFunctionPointer<_createDirectory>(lpVtbl->createDirectory)((ISlangMutableFileSystem*)Unsafe.AsPointer(ref this), path);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("void *(const SlangUUID &) __attribute__((stdcall))")]
        public IntPtr castAs;

        [NativeTypeName("SlangResult (const char *, ISlangBlob **) __attribute__((stdcall))")]
        public IntPtr loadFile;

        [NativeTypeName("SlangResult (const char *, ISlangBlob **) __attribute__((stdcall))")]
        public IntPtr getFileUniqueIdentity;

        [NativeTypeName("SlangResult (SlangPathType, const char *, const char *, ISlangBlob **) __attribute__((stdcall))")]
        public IntPtr calcCombinedPath;

        [NativeTypeName("SlangResult (const char *, SlangPathType *) __attribute__((stdcall))")]
        public IntPtr getPathType;

        [NativeTypeName("SlangResult (PathKind, const char *, ISlangBlob **) __attribute__((stdcall))")]
        public IntPtr getPath;

        [NativeTypeName("void () __attribute__((stdcall))")]
        public IntPtr clearCache;

        [NativeTypeName("SlangResult (const char *, FileSystemContentsCallBack, void *) __attribute__((stdcall))")]
        public IntPtr enumeratePathContents;

        [NativeTypeName("OSPathKind () __attribute__((stdcall))")]
        public IntPtr getOSPathKind;

        [NativeTypeName("SlangResult (const char *, const void *, size_t) __attribute__((stdcall))")]
        public IntPtr saveFile;

        [NativeTypeName("SlangResult (const char *, ISlangBlob *) __attribute__((stdcall))")]
        public IntPtr saveFileBlob;

        [NativeTypeName("SlangResult (const char *) __attribute__((stdcall))")]
        public IntPtr remove;

        [NativeTypeName("SlangResult (const char *) __attribute__((stdcall))")]
        public IntPtr createDirectory;
    }
}
