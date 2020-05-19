// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controlls"",
    ""maps"": [
        {
            ""name"": ""TrackCreating"",
            ""id"": ""0b7cb0e2-95ab-43ad-a8fe-6b69ca1b0b9d"",
            ""actions"": [
                {
                    ""name"": ""PlaceNode"",
                    ""type"": ""Button"",
                    ""id"": ""39084e4d-dded-4eb1-9e09-c26d0223a663"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8de4b36a-5510-4e9f-95fd-65f43a8b8445"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cursor"",
                    ""type"": ""Value"",
                    ""id"": ""db7bf927-9399-4a93-8ab9-8955cbfad303"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateLeft"",
                    ""type"": ""Button"",
                    ""id"": ""19db7538-316b-43f2-8e46-993b9b347e4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateRight"",
                    ""type"": ""Button"",
                    ""id"": ""66daa3d6-e735-4b1d-9c33-cacbd3cf3844"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Button"",
                    ""id"": ""e2cdcfc6-be38-4c8e-9f24-cf896bb20094"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""09b3b74f-9394-40c0-9788-f7f120791afb"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Temp Reorder"",
                    ""type"": ""Button"",
                    ""id"": ""f10a77df-efd3-486d-905b-932cf0047252"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1116ed16-aba5-44ac-af9d-ea851bf6a4d6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PlaceNode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ccd0ff0d-4536-4914-ae40-a20e02e337f3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""PlaceNode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""8138f098-eb75-4b38-beca-d7c239d830c9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d75d66be-926c-4431-a099-205d072bbbe6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9e2eaf53-2063-443b-8f7b-03cf6b9c021b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""23e4e9ae-5469-4e59-a4f5-e5bb5f61c7aa"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2190d9c9-3305-4f2d-9e8a-0cb2d5534260"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c3c12ee8-f833-4e7f-9bb4-491e50eb9702"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4847f10d-c838-403a-ba42-562e539f62e1"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6e8879f-1e85-42c2-98cc-fa65b35e9135"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8e82c9f-e39c-47a2-a64b-93773b8660cc"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""710c5455-d9c7-4866-ba42-8d8fb4c255da"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c981ec43-c510-4c87-a2c9-b900cc24cbf0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4558e957-dba4-4fec-9ee1-0d71df9a568b"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdbb4bf2-a2c0-4729-a1e4-59543b35a8be"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3145fdf5-ceca-46d9-96c7-b6022c15099b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""b68d3b0b-ef68-4cc7-8392-9d3e0648a07d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1026eb88-3386-42ac-9be8-8c0e7324eea6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2cda1611-d9a7-46ad-9504-490e1a03a400"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""ac05f53d-96a9-4d3b-87d9-f7c4aa9a1e4b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c3485df8-8ee2-48d4-b157-a605e9fb2e0c"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2c840adb-336f-42fc-9c83-d2d5d3850cc8"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""JoyPad"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""438cfa5a-7b11-4301-a5c4-66464a7133c5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Temp Reorder"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""750d37c2-9874-43b1-8926-ab78e81daad1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Temp Reorder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d481d2fc-e231-438d-94e6-4b8bcaa698d2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Temp Reorder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""JoyPad"",
            ""bindingGroup"": ""JoyPad"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // TrackCreating
        m_TrackCreating = asset.FindActionMap("TrackCreating", throwIfNotFound: true);
        m_TrackCreating_PlaceNode = m_TrackCreating.FindAction("PlaceNode", throwIfNotFound: true);
        m_TrackCreating_Move = m_TrackCreating.FindAction("Move", throwIfNotFound: true);
        m_TrackCreating_Cursor = m_TrackCreating.FindAction("Cursor", throwIfNotFound: true);
        m_TrackCreating_RotateLeft = m_TrackCreating.FindAction("RotateLeft", throwIfNotFound: true);
        m_TrackCreating_RotateRight = m_TrackCreating.FindAction("RotateRight", throwIfNotFound: true);
        m_TrackCreating_Drag = m_TrackCreating.FindAction("Drag", throwIfNotFound: true);
        m_TrackCreating_Zoom = m_TrackCreating.FindAction("Zoom", throwIfNotFound: true);
        m_TrackCreating_TempReorder = m_TrackCreating.FindAction("Temp Reorder", throwIfNotFound: true);
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

    // TrackCreating
    private readonly InputActionMap m_TrackCreating;
    private ITrackCreatingActions m_TrackCreatingActionsCallbackInterface;
    private readonly InputAction m_TrackCreating_PlaceNode;
    private readonly InputAction m_TrackCreating_Move;
    private readonly InputAction m_TrackCreating_Cursor;
    private readonly InputAction m_TrackCreating_RotateLeft;
    private readonly InputAction m_TrackCreating_RotateRight;
    private readonly InputAction m_TrackCreating_Drag;
    private readonly InputAction m_TrackCreating_Zoom;
    private readonly InputAction m_TrackCreating_TempReorder;
    public struct TrackCreatingActions
    {
        private @Controlls m_Wrapper;
        public TrackCreatingActions(@Controlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlaceNode => m_Wrapper.m_TrackCreating_PlaceNode;
        public InputAction @Move => m_Wrapper.m_TrackCreating_Move;
        public InputAction @Cursor => m_Wrapper.m_TrackCreating_Cursor;
        public InputAction @RotateLeft => m_Wrapper.m_TrackCreating_RotateLeft;
        public InputAction @RotateRight => m_Wrapper.m_TrackCreating_RotateRight;
        public InputAction @Drag => m_Wrapper.m_TrackCreating_Drag;
        public InputAction @Zoom => m_Wrapper.m_TrackCreating_Zoom;
        public InputAction @TempReorder => m_Wrapper.m_TrackCreating_TempReorder;
        public InputActionMap Get() { return m_Wrapper.m_TrackCreating; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TrackCreatingActions set) { return set.Get(); }
        public void SetCallbacks(ITrackCreatingActions instance)
        {
            if (m_Wrapper.m_TrackCreatingActionsCallbackInterface != null)
            {
                @PlaceNode.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnPlaceNode;
                @PlaceNode.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnPlaceNode;
                @PlaceNode.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnPlaceNode;
                @Move.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnMove;
                @Cursor.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnCursor;
                @Cursor.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnCursor;
                @Cursor.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnCursor;
                @RotateLeft.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnRotateLeft;
                @RotateRight.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnRotateRight;
                @RotateRight.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnRotateRight;
                @RotateRight.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnRotateRight;
                @Drag.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnDrag;
                @Drag.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnDrag;
                @Drag.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnDrag;
                @Zoom.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnZoom;
                @TempReorder.started -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnTempReorder;
                @TempReorder.performed -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnTempReorder;
                @TempReorder.canceled -= m_Wrapper.m_TrackCreatingActionsCallbackInterface.OnTempReorder;
            }
            m_Wrapper.m_TrackCreatingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlaceNode.started += instance.OnPlaceNode;
                @PlaceNode.performed += instance.OnPlaceNode;
                @PlaceNode.canceled += instance.OnPlaceNode;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Cursor.started += instance.OnCursor;
                @Cursor.performed += instance.OnCursor;
                @Cursor.canceled += instance.OnCursor;
                @RotateLeft.started += instance.OnRotateLeft;
                @RotateLeft.performed += instance.OnRotateLeft;
                @RotateLeft.canceled += instance.OnRotateLeft;
                @RotateRight.started += instance.OnRotateRight;
                @RotateRight.performed += instance.OnRotateRight;
                @RotateRight.canceled += instance.OnRotateRight;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @TempReorder.started += instance.OnTempReorder;
                @TempReorder.performed += instance.OnTempReorder;
                @TempReorder.canceled += instance.OnTempReorder;
            }
        }
    }
    public TrackCreatingActions @TrackCreating => new TrackCreatingActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_JoyPadSchemeIndex = -1;
    public InputControlScheme JoyPadScheme
    {
        get
        {
            if (m_JoyPadSchemeIndex == -1) m_JoyPadSchemeIndex = asset.FindControlSchemeIndex("JoyPad");
            return asset.controlSchemes[m_JoyPadSchemeIndex];
        }
    }
    public interface ITrackCreatingActions
    {
        void OnPlaceNode(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnCursor(InputAction.CallbackContext context);
        void OnRotateLeft(InputAction.CallbackContext context);
        void OnRotateRight(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnTempReorder(InputAction.CallbackContext context);
    }
}
