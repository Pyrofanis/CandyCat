// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/MainControlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainControlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainControlls"",
    ""maps"": [
        {
            ""name"": ""Controlls"",
            ""id"": ""81b865bf-9bad-4e10-b452-6cda78875783"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""69ef455e-997b-4007-9a24-30290261903a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""872e0546-1ae5-401e-ad18-68acc87810bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Selection"",
                    ""type"": ""Button"",
                    ""id"": ""73abe305-63b1-40a2-b33e-0cbaeec956ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""f06c38ac-9d1a-4cf2-9666-c6a2f7971a38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""44afead9-2249-4138-a05d-080f9cc7c47b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""7ae0cd08-3f63-48c5-813a-c1d31d52cc6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f0f0f959-a89a-413e-b8c2-2587b3ea4c94"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MainControllScheamsAllPlatforms"",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bd230c3-a231-4e79-9c5f-f4ece9bb8f5c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MainControllScheamsAllPlatforms"",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2a0eae4-8ec9-4de0-8f5f-6e673cc9e595"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MainControllScheamsAllPlatforms"",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74517615-839c-41e1-8e70-23ad5510b4e3"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MainControllScheamsAllPlatforms"",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adfa0b16-4378-4af4-b0bc-0b40a7a669de"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MainControllScheamsAllPlatforms"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b24c6ca-5662-4741-9432-9dc4405d4824"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MainControllScheamsAllPlatforms"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f22723c-e62c-47fc-a9ef-84d0759a53d6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MainControllScheamsAllPlatforms"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""563c23fa-1335-4956-9d69-6e441ec5e559"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MainControllScheamsAllPlatforms"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec90f6b3-8878-4307-b94f-a3f60d3ce320"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MainControllScheamsAllPlatforms"",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6555ec4-d7a8-421f-b24e-7eb5c66368f4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MainControllScheamsAllPlatforms"",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08122fb5-42cf-4c0c-b339-24c7c2e5da17"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MainControllScheamsAllPlatforms"",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff0345e9-09e1-4b04-b3f8-5ee46f851d43"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MainControllScheamsAllPlatforms"",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8d0fb91-a0cf-4a55-a7e2-a4489fed0a4f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ebb26fe-2bcb-4726-89cb-e3a0db1fb629"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ba3702f-a740-4713-9675-f3644ff27e31"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d72a382-2ed8-463f-b86c-1803c63a3bf3"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4ea4d5e-67bd-41c1-a133-77bf2076226c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb34bd1f-81ff-4f76-b871-b05a45ff129a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71b21a6c-2fcc-4843-b5c6-acd52bdfabb0"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72bafac4-3e32-4bf3-ae67-1e105baa7b5d"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MainControllScheamsAllPlatforms"",
            ""bindingGroup"": ""MainControllScheamsAllPlatforms"",
            ""devices"": []
        }
    ]
}");
        // Controlls
        m_Controlls = asset.FindActionMap("Controlls", throwIfNotFound: true);
        m_Controlls_MoveLeft = m_Controlls.FindAction("MoveLeft", throwIfNotFound: true);
        m_Controlls_MoveRight = m_Controlls.FindAction("MoveRight", throwIfNotFound: true);
        m_Controlls_Selection = m_Controlls.FindAction("Selection", throwIfNotFound: true);
        m_Controlls_Escape = m_Controlls.FindAction("Escape", throwIfNotFound: true);
        m_Controlls_MoveUp = m_Controlls.FindAction("MoveUp", throwIfNotFound: true);
        m_Controlls_MoveDown = m_Controlls.FindAction("MoveDown", throwIfNotFound: true);
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

    // Controlls
    private readonly InputActionMap m_Controlls;
    private IControllsActions m_ControllsActionsCallbackInterface;
    private readonly InputAction m_Controlls_MoveLeft;
    private readonly InputAction m_Controlls_MoveRight;
    private readonly InputAction m_Controlls_Selection;
    private readonly InputAction m_Controlls_Escape;
    private readonly InputAction m_Controlls_MoveUp;
    private readonly InputAction m_Controlls_MoveDown;
    public struct ControllsActions
    {
        private @MainControlls m_Wrapper;
        public ControllsActions(@MainControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveLeft => m_Wrapper.m_Controlls_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_Controlls_MoveRight;
        public InputAction @Selection => m_Wrapper.m_Controlls_Selection;
        public InputAction @Escape => m_Wrapper.m_Controlls_Escape;
        public InputAction @MoveUp => m_Wrapper.m_Controlls_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_Controlls_MoveDown;
        public InputActionMap Get() { return m_Wrapper.m_Controlls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllsActions set) { return set.Get(); }
        public void SetCallbacks(IControllsActions instance)
        {
            if (m_Wrapper.m_ControllsActionsCallbackInterface != null)
            {
                @MoveLeft.started -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMoveRight;
                @Selection.started -= m_Wrapper.m_ControllsActionsCallbackInterface.OnSelection;
                @Selection.performed -= m_Wrapper.m_ControllsActionsCallbackInterface.OnSelection;
                @Selection.canceled -= m_Wrapper.m_ControllsActionsCallbackInterface.OnSelection;
                @Escape.started -= m_Wrapper.m_ControllsActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_ControllsActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_ControllsActionsCallbackInterface.OnEscape;
                @MoveUp.started -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMoveUp;
                @MoveUp.performed -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMoveUp;
                @MoveUp.canceled -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMoveUp;
                @MoveDown.started -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMoveDown;
                @MoveDown.performed -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMoveDown;
                @MoveDown.canceled -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMoveDown;
            }
            m_Wrapper.m_ControllsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @Selection.started += instance.OnSelection;
                @Selection.performed += instance.OnSelection;
                @Selection.canceled += instance.OnSelection;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
                @MoveUp.started += instance.OnMoveUp;
                @MoveUp.performed += instance.OnMoveUp;
                @MoveUp.canceled += instance.OnMoveUp;
                @MoveDown.started += instance.OnMoveDown;
                @MoveDown.performed += instance.OnMoveDown;
                @MoveDown.canceled += instance.OnMoveDown;
            }
        }
    }
    public ControllsActions @Controlls => new ControllsActions(this);
    private int m_MainControllScheamsAllPlatformsSchemeIndex = -1;
    public InputControlScheme MainControllScheamsAllPlatformsScheme
    {
        get
        {
            if (m_MainControllScheamsAllPlatformsSchemeIndex == -1) m_MainControllScheamsAllPlatformsSchemeIndex = asset.FindControlSchemeIndex("MainControllScheamsAllPlatforms");
            return asset.controlSchemes[m_MainControllScheamsAllPlatformsSchemeIndex];
        }
    }
    public interface IControllsActions
    {
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnSelection(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
    }
}
