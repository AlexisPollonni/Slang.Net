﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom,
                       StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("AFDAB195-361F-42CB-9513-9006261DD8CD")]
//TODO: Finish marshalling code for callbacks
public partial interface IByteCodeRunner : IUnknown
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult LoadModule(IBlob moduleBlob);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SelectFunctionByIndex(uint functionIndex);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    int FindFunctionByName(string name);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetFunctionInfo(uint index, out Unmanaged.ByteCodeFuncInfo outInfo);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    unsafe void* GetCurrentWorkingSet();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult Execute([MarshalUsing(CountElementName = "argumentSize")] Span<byte> argumentData,
                        nuint argumentSize);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void GetErrorString(out IBlob outBlob);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(CountElementName = "outValueSize")]
    Span<byte> GetReturnValue(out nuint outValueSize);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    unsafe void SetExtInstHandlerUserData(void* userData);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult RegisterExtCall(string name, Action<IByteCodeRunner, nint, nint> function);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetPrintCallback(Action<string, nint> callback, nint userData);
}