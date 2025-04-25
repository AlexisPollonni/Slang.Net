using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Gfx.Descriptions;
using SlangNet.ComWrappers.Gfx.Interfaces;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools;
using DeviceType = SlangNet.Bindings.Generated.DeviceType;
using Format = SlangNet.Bindings.Generated.Format;
using FormatInfo = SlangNet.Bindings.Generated.FormatInfo;

namespace SlangNet.ComWrappers.Gfx;

public static partial class Gfx
{
    [LibraryImport("gfx", EntryPoint = "gfxIsCompressedFormat")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool IsCompressedFormat(Format format);

    [LibraryImport("gfx", EntryPoint = "gfxIsTypelessFormat")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool IsTypelessFormat(Format format);

    [LibraryImport("gfx", EntryPoint = "gfxGetFormatInfo")]
    public static partial SlangResult GetFormatInfo(Format format, out FormatInfo outInfo);

    [LibraryImport("gfx", EntryPoint = "gfxGetAdapters")]
    public static partial SlangResult GetAdapters(DeviceType type, out IBlob outAdaptersBlob);

    public static IReadOnlyList<AdapterInfo> GetAdapters(DeviceType type)
    {
        GetAdapters(type, out var blob).ThrowIfFailed();

        return new AdaptersList(blob);
    }

    private class AdaptersList(IBlob adaptersBlob) : NativeResultReadOnlyList<AdapterInfo>
    {
        public override unsafe int Count => (int)(adaptersBlob.GetBufferSize() / (ulong)sizeof(Unmanaged.AdapterInfo));

        public override unsafe SlangResult TryGetAt(int index, out AdapterInfo value)
        {
            var count = Count;
            if (count <= 0 || index >= count)
            {
                value = default;
                return SlangResult.InvalidParameter;
            }

            var span = new ReadOnlySpan<Unmanaged.AdapterInfo>(adaptersBlob.GetBufferPointer(), count);

            value = AdapterInfo.CreateFromNative(span[index]);
            return SlangResult.Ok;
        }
    }

    [LibraryImport("gfx", EntryPoint = "gfxCreateDevice")]
    public static partial SlangResult CreateDevice(DeviceDescription desc, out IDevice outDevice);

    [LibraryImport("gfx", EntryPoint = "gfxReportLiveObjects")]
    public static partial SlangResult ReportLiveObjects();

    [LibraryImport("gfx", EntryPoint = "gfxEnableDebugLayer")]
    public static partial void EnableDebugLayer();

    [LibraryImport("gfx", EntryPoint = "gfxGetDeviceTypeName")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? GetDeviceTypeName(DeviceType type);

    //TODO: Find a better way to do all this
    // Keep a static reference to prevent garbage collection
    private static DebugCallbackImpl? _debugCallbackInstance;

    public static unsafe SlangResult SetDebugCallback(
        Action<Unmanaged.DebugMessageType, Unmanaged.DebugMessageSource, string>? callback)
    {
        // If null, remove the callback
        if (callback == null)
        {
            _debugCallbackInstance?.Dispose();
            _debugCallbackInstance = null;
            return Unmanaged.GfxApi.gfxSetDebugCallback(null).ToSlangResult();
        }


        // Create our implementation
        _debugCallbackInstance = new(callback);

        // Get the native pointer to our implementation
        var nativePtr = _debugCallbackInstance.NativePointer;

        // Set the callback
        return Unmanaged.GfxApi.gfxSetDebugCallback(nativePtr).ToSlangResult();
    }

    // Implementation of the IDebugCallback interface
    private sealed unsafe class DebugCallbackImpl : IDisposable
    {
        // The managed callback to invoke
        private readonly Action<Unmanaged.DebugMessageType, Unmanaged.DebugMessageSource, string> _callback;

        // The vtable for our implementation
        private readonly Unmanaged.IDebugCallback.Vtbl _vtbl;

        // The delegate for the handleMessage function
        private readonly Unmanaged.IDebugCallback._handleMessage _handleMessageDelegate;

        // The native pointer to our implementation
        private readonly Unmanaged.IDebugCallback* _nativePtr;

        // GCHandle to prevent our instance from being collected
        private GCHandle _gcHandle;

        public DebugCallbackImpl(Action<Unmanaged.DebugMessageType, Unmanaged.DebugMessageSource, string> callback)
        {
            _callback = callback;

            // Create the delegate for the handleMessage function
            _handleMessageDelegate = HandleMessage;

            // Create the vtable
            _vtbl = new()
            {
                handleMessage = Marshal.GetFunctionPointerForDelegate(_handleMessageDelegate)
            };

            // Allocate memory for the native structure
            _nativePtr = (Unmanaged.IDebugCallback*)NativeMemory.Alloc((nuint)sizeof(Unmanaged.IDebugCallback));

            // Set the vtable pointer
            _nativePtr->lpVtbl
                = (Unmanaged.IDebugCallback.Vtbl*)NativeMemory.Alloc((nuint)sizeof(Unmanaged.IDebugCallback.Vtbl));
            *_nativePtr->lpVtbl = _vtbl;

            // Keep a GCHandle to prevent our instance from being collected
            _gcHandle = GCHandle.Alloc(this);
        }

        // The implementation of the handleMessage function
        private void HandleMessage(Unmanaged.IDebugCallback* pThis,
                                   Unmanaged.DebugMessageType type,
                                   Unmanaged.DebugMessageSource source,
                                   sbyte* message)
        {
            try
            {
                // Convert the message to a managed string
                string managedMessage
                    = message != null ? InteropUtils.PtrToStringUtf8(message) ?? string.Empty : string.Empty;

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
        public Unmanaged.IDebugCallback* NativePointer => _nativePtr;

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