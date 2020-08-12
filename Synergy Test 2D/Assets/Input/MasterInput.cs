// GENERATED AUTOMATICALLY FROM 'Assets/Input/MasterInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MasterInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MasterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MasterInput"",
    ""maps"": [
        {
            ""name"": ""GlobalInput"",
            ""id"": ""70dde54e-bf63-41ba-94b1-53e9fa3a40db"",
            ""actions"": [
                {
                    ""name"": ""PrimaryTouchPos"",
                    ""type"": ""Value"",
                    ""id"": ""e53a8e48-14ed-43e5-ab15-aa1723f23a57"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryTouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""0ce15468-9187-4d73-ae26-1f62d48737e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d74991c0-ec9b-4c4e-8580-ebdbee347864"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouchPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47cca33d-d331-4184-a9ff-c95d18d60f4c"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouchPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7cc27a7-fda2-487c-9dff-3ca72e5701a0"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23b95120-f2f1-4284-93a5-70bd44543197"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GlobalInput
        m_GlobalInput = asset.FindActionMap("GlobalInput", throwIfNotFound: true);
        m_GlobalInput_PrimaryTouchPos = m_GlobalInput.FindAction("PrimaryTouchPos", throwIfNotFound: true);
        m_GlobalInput_PrimaryTouchPress = m_GlobalInput.FindAction("PrimaryTouchPress", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // GlobalInput
    private readonly InputActionMap m_GlobalInput;
    private IGlobalInputActions m_GlobalInputActionsCallbackInterface;
    private readonly InputAction m_GlobalInput_PrimaryTouchPos;
    private readonly InputAction m_GlobalInput_PrimaryTouchPress;
    public struct GlobalInputActions
    {
        private @MasterInput m_Wrapper;
        public GlobalInputActions(@MasterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryTouchPos => m_Wrapper.m_GlobalInput_PrimaryTouchPos;
        public InputAction @PrimaryTouchPress => m_Wrapper.m_GlobalInput_PrimaryTouchPress;
        public InputActionMap Get() { return m_Wrapper.m_GlobalInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GlobalInputActions set) { return set.Get(); }
        public void SetCallbacks(IGlobalInputActions instance)
        {
            if (m_Wrapper.m_GlobalInputActionsCallbackInterface != null)
            {
                @PrimaryTouchPos.started -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnPrimaryTouchPos;
                @PrimaryTouchPos.performed -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnPrimaryTouchPos;
                @PrimaryTouchPos.canceled -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnPrimaryTouchPos;
                @PrimaryTouchPress.started -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnPrimaryTouchPress;
                @PrimaryTouchPress.performed -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnPrimaryTouchPress;
                @PrimaryTouchPress.canceled -= m_Wrapper.m_GlobalInputActionsCallbackInterface.OnPrimaryTouchPress;
            }
            m_Wrapper.m_GlobalInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryTouchPos.started += instance.OnPrimaryTouchPos;
                @PrimaryTouchPos.performed += instance.OnPrimaryTouchPos;
                @PrimaryTouchPos.canceled += instance.OnPrimaryTouchPos;
                @PrimaryTouchPress.started += instance.OnPrimaryTouchPress;
                @PrimaryTouchPress.performed += instance.OnPrimaryTouchPress;
                @PrimaryTouchPress.canceled += instance.OnPrimaryTouchPress;
            }
        }
    }
    public GlobalInputActions @GlobalInput => new GlobalInputActions(this);
    public interface IGlobalInputActions
    {
        void OnPrimaryTouchPos(InputAction.CallbackContext context);
        void OnPrimaryTouchPress(InputAction.CallbackContext context);
    }
}
