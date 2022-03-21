// this file is not autogenerated!
// random utils to make .NET bindings tick

using System;
// using System.Collections.Generic;
using System.Diagnostics;
// using System.Linq;
// using System.Runtime.InteropServices;
// using System.Text;
// using System.Threading;
using Unity.InputSystem.Runtime;

namespace Unity.InputSystem.Runtime
{
    public static unsafe partial class Native
    {
        public static InputDeviceRef InputInstantiateDevice(Guid guid, InputDevicePersistentIdentifier identifier = default)
        {
            return InputInstantiateDevice((InputGuid)guid, identifier);
        }

        public static void InputSwapFramebuffer()
        {
            InputSwapFramebuffer(InputCurrentAPIContext.CurrentFramebuffer);
        }

    }
    

#if false

    public static unsafe partial class Native
    {
        // TODO use burst shared static here 
        // public static readonly SharedStatic<int> IntField = SharedStatic<int>.GetOrCreate<MutableStaticTest, IntFieldKey>();
        // private class IntFieldKey {}
        private static Input_RuntimeContext* Input_RuntimeContext_ManagedPointer;

        public static Input_RuntimeContext* Input_GetRuntimeContext()
        {
            return Input_RuntimeContext_ManagedPointer;
        }

        public static void Input_SetRuntimeContext(Input_RuntimeContext* context)
        {
            if (Input_GetAPIVersion_ForManaged() != Input_GetAPIVersion_ForNative())
            {
                throw new InvalidOperationException(
                    $"Managed API version {Input_GetAPIVersion_ForManaged()} != Native API version {Input_GetAPIVersion_ForNative()}, please reload the native input plugin");
            }
            
            Input_RuntimeContext_ManagedPointer = context;
            Input_SetRuntimeContext_ForNative(context);
        }

        // TODO this is fine for normal managed code, but Burst will not like any of this
        public static uint Input_RegisterDevice(
            Input_Device_PersistentId* persistentId,
            string displayName,
            Input_Control_Usage[] usages,
            Input_Device_RuntimeRegistration_PlatformData platformData
        )
        {
            var displayNameBytes = Encoding.UTF8.GetBytes(displayName);
            fixed (byte* displayNameBytesPtr = displayNameBytes)
            {
                var usagesPinHandle = GCHandle.Alloc(usages, GCHandleType.Pinned);
                try
                {
                    var usagesArr = new byte[usages.Length * Marshal.SizeOf(typeof(Input_Control_Usage))];
                    Marshal.Copy(usagesPinHandle.AddrOfPinnedObject(), usagesArr, 0, usagesArr.Length);

                    fixed (byte* usagesBytes = usagesArr)
                    {
                        return Input_RegisterDevice(persistentId, (sbyte*)displayNameBytesPtr,
                            (Input_Control_Usage*)usagesBytes, (uint)usages.Length, platformData);
                    }
                }
                finally
                {
                    if (usagesPinHandle.IsAllocated)
                        usagesPinHandle.Free();
                }
            }
        }

        public static void Input_Log(byte[] msg)
        {
            fixed (byte* p = msg)
                Input_Log((sbyte*)p);
        }
        
        public static void Input_Log(string msg)
        {
            // TODO wtf remove this
            var bytes = Encoding.UTF8.GetBytes(msg).Append((byte)0).ToArray();
            fixed (byte* p = bytes)
                InputLog((sbyte*)p);
        }

        public static void InputAssertFormatted(bool expr)
        {
            if (!expr)
                throw new InvalidOperationException();
        }

        public static uint Input_PAL_AtomicUint32_Load(Input_PAL_AtomicUint32* atomic)
        {
            // Tbh not sure about this one, we do need a barrier though
            return (uint)Interlocked.Add(ref atomic->value, 0);
        }

        public static void Input_PAL_AtomicUint32_Store(Input_PAL_AtomicUint32* atomic, uint value)
        {
            Interlocked.Exchange(ref atomic->value, (int)value);
        }

        public static uint Input_PAL_AtomicUint32_Exchange(Input_PAL_AtomicUint32* atomic, uint newValue)
        {
            return (uint)Interlocked.Exchange(ref atomic->value, (int)newValue);
        }

        public static void Input_PAL_Thread_SpinWait()
        {
            Thread.SpinWait(1);
        }

        public static string Input_Control_SampleToStringForTypeId(uint typeId, void* latestSample)
        {
            var output = stackalloc sbyte[512];
            Input_Control_SampleToStringForTypeId(typeId, latestSample, output, 512);
            return new string(output);
        }
        
        // TODO we don't really want people to provide just one sample, we want batching
        public static void Input_Ingress_Axis1D(Input_Control_Reference controlReference, short sample, Input_Timestamp timestamp)
        {
            var sampleAsFloat = _IntToNormalizedFloat(sample, short.MinValue, short.MaxValue) * 2.0f - 1.0f;
            Input_Ingress_Axis1D(controlReference, &sampleAsFloat, 1, timestamp);
        }
        public static void Input_Ingress_Axis1D(Input_Control_Reference controlReference, byte sample, Input_Timestamp timestamp)
        {
            var sampleAsFloat = _IntToNormalizedFloat(sample, byte.MinValue, byte.MaxValue);
            Input_Ingress_Axis1D(controlReference, &sampleAsFloat, 1, timestamp);
        }
        public static void Input_Ingress_Axis1D(Input_Control_Reference controlReference, float sample, Input_Timestamp timestamp)
        {
            Input_Ingress_Axis1D(controlReference, &sample, 1, timestamp);
        }
        public static void Input_Ingress_Button(Input_Control_Reference controlReference, bool sample, Input_Timestamp timestamp)
        {
            var sampleAsByte = sample ? (byte)1 : (byte)0;
            Input_Ingress_Button(controlReference, &sampleAsByte, 1, timestamp);
        }
        
        private static float _IntToNormalizedFloat(int value, int minValue, int maxValue)
        {
            if (value <= minValue)
                return 0.0f;
            if (value >= maxValue)
                return 1.0f;
            // using double here because int.MaxValue is not representable in floats
            // as int.MaxValue = 2147483647 will become 2147483648.0 when casted to a float
            return (float)(((double)value - minValue) / ((double)maxValue - minValue));
        }

        // TODO not burst friendly 
        public static Input_Control_Reference[] Input_ForEachChangedControl(uint ioFrameId)
        {
            var iterator = new Input_ControlsInstances_Iterator { };

            var r = new List<Input_Control_Reference>();
            while(Input_ForEachChangedControl(ioFrameId, &iterator))
                r.Add(iterator.controlReference);
            return r.ToArray();
        }
        
        // TODO not burst friendly 
        public static Input_Control_Reference[] Input_ForEachChangedButtonControl(uint ioFrameId)
        {
            var iterator = new Input_ControlsInstances_Iterator { };

            var r = new List<Input_Control_Reference>();
            while(Input_ForEachChangedButtonControl(ioFrameId, &iterator))
                r.Add(iterator.controlReference);
            return r.ToArray();
        }
        
        // TODO not burst friendly 
        public static Input_Control_Reference[] Input_ForEachControlMatchingQuery(uint ioFrameId, Input_Control_Query query)
        {
            var iterator = new Input_ControlsInstances_Iterator { };
            var r = new List<Input_Control_Reference>();
            while(Input_ForEachControlMatchingQuery(ioFrameId, &iterator, query))
                r.Add(iterator.controlReference);
            return r.ToArray();
        }

        // TODO not burst friendly 
        public static uint[] Input_Control_GetTypeIdDatabase()
        {
            var count = Input_Control_GetTypeIdDatabase(null, 0);
            var results = new uint[count];
            fixed (uint* resultsPtr = results)
                Input_Control_GetTypeIdDatabase(resultsPtr, count);
            return results;
        }
        
        // TODO not burst friendly 
        public static Input_Control_Usage[] Input_Control_GetUsageDatabase(uint filterByTypeId = 0, uint filterByUsagePage = 0)
        {
            var count = Input_Control_GetUsageDatabase(null, 0, filterByTypeId, filterByUsagePage);
            var results = new Input_Control_Usage[count];
            fixed (Input_Control_Usage* resultsPtr = results)
                Input_Control_GetUsageDatabase(resultsPtr, count, filterByTypeId, filterByUsagePage);
            return results;
        }
    }

    // TODO use roslyn source gen for this
    public partial struct Input_Control_Usage
    {
        public static implicit operator Input_Control_Usage(Input_Control_Usage_GenericButton value) => new()
            { page = (uint)Input_Control_UsagePage_BuiltIn.GenericButtons, value = (uint)value };

        public static implicit operator Input_Control_Usage(Input_Control_Usage_GenericAxis value) => new()
            { page = (uint)Input_Control_UsagePage_BuiltIn.GenericAxes, value = (uint)value };

        public static implicit operator Input_Control_Usage(Input_Control_Usage_Keyboard value) => new()
            { page = (uint)Input_Control_UsagePage_BuiltIn.Keyboard, value = (uint)value };

        public static implicit operator Input_Control_Usage(Input_Control_Usage_Mouse value) => new()
            { page = (uint)Input_Control_UsagePage_BuiltIn.Mouse, value = (uint)value };

        public static implicit operator Input_Control_Usage(Input_Control_Usage_Gamepad value) => new()
            { page = (uint)Input_Control_UsagePage_BuiltIn.Gamepad, value = (uint)value };
    }

    internal unsafe class Input_DynamicArray_DebugView<T> where T : unmanaged
    {
        public T[] Items;
        
        public Input_DynamicArray_DebugView(Input_DynamicArray arr)
        {
            var arrManaged = new T[arr.count];

            var h = GCHandle.Alloc(arrManaged, GCHandleType.Pinned);
            Input_PAL_Memcpy((void*)h.AddrOfPinnedObject(), arr.elements, arr.count * arr.elementSizeInBytes);
            h.Free();

            Items = arrManaged;
        }
    }

    [DebuggerTypeProxy(typeof(Input_Control_Catalog_CSharp_View))]
    public partial struct Input_Control_Catalog
    {
        class Input_Control_Catalog_CSharp_View
        {
            public Input_DynamicArray_DebugView<Input_Control_Instance> controls;
            
            public Input_Control_Catalog_CSharp_View(Input_Control_Catalog catalog)
            {
                controls = new Input_DynamicArray_DebugView<Input_Control_Instance>(catalog.controls);
            }
        }
    }

#endif

    // TODO modify ClangSharp to use this
    internal static class NativeLibrary
    {
#if true // TODO, on platforms where we run Mono/CoreCLR we need to pinvoke into a prebuilt library
        public const string DllName = "RuntimeNext.Native";
#else // on all other platforms we pinvoke into statically linked code
        public const string DllName = "__Internal";
#endif
    }

    // clangsharp attribute
    [Conditional("DEBUG")]
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Struct | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Enum |
        AttributeTargets.ReturnValue, AllowMultiple = false, Inherited = true)]
    internal sealed class NativeTypeNameAttribute : Attribute
    {
        public NativeTypeNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}