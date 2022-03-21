// DO NOT EDIT
// This file is autogenerated from C++ sources

using static Unity.InputSystem.Runtime.Native;

using System.Runtime.InteropServices;

namespace Unity.InputSystem.Runtime
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct InputAxisOneWayControlSample
    {
        public float value;

        public bool Equals([NativeTypeName("const InputAxisOneWayControlSample")] InputAxisOneWayControlSample o)
        {
            return value == o.value;
        }
    }

    public partial struct InputAxisOneWayControlState
    {
        [NativeTypeName("uint8_t")]
        public byte _reserved;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct InputAxisTwoWayControlSample
    {
        public float value;

        public bool Equals([NativeTypeName("const InputAxisTwoWayControlSample")] InputAxisTwoWayControlSample o)
        {
            return value == o.value;
        }
    }

    public partial struct InputAxisTwoWayControlState
    {
        [NativeTypeName("uint8_t")]
        public byte _reserved;
    }

    public partial struct InputButtonControlSample
    {
        [NativeTypeName("uint8_t")]
        public byte value;

        public bool IsPressed()
        {
            return value == 1;
        }

        public bool IsReleased()
        {
            return value == 0;
        }

        public bool Equals([NativeTypeName("const InputButtonControlSample")] InputButtonControlSample o)
        {
            return value == o.value;
        }

        public bool NotEquals([NativeTypeName("const InputButtonControlSample")] InputButtonControlSample o)
        {
            return value != o.value;
        }
    }

    public partial struct InputButtonControlState
    {
        public bool wasPressedThisIOFrame;

        public bool wasReleasedThisIOFrame;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct InputDeltaAxisTwoWayControlSample
    {
        public float value;
    }

    public partial struct InputDeltaAxisTwoWayControlState
    {
        [NativeTypeName("uint8_t")]
        public byte _reserved;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct InputDeltaVector2DControlSample
    {
        public float x;

        public float y;
    }

    public partial struct InputDeltaVector2DControlState
    {
        [NativeTypeName("uint8_t")]
        public byte _reserved;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct InputStickControlSample
    {
        public float x;

        public float y;
    }

    public partial struct InputStickControlState
    {
        [NativeTypeName("uint8_t")]
        public byte _reserved;
    }

    public partial struct InputControlTypeRef
    {
        [NativeTypeName("uint32_t")]
        public uint transparent;

        public bool Equals([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef o)
        {
            return transparent == o.transparent;
        }

        public bool NotEquals([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef o)
        {
            return transparent != o.transparent;
        }
    }

    public partial struct InputControlUsage
    {
        [NativeTypeName("uint32_t")]
        public uint transparent;

        public bool Equals([NativeTypeName("const InputControlUsage")] InputControlUsage o)
        {
            return transparent == o.transparent;
        }

        public bool NotEquals([NativeTypeName("const InputControlUsage")] InputControlUsage o)
        {
            return transparent != o.transparent;
        }
    }

    public unsafe partial struct InputControlDescr
    {
        [NativeTypeName("char [256]")]
        public fixed sbyte displayName[256];
    }

    public enum InputControlRecordingMode
    {
        Disabled,
        LatestOnly,
        AllMerged,
        AllAsIs,
    }

    public partial struct InputControlRef
    {
        public InputControlUsage usage;

        public InputDeviceRef deviceRef;

        public static InputControlRef Setup([NativeTypeName("const InputControlUsage")] InputControlUsage usage, [NativeTypeName("const InputDeviceRef")] InputDeviceRef deviceRef)
        {
            return new InputControlRef
            {
                usage = usage,
                deviceRef = deviceRef,
            };
        }

        public bool Equals([NativeTypeName("const InputControlRef")] InputControlRef o)
        {
            return usage.Equals(o.usage) && deviceRef.Equals(o.deviceRef);
        }

        public bool NotEquals([NativeTypeName("const InputControlRef")] InputControlRef o)
        {
            return !(usage.Equals(o.usage) && deviceRef.Equals(o.deviceRef));
        }
    }

    public partial struct InputControlTimestamp
    {
        [NativeTypeName("uint64_t")]
        public ulong timestamp;

        [NativeTypeName("uint16_t")]
        public ushort timeline;

        public bool Equals([NativeTypeName("const InputControlTimestamp")] InputControlTimestamp o)
        {
            return timestamp == o.timestamp && timeline == o.timeline;
        }

        public bool NotEquals([NativeTypeName("const InputControlTimestamp")] InputControlTimestamp o)
        {
            return !(timestamp == o.timestamp && timeline == o.timeline);
        }
    }

    public unsafe partial struct InputControlVisitorGenericState
    {
        public void* controlState;

        public InputControlTimestamp* latestRecordedTimestamp;

        public void* latestRecordedSample;
    }

    public unsafe partial struct InputControlVisitorGenericRecordings
    {
        public InputControlTimestamp* allRecordedTimestamps;

        public void* allRecordedSamples;

        [NativeTypeName("uint32_t")]
        public uint allRecordedCount;
    }

    public partial struct InputDatabaseDeviceAssignedRef
    {
        [NativeTypeName("uint32_t")]
        public uint _opaque;

        public bool Equals([NativeTypeName("const InputDatabaseDeviceAssignedRef")] InputDatabaseDeviceAssignedRef o)
        {
            return _opaque == o._opaque;
        }
    }

    public partial struct InputDatabaseControlUsageDescr
    {
        public InputControlTypeRef controlTypeRef;

        public InputControlRecordingMode defaultRecordingMode;

        public InputControlUsage parentOfVirtualControl;
    }

    public partial struct InputDatabaseControlTypeDescr
    {
        [NativeTypeName("uint32_t")]
        public uint stateSizeInBytes;

        [NativeTypeName("uint32_t")]
        public uint sampleSizeInBytes;
    }

    public unsafe partial struct InputDeviceDatabaseCallbacks
    {
        [NativeTypeName("void (*)(const InputControlTypeRef, const InputControlRef, const InputControlTypeRef, const InputControlTimestamp *, const void *, const uint32_t, const InputControlRef)")]
        public delegate* unmanaged[Cdecl]<InputControlTypeRef, InputControlRef, InputControlTypeRef, InputControlTimestamp*, void*, uint, InputControlRef, void> ControlTypeIngress;

        [NativeTypeName("void (*)(const InputControlTypeRef, const InputControlRef *, void *, InputControlTimestamp *, void *, const uint32_t)")]
        public delegate* unmanaged[Cdecl]<InputControlTypeRef, InputControlRef*, void*, InputControlTimestamp*, void*, uint, void> ControlTypeFrameBegin;

        [NativeTypeName("uint32_t (*)(const InputDatabaseDeviceAssignedRef, InputDeviceTraitRef *, const uint32_t)")]
        public delegate* unmanaged[Cdecl]<InputDatabaseDeviceAssignedRef, InputDeviceTraitRef*, uint, uint> GetDeviceTraits;

        [NativeTypeName("uint32_t (*)(const InputDeviceTraitRef)")]
        public delegate* unmanaged[Cdecl]<InputDeviceTraitRef, uint> GetTraitSizeInBytes;

        [NativeTypeName("uint32_t (*)(const InputDeviceTraitRef, const InputDeviceRef, InputControlRef *, const uint32_t)")]
        public delegate* unmanaged[Cdecl]<InputDeviceTraitRef, InputDeviceRef, InputControlRef*, uint, uint> GetTraitControls;

        [NativeTypeName("void (*)(const InputDeviceTraitRef, void *, const InputDeviceRef)")]
        public delegate* unmanaged[Cdecl]<InputDeviceTraitRef, void*, InputDeviceRef, void> ConfigureTraitInstance;

        [NativeTypeName("InputDatabaseControlUsageDescr (*)(const InputControlUsage)")]
        public delegate* unmanaged[Cdecl]<InputControlUsage, InputDatabaseControlUsageDescr> GetControlUsageDescr;

        [NativeTypeName("InputDatabaseControlTypeDescr (*)(const InputControlTypeRef)")]
        public delegate* unmanaged[Cdecl]<InputControlTypeRef, InputDatabaseControlTypeDescr> GetControlTypeDescr;

        [NativeTypeName("InputDatabaseDeviceAssignedRef (*)(const InputGuid)")]
        public delegate* unmanaged[Cdecl]<InputGuid, InputDatabaseDeviceAssignedRef> GetDeviceAssignedRef;

        [NativeTypeName("InputDeviceTraitRef (*)(const InputGuid)")]
        public delegate* unmanaged[Cdecl]<InputGuid, InputDeviceTraitRef> GetTraitAssignedRef;

        [NativeTypeName("InputControlUsage (*)(const InputGuid)")]
        public delegate* unmanaged[Cdecl]<InputGuid, InputControlUsage> GetControlUsage;

        [NativeTypeName("InputControlTypeRef (*)(const InputGuid)")]
        public delegate* unmanaged[Cdecl]<InputGuid, InputControlTypeRef> GetControlTypeRef;

        [NativeTypeName("InputGuid (*)(const InputDatabaseDeviceAssignedRef)")]
        public delegate* unmanaged[Cdecl]<InputDatabaseDeviceAssignedRef, InputGuid> GetDeviceGuid;

        [NativeTypeName("InputGuid (*)(const InputDeviceTraitRef)")]
        public delegate* unmanaged[Cdecl]<InputDeviceTraitRef, InputGuid> GetTraitGuid;

        [NativeTypeName("InputGuid (*)(const InputControlUsage)")]
        public delegate* unmanaged[Cdecl]<InputControlUsage, InputGuid> GetControlGuid;

        [NativeTypeName("InputGuid (*)(const InputControlTypeRef)")]
        public delegate* unmanaged[Cdecl]<InputControlTypeRef, InputGuid> GetControlTypeGuid;

        [NativeTypeName("uint32_t (*)()")]
        public delegate* unmanaged[Cdecl]<uint> GetDeviceRefCount;

        [NativeTypeName("uint32_t (*)()")]
        public delegate* unmanaged[Cdecl]<uint> GetTraitRefCount;

        [NativeTypeName("uint32_t (*)()")]
        public delegate* unmanaged[Cdecl]<uint> GetControlUsageCount;

        [NativeTypeName("uint32_t (*)()")]
        public delegate* unmanaged[Cdecl]<uint> GetControlTypeCount;

        [NativeTypeName("uint32_t (*)(const InputDatabaseDeviceAssignedRef, char *, const uint32_t)")]
        public delegate* unmanaged[Cdecl]<InputDatabaseDeviceAssignedRef, sbyte*, uint, uint> GetDeviceName;

        [NativeTypeName("uint32_t (*)(const InputDeviceTraitRef, char *, const uint32_t)")]
        public delegate* unmanaged[Cdecl]<InputDeviceTraitRef, sbyte*, uint, uint> GetTraitName;

        [NativeTypeName("uint32_t (*)(const InputControlUsage, char *, const uint32_t)")]
        public delegate* unmanaged[Cdecl]<InputControlUsage, sbyte*, uint, uint> GetControlFullName;

        [NativeTypeName("uint32_t (*)(const InputControlTypeRef, char *, const uint32_t)")]
        public delegate* unmanaged[Cdecl]<InputControlTypeRef, sbyte*, uint, uint> GetControlTypeName;
    }

    public partial struct InputDeviceRef
    {
        [NativeTypeName("uint32_t")]
        public uint _opaque;

        public bool Equals([NativeTypeName("const InputDeviceRef")] InputDeviceRef o)
        {
            return _opaque == o._opaque;
        }
    }

    public unsafe partial struct InputDevicePersistentIdentifier
    {
        [NativeTypeName("uint8_t [512]")]
        public fixed byte persistentId[512];
    }

    public unsafe partial struct InputDeviceDescr
    {
        public InputGuid guid;

        public InputDevicePersistentIdentifier persistentIdentifier;

        [NativeTypeName("char [256]")]
        public fixed sbyte displayName[256];
    }

    public partial struct InputDeviceTraitRef
    {
        [NativeTypeName("uint32_t")]
        public uint transparent;

        public bool Equals([NativeTypeName("const InputDeviceTraitRef")] InputDeviceTraitRef o)
        {
            return transparent == o.transparent;
        }
    }

    public unsafe partial struct InputFramebufferRef
    {
        [NativeTypeName("uint32_t")]
        public uint transparent;

        public bool Equals([NativeTypeName("const InputFramebufferRef &")] InputFramebufferRef* o)
        {
            return transparent == o->transparent;
        }
    }

    public partial struct InputGuid
    {
        [NativeTypeName("uint64_t")]
        public ulong a;

        [NativeTypeName("uint64_t")]
        public ulong b;
    }

    public unsafe partial struct InputPALCallbacks
    {
        [NativeTypeName("void (*)(const char *)")]
        public delegate* unmanaged[Cdecl]<sbyte*, void> Log;

        [NativeTypeName("void (*)()")]
        public delegate* unmanaged[Cdecl]<void> DebugTrap;
    }

    public partial struct InputQueryDescr
    {
        public InputControlTypeRef requiredType;

        public InputControlUsage requiredUsage;

        public InputDeviceRef deviceSessionId;

        [NativeTypeName("InputQueryDescr::ChangedQueryMode")]
        public ChangedQueryMode changed;

        [NativeTypeName("InputQueryDescr::ButtonQueryMode")]
        public ButtonQueryMode _button;

        public enum ChangedQueryMode
        {
            Any,
            OnlyChanged,
            OnlyNotChanged,
        }

        public enum ButtonQueryMode
        {
            Any,
            OnlyWasPressed,
            OnlyWasReleased,
        }
    }

    public partial struct InputQueryRef
    {
        [NativeTypeName("uint32_t")]
        public uint _opaque;
    }

    public unsafe partial struct InputControlsLinkedList
    {
        [NativeTypeName("const InputControlRef")]
        public InputControlRef controlRef;

        [NativeTypeName("const InputControlsLinkedList *")]
        public InputControlsLinkedList* next;
    }

    public static unsafe partial class Native
    {
        public static void _TodoIngress([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef")] InputControlRef controlRef, [NativeTypeName("const InputControlTypeRef")] InputControlTypeRef samplesType, [NativeTypeName("const InputControlTimestamp *")] InputControlTimestamp* timestamps, [NativeTypeName("const void *")] void* samples, [NativeTypeName("const uint32_t")] uint count, [NativeTypeName("const InputControlRef")] InputControlRef fromAnotherControl)
        {
        }

        public static void _TodoFrameBegin([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef *")] InputControlRef* controlRefs, [NativeTypeName("uint8_t *")] byte* controlStates, InputControlTimestamp* timestamps, [NativeTypeName("uint8_t *")] byte* samples, [NativeTypeName("const uint32_t")] uint controlCount)
        {
        }

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputRuntimeInit([NativeTypeName("const uint32_t")] uint ioFramesCount);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputRuntimeDeinit();

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputSwapFramebuffer([NativeTypeName("const InputFramebufferRef")] InputFramebufferRef framebufferRef);

        [NativeTypeName("const InputAxisOneWayControlSample")]
        public static readonly InputAxisOneWayControlSample InputAxisOneWayControlSampleDefault = new InputAxisOneWayControlSample
        {
            value = 0.0f,
        };

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputAxisOneWayControlIngress([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef")] InputControlRef controlRef, [NativeTypeName("const InputControlTypeRef")] InputControlTypeRef samplesTypeRef, [NativeTypeName("const InputControlTimestamp *")] InputControlTimestamp* timestamps, [NativeTypeName("const void *")] void* samples, [NativeTypeName("const uint32_t")] uint count, [NativeTypeName("const InputControlRef")] InputControlRef fromAnotherControl);

        public static void InputAxisOneWayFrameBegin([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef *")] InputControlRef* controlRefs, InputAxisOneWayControlState* controlStates, InputControlTimestamp* latestRecordedTimestamps, InputAxisOneWayControlSample* latestRecordedSamples, [NativeTypeName("const uint32_t")] uint controlStatesCount)
        {
        }

        [NativeTypeName("const InputAxisTwoWayControlSample")]
        public static readonly InputAxisTwoWayControlSample InputAxisTwoWayControlSampleDefault = new InputAxisTwoWayControlSample
        {
            value = 0.0f,
        };

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputAxisTwoWayControlIngress([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef")] InputControlRef controlRef, [NativeTypeName("const InputControlTypeRef")] InputControlTypeRef samplesTypeRef, [NativeTypeName("const InputControlTimestamp *")] InputControlTimestamp* timestamps, [NativeTypeName("const void *")] void* samples, [NativeTypeName("const uint32_t")] uint count, [NativeTypeName("const InputControlRef")] InputControlRef fromAnotherControl);

        public static void InputAxisTwoWayFrameBegin([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef *")] InputControlRef* controlRefs, InputAxisTwoWayControlState* controlStates, InputControlTimestamp* latestRecordedTimestamps, InputAxisTwoWayControlSample* latestRecordedSamples, [NativeTypeName("const uint32_t")] uint controlStatesCount)
        {
        }

        [NativeTypeName("const InputButtonControlSample")]
        public static readonly InputButtonControlSample InputButtonControlSampleDefault = new InputButtonControlSample
        {
            value = 0,
        };

        [NativeTypeName("const InputButtonControlSample")]
        public static readonly InputButtonControlSample InputButtonControlSamplePressed = new InputButtonControlSample
        {
            value = 1,
        };

        [NativeTypeName("const InputButtonControlSample")]
        public static readonly InputButtonControlSample InputButtonControlSampleReleased = new InputButtonControlSample
        {
            value = 0,
        };

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputButtonControlIngress([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef")] InputControlRef controlRef, [NativeTypeName("const InputControlTypeRef")] InputControlTypeRef samplesTypeRef, [NativeTypeName("const InputControlTimestamp *")] InputControlTimestamp* timestamps, [NativeTypeName("const void *")] void* samples, [NativeTypeName("const uint32_t")] uint count, [NativeTypeName("const InputControlRef")] InputControlRef fromAnotherControl);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputButtonControlFrameBegin([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef *")] InputControlRef* controlRefs, InputButtonControlState* controlStates, InputControlTimestamp* latestRecordedTimestamps, InputButtonControlSample* latestRecordedSamples, [NativeTypeName("const uint32_t")] uint controlStatesCount);

        [NativeTypeName("const InputDeltaAxisTwoWayControlSample")]
        public static readonly InputDeltaAxisTwoWayControlSample InputDeltaAxisTwoWayControlSampleDefault = new InputDeltaAxisTwoWayControlSample
        {
            value = 0.0f,
        };

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputDeltaAxisTwoWayControlIngress([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef")] InputControlRef controlRef, [NativeTypeName("const InputControlTypeRef")] InputControlTypeRef samplesTypeRef, [NativeTypeName("const InputControlTimestamp *")] InputControlTimestamp* timestamps, [NativeTypeName("const void *")] void* samples, [NativeTypeName("const uint32_t")] uint count, [NativeTypeName("const InputControlRef")] InputControlRef fromAnotherControl);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputDeltaAxisTwoWayFrameBegin([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef *")] InputControlRef* controlRefs, InputDeltaAxisTwoWayControlState* controlStates, InputControlTimestamp* latestRecordedTimestamps, InputDeltaAxisTwoWayControlSample* latestRecordedSamples, [NativeTypeName("const uint32_t")] uint controlStatesCount);

        [NativeTypeName("const InputDeltaVector2DControlSample")]
        public static readonly InputDeltaVector2DControlSample InputDeltaVector2DControlSampleDefault = new InputDeltaVector2DControlSample
        {
            x = 0.0f,
            y = 0.0f,
        };

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputDeltaVector2DControlIngress([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef")] InputControlRef controlRef, [NativeTypeName("const InputControlTypeRef")] InputControlTypeRef samplesTypeRef, [NativeTypeName("const InputControlTimestamp *")] InputControlTimestamp* timestamps, [NativeTypeName("const void *")] void* samples, [NativeTypeName("const uint32_t")] uint count, [NativeTypeName("const InputControlRef")] InputControlRef fromAnotherControl);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputDeltaVector2DFrameBegin([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef *")] InputControlRef* controlRefs, InputDeltaVector2DControlState* controlStates, InputControlTimestamp* latestRecordedTimestamps, InputDeltaVector2DControlSample* latestRecordedSamples, [NativeTypeName("const uint32_t")] uint controlStatesCount);

        [NativeTypeName("const InputStickControlSample")]
        public static readonly InputStickControlSample InputStickControlSampleDefault = new InputStickControlSample
        {
            x = 0.0f,
            y = 0.0f,
        };

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputStickControlIngress([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef")] InputControlRef controlRef, [NativeTypeName("const InputControlTypeRef")] InputControlTypeRef samplesTypeRef, [NativeTypeName("const InputControlTimestamp *")] InputControlTimestamp* timestamps, [NativeTypeName("const void *")] void* samples, [NativeTypeName("const uint32_t")] uint count, [NativeTypeName("const InputControlRef")] InputControlRef fromAnotherControl);

        public static void InputStickFrameBegin([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef *")] InputControlRef* controlRefs, InputStickControlState* controlStates, InputControlTimestamp* latestRecordedTimestamps, InputStickControlSample* latestRecordedSamples, [NativeTypeName("const uint32_t")] uint controlStatesCount)
        {
        }

        [NativeTypeName("const InputControlTypeRef")]
        public static readonly InputControlTypeRef InputControlTypeRefInvalid = new InputControlTypeRef
        {
            transparent = 0,
        };

        public static InputControlUsage InputControlGetVirtualControlUsage([NativeTypeName("const InputControlUsage")] InputControlUsage parentControl, [NativeTypeName("const uint32_t")] uint virtualControlOffset)
        {
            return new InputControlUsage
            {
                transparent = parentControl.transparent + virtualControlOffset,
            };
        }

        [NativeTypeName("const InputControlUsage")]
        public static readonly InputControlUsage InputControlUsageInvalid = new InputControlUsage
        {
            transparent = 0,
        };

        [NativeTypeName("const InputControlRef")]
        public static readonly InputControlRef InputControlRefInvalid = new InputControlRef
        {
            usage = InputControlUsageInvalid,
            deviceRef = InputDeviceRefInvalid,
        };

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputInstantiateControlsInternal([NativeTypeName("const InputControlRef *")] InputControlRef* controlRefs, [NativeTypeName("const uint32_t")] uint controlRefsCount);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputRemoveControlsInternal([NativeTypeName("const InputControlRef *")] InputControlRef* controlRefs, [NativeTypeName("const uint32_t")] uint controlRefsCount);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputSetControlDescr([NativeTypeName("const InputControlRef")] InputControlRef controlRef, [NativeTypeName("const InputControlDescr")] InputControlDescr descr);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte InputGetControlDescr([NativeTypeName("const InputControlRef")] InputControlRef controlRef, [NativeTypeName("const InputFramebufferRef")] InputFramebufferRef framebufferRef, InputControlDescr* outDescr);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputSetRecordingMode([NativeTypeName("const InputControlRef")] InputControlRef controlRef, [NativeTypeName("const InputControlRecordingMode")] InputControlRecordingMode recordingMode);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern InputControlRecordingMode InputGetRecordingMode([NativeTypeName("const InputControlRef")] InputControlRef controlRef);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputForceSyncControlInFrontbufferWithBackbuffer([NativeTypeName("const InputControlRef")] InputControlRef controlRef, [NativeTypeName("const InputFramebufferRef")] InputFramebufferRef framebufferRef);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputGetControlVisitorGenericState([NativeTypeName("const InputControlRef")] InputControlRef controlRef, [NativeTypeName("const InputFramebufferRef")] InputFramebufferRef framebufferRef, InputControlVisitorGenericState* outVisitor);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputGetControlVisitorGenericRecordings([NativeTypeName("const InputControlRef")] InputControlRef controlRef, [NativeTypeName("const InputFramebufferRef")] InputFramebufferRef framebufferRef, InputControlVisitorGenericRecordings* outVisitor);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputGetCurrentTime(InputControlTimestamp* outTimestamp);

        [NativeTypeName("const InputDatabaseDeviceAssignedRef")]
        public static readonly InputDatabaseDeviceAssignedRef InputDatabaseDeviceAssignedRefInvalid = new InputDatabaseDeviceAssignedRef
        {
            _opaque = 0,
        };

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputDatabaseSetCallbacks(InputDeviceDatabaseCallbacks callbacks);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern InputDeviceDatabaseCallbacks* _InputDatabaseGetCallbacks();

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern InputDatabaseControlUsageDescr InputGetControlUsageDescr([NativeTypeName("const InputControlUsage")] InputControlUsage usage);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern InputDatabaseControlTypeDescr InputGetControlTypeDescr([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern InputDeviceRef InputInstantiateDevice([NativeTypeName("const InputGuid")] InputGuid guid, [NativeTypeName("const InputDevicePersistentIdentifier")] InputDevicePersistentIdentifier identifier);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _InputDatabaseControlIngress([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef")] InputControlRef controlRef, [NativeTypeName("const InputControlTypeRef")] InputControlTypeRef samplesType, [NativeTypeName("const InputControlTimestamp *")] InputControlTimestamp* timestamps, [NativeTypeName("const void *")] void* samples, [NativeTypeName("const uint32_t")] uint count, [NativeTypeName("const InputControlRef")] InputControlRef fromAnotherControl);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _InputDatabaseControlTypeFrameBegin([NativeTypeName("const InputControlTypeRef")] InputControlTypeRef controlTypeRef, [NativeTypeName("const InputControlRef *")] InputControlRef* controlRefs, void* controlStates, InputControlTimestamp* latestRecordedTimestamps, void* latestRecordedSamples, [NativeTypeName("const uint32_t")] uint controlCount);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _InputDatabaseInitializeControlStorageSpace();

        [NativeTypeName("const InputDeviceRef")]
        public static readonly InputDeviceRef InputDeviceRefInvalid = new InputDeviceRef
        {
            _opaque = 0,
        };

        [NativeTypeName("const InputDeviceTraitRef")]
        public static readonly InputDeviceTraitRef InputDeviceTraitRefInvalid = new InputDeviceTraitRef
        {
            transparent = 0,
        };

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern InputDeviceRef InputInstantiateDeviceInternal([NativeTypeName("const InputDeviceDescr")] InputDeviceDescr descr, [NativeTypeName("const InputDeviceTraitRef *")] InputDeviceTraitRef* traits, [NativeTypeName("const uint32_t *")] uint* traitSizesInBytes, [NativeTypeName("const uint32_t")] uint traitsCount);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputRemoveDevice([NativeTypeName("const InputDeviceRef")] InputDeviceRef deviceRef);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* InputGetDeviceTrait([NativeTypeName("const InputDeviceRef")] InputDeviceRef deviceRef, [NativeTypeName("const InputDeviceTraitRef")] InputDeviceTraitRef traitRef);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("bool")]
        public static extern byte InputGetDeviceDescr([NativeTypeName("const InputDeviceRef")] InputDeviceRef deviceRef, InputDeviceDescr* outDescr);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern InputDeviceRef InputFindDeviceForPersistentId([NativeTypeName("const InputDevicePersistentIdentifier")] InputDevicePersistentIdentifier devicePersistentIdentifier);

        [NativeTypeName("const InputGuid")]
        public static readonly InputGuid InputGuidInvalid = new InputGuid
        {
            a = 0,
            b = 0,
        };

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern InputGuid InputGuidFromString([NativeTypeName("const char *")] sbyte* guid);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputGuidToString([NativeTypeName("const InputGuid")] InputGuid guid, [NativeTypeName("char *")] sbyte* buffer, [NativeTypeName("const uint32_t")] uint bufferSize);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputSetPALCallbacks([NativeTypeName("const InputPALCallbacks")] InputPALCallbacks callbacks);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern InputQueryRef InputRegisterQuery([NativeTypeName("const InputFramebufferRef")] InputFramebufferRef framebufferRef, [NativeTypeName("const InputQueryDescr")] InputQueryDescr queryDescr);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputRemoveQuery([NativeTypeName("const InputQueryRef")] InputQueryRef queryRef);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const InputControlsLinkedList *")]
        public static extern InputControlsLinkedList* InputGetQueryResult([NativeTypeName("const InputQueryRef")] InputQueryRef queryRef);

        [DllImport("InputNative", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void InputRuntimeRunNativeTests();
    }
}