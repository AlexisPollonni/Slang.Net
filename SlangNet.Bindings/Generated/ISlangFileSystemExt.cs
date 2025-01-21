using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.Slang;

/// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt"]/*' />
[Guid("5FB632D2-979D-4481-9FEE-663C3F1449E1")]
[NativeTypeName("struct ISlangFileSystemExt : ISlangFileSystem")]
[NativeInheritance("ISlangFileSystem")]
public unsafe partial struct ISlangFileSystemExt
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ISlangFileSystemExt* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ISlangFileSystemExt* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ISlangFileSystemExt* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void* _castAs(ISlangFileSystemExt* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* guid);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _loadFile(ISlangFileSystemExt* pThis, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** outBlob);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getFileUniqueIdentity(ISlangFileSystemExt* pThis, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** outUniqueIdentity);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _calcCombinedPath(ISlangFileSystemExt* pThis, [NativeTypeName("SlangPathType")] PathType fromPathType, [NativeTypeName("const char *")] sbyte* fromPath, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** pathOut);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getPathType(ISlangFileSystemExt* pThis, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("SlangPathType *")] PathType* pathTypeOut);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getPath(ISlangFileSystemExt* pThis, PathKind kind, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** outPath);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _clearCache(ISlangFileSystemExt* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _enumeratePathContents(ISlangFileSystemExt* pThis, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("FileSystemContentsCallBack")] IntPtr callback, void* userData);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate OSPathKind _getOSPathKind(ISlangFileSystemExt* pThis);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ISlangFileSystemExt*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ISlangFileSystemExt*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangCastable.castAs" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* castAs([NativeTypeName("const SlangUUID &")] SlangUUID* guid)
    {
        return Marshal.GetDelegateForFunctionPointer<_castAs>(lpVtbl->castAs)((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), guid);
    }

    /// <inheritdoc cref="ISlangFileSystem.loadFile" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int loadFile([NativeTypeName("const char *")] sbyte* path, ISlangBlob** outBlob)
    {
        return Marshal.GetDelegateForFunctionPointer<_loadFile>(lpVtbl->loadFile)((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), path, outBlob);
    }

    /// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt.getFileUniqueIdentity"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getFileUniqueIdentity([NativeTypeName("const char *")] sbyte* path, ISlangBlob** outUniqueIdentity)
    {
        return Marshal.GetDelegateForFunctionPointer<_getFileUniqueIdentity>(lpVtbl->getFileUniqueIdentity)((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), path, outUniqueIdentity);
    }

    /// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt.calcCombinedPath"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int calcCombinedPath([NativeTypeName("SlangPathType")] PathType fromPathType, [NativeTypeName("const char *")] sbyte* fromPath, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** pathOut)
    {
        return Marshal.GetDelegateForFunctionPointer<_calcCombinedPath>(lpVtbl->calcCombinedPath)((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), fromPathType, fromPath, path, pathOut);
    }

    /// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt.getPathType"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getPathType([NativeTypeName("const char *")] sbyte* path, [NativeTypeName("SlangPathType *")] PathType* pathTypeOut)
    {
        return Marshal.GetDelegateForFunctionPointer<_getPathType>(lpVtbl->getPathType)((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), path, pathTypeOut);
    }

    /// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt.getPath"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getPath(PathKind kind, [NativeTypeName("const char *")] sbyte* path, ISlangBlob** outPath)
    {
        return Marshal.GetDelegateForFunctionPointer<_getPath>(lpVtbl->getPath)((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), kind, path, outPath);
    }

    /// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt.clearCache"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void clearCache()
    {
        Marshal.GetDelegateForFunctionPointer<_clearCache>(lpVtbl->clearCache)((ISlangFileSystemExt*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt.enumeratePathContents"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int enumeratePathContents([NativeTypeName("const char *")] sbyte* path, [NativeTypeName("FileSystemContentsCallBack")] IntPtr callback, void* userData)
    {
        return Marshal.GetDelegateForFunctionPointer<_enumeratePathContents>(lpVtbl->enumeratePathContents)((ISlangFileSystemExt*)Unsafe.AsPointer(ref this), path, callback, userData);
    }

    /// <include file='ISlangFileSystemExt.xml' path='doc/member[@name="ISlangFileSystemExt.getOSPathKind"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public OSPathKind getOSPathKind()
    {
        return Marshal.GetDelegateForFunctionPointer<_getOSPathKind>(lpVtbl->getOSPathKind)((ISlangFileSystemExt*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;

        [NativeTypeName("void *(const SlangUUID &)")]
        public IntPtr castAs;

        [NativeTypeName("SlangResult (const char *, ISlangBlob **)")]
        public IntPtr loadFile;

        [NativeTypeName("SlangResult (const char *, ISlangBlob **)")]
        public IntPtr getFileUniqueIdentity;

        [NativeTypeName("SlangResult (SlangPathType, const char *, const char *, ISlangBlob **)")]
        public IntPtr calcCombinedPath;

        [NativeTypeName("SlangResult (const char *, SlangPathType *)")]
        public IntPtr getPathType;

        [NativeTypeName("SlangResult (PathKind, const char *, ISlangBlob **)")]
        public IntPtr getPath;

        [NativeTypeName("void ()")]
        public IntPtr clearCache;

        [NativeTypeName("SlangResult (const char *, FileSystemContentsCallBack, void *)")]
        public IntPtr enumeratePathContents;

        [NativeTypeName("OSPathKind ()")]
        public IntPtr getOSPathKind;
    }
}
