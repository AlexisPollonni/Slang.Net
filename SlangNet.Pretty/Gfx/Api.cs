using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SlangNet.Gfx;


public static unsafe partial class Api
{
    public static bool IsCompressedFormat(Format format)
    {
        return gfxIsCompressedFormat(format) == 1;
    }

    public static bool IsTypelessFormat(Format format)
    {
        return gfxIsTypelessFormat(format) == 1;
    }

    public static unsafe SlangResult TryGetFormatInfo(Format format, out FormatInfo? formatInfo)
    {
        var info = new FormatInfo();
        var res = gfxGetFormatInfo(format, &info).ToSlangResult();
        
        formatInfo = res ?  info : null;
        return res;
    }
    
    public static SlangResult TryGetAdapters(DeviceType deviceType, out IReadOnlyList<AdapterInfo>? adapters)
    {
        ISlangBlob* adaptersBlob = null;
        var res = gfxGetAdapters(deviceType, &adaptersBlob).ToSlangResult();
        
        if(!res)
        {
            adapters = null;
            return res;
        }
        var ptr = (Unsafe.AdapterInfo*)adaptersBlob->getBufferPointer();

        if(ptr is null)
        {
            adapters = null;
            return res;
        }
        var count = (int)adaptersBlob->getBufferSize() / sizeof(Unsafe.AdapterInfo);

        adapters = InteropUtils.MarshalArrayToManaged<AdapterInfo, Unsafe.AdapterInfo>(ptr, count);

        adaptersBlob->release();
        return res;
    }
    public static SlangResult TryReportLiveObjects() =>
        gfxReportLiveObjects().ToSlangResult();

    public static void EnableDebugLayer() => gfxEnableDebugLayer();

    public static string GetDeviceTypeName(DeviceType type) =>
        InteropUtils.PtrToStringUTF8(gfxGetDeviceTypeName(type))!;

    // Keep a static reference to prevent garbage collection
    private static DebugCallbackImpl? _debugCallbackInstance;

    public static SlangResult TrySetDebugCallback(Action<DebugMessageType, DebugMessageSource, string>? callback)
    {
        // If null, remove the callback
        if (callback == null)
        {
            _debugCallbackInstance?.Dispose();
            _debugCallbackInstance = null;
            return gfxSetDebugCallback(null).ToSlangResult();
        }


        // Create our implementation
        _debugCallbackInstance = new DebugCallbackImpl(callback);
        
        // Get the native pointer to our implementation
        var nativePtr = _debugCallbackInstance.NativePointer;
        
        // Set the callback
        return gfxSetDebugCallback(nativePtr).ToSlangResult();
    }

    // Implementation of the IDebugCallback interface
    private unsafe class DebugCallbackImpl : IDisposable
    {
        // The managed callback to invoke
        private readonly Action<DebugMessageType, DebugMessageSource, string> _callback;
        
        // The vtable for our implementation
        private readonly IDebugCallback.Vtbl _vtbl;
        
        // The delegate for the handleMessage function
        private readonly IDebugCallback._handleMessage _handleMessageDelegate;
        
        // The native pointer to our implementation
        private readonly IDebugCallback* _nativePtr;
        
        // GCHandle to prevent our instance from being collected
        private GCHandle _gcHandle;
        
        public DebugCallbackImpl(Action<DebugMessageType, DebugMessageSource, string> callback)
        {
            _callback = callback;
            
            // Create the delegate for the handleMessage function
            _handleMessageDelegate = HandleMessage;
            
            // Create the vtable
            _vtbl = new IDebugCallback.Vtbl
            {
                handleMessage = Marshal.GetFunctionPointerForDelegate(_handleMessageDelegate)
            };
            
            // Allocate memory for the native structure
            _nativePtr = (IDebugCallback*)NativeMemory.Alloc((nuint)sizeof(IDebugCallback));
            
            // Set the vtable pointer
            _nativePtr->lpVtbl = (IDebugCallback.Vtbl*)NativeMemory.Alloc((nuint)sizeof(IDebugCallback.Vtbl));
            *_nativePtr->lpVtbl = _vtbl;
            
            // Keep a GCHandle to prevent our instance from being collected
            _gcHandle = GCHandle.Alloc(this);
        }
        
        // The implementation of the handleMessage function
        private void HandleMessage(IDebugCallback* pThis, DebugMessageType type, DebugMessageSource source, sbyte* message)
        {
            try
            {
                // Convert the message to a managed string
                string managedMessage = message != null ? InteropUtils.PtrToStringUTF8(message) ?? string.Empty : string.Empty;
                
                // Invoke the callback
                _callback(type, source, managedMessage);
            }
            catch (Exception ex)
            {
                // Log the exception - don't let it propagate to native code
                Console.WriteLine($"Exception in debug callback: {ex}");
            }
        }
        
        // Get the native pointer to our implementation
        public IDebugCallback* NativePointer => _nativePtr;
        
        // Dispose pattern to clean up native resources
        public void Dispose()
        {
            if (_nativePtr != null)
            {
                if (_nativePtr->lpVtbl != null)
                {
                    NativeMemory.Free(_nativePtr->lpVtbl);
                }
                
                NativeMemory.Free(_nativePtr);
            }
            
            if (_gcHandle.IsAllocated)
            {
                _gcHandle.Free();
            }
        }
        
        // Finalizer as a backup
        ~DebugCallbackImpl()
        {
            Dispose();
        }
    }
}