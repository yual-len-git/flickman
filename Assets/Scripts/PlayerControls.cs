//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Scripts/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Walk"",
            ""id"": ""35bc4fa9-7181-40ea-b0eb-f90889e9656d"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""732cd600-1755-493e-a3d0-521b36979e51"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Viewfinder"",
                    ""type"": ""Button"",
                    ""id"": ""6b014518-6812-4055-b22e-60f060736fad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""abd49924-ede3-4002-86c1-70284b96616b"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""059ee7d7-a3dc-403c-b3aa-d8911e0b8275"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Photograph"",
                    ""type"": ""Button"",
                    ""id"": ""74d0aaa8-d69b-43f6-877a-9eef3495b23b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Button"",
                    ""id"": ""2cb59a3c-6ca8-4837-8083-37c79b362da1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Buy"",
                    ""type"": ""Button"",
                    ""id"": ""d4500713-95d9-436a-bab5-e4b2726c06bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""1cc31327-8938-4d74-b90b-26e85d2a6374"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f17d46a7-471f-47b9-8f02-d09f4eb474b9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df8055dd-99de-47c4-a908-89238aed4652"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Viewfinder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec8e0f1b-6987-4f7c-8ef0-34af566c9b93"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Viewfinder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e57012c-d0a8-4254-b565-d3012d9c3291"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e341feea-3fe5-4786-8a26-5c27b617988b"",
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
                    ""id"": ""3b9ce8ba-3566-4bcf-9929-69d687f0ea7f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""acadcbfc-6752-4b5a-a367-c033cd24de2b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0d23ddb5-604f-4ef4-ba5a-81198e190604"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c8e36800-0bee-408a-acf9-5aff820d7428"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""087ca748-44e4-4121-90b8-7b9c5b765319"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Photograph"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e1e5dc1-b1be-402c-a1fc-2111fed34e1d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73debaaf-d3c2-4a01-8927-b878f9585008"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Buy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56dd2434-001d-4782-8a98-c7c840095207"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Walk
        m_Walk = asset.FindActionMap("Walk", throwIfNotFound: true);
        m_Walk_Jump = m_Walk.FindAction("Jump", throwIfNotFound: true);
        m_Walk_Viewfinder = m_Walk.FindAction("Viewfinder", throwIfNotFound: true);
        m_Walk_Move = m_Walk.FindAction("Move", throwIfNotFound: true);
        m_Walk_Look = m_Walk.FindAction("Look", throwIfNotFound: true);
        m_Walk_Photograph = m_Walk.FindAction("Photograph", throwIfNotFound: true);
        m_Walk_Drag = m_Walk.FindAction("Drag", throwIfNotFound: true);
        m_Walk_Buy = m_Walk.FindAction("Buy", throwIfNotFound: true);
        m_Walk_Interact = m_Walk.FindAction("Interact", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Walk
    private readonly InputActionMap m_Walk;
    private IWalkActions m_WalkActionsCallbackInterface;
    private readonly InputAction m_Walk_Jump;
    private readonly InputAction m_Walk_Viewfinder;
    private readonly InputAction m_Walk_Move;
    private readonly InputAction m_Walk_Look;
    private readonly InputAction m_Walk_Photograph;
    private readonly InputAction m_Walk_Drag;
    private readonly InputAction m_Walk_Buy;
    private readonly InputAction m_Walk_Interact;
    public struct WalkActions
    {
        private @PlayerControls m_Wrapper;
        public WalkActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Walk_Jump;
        public InputAction @Viewfinder => m_Wrapper.m_Walk_Viewfinder;
        public InputAction @Move => m_Wrapper.m_Walk_Move;
        public InputAction @Look => m_Wrapper.m_Walk_Look;
        public InputAction @Photograph => m_Wrapper.m_Walk_Photograph;
        public InputAction @Drag => m_Wrapper.m_Walk_Drag;
        public InputAction @Buy => m_Wrapper.m_Walk_Buy;
        public InputAction @Interact => m_Wrapper.m_Walk_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Walk; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WalkActions set) { return set.Get(); }
        public void SetCallbacks(IWalkActions instance)
        {
            if (m_Wrapper.m_WalkActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_WalkActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_WalkActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_WalkActionsCallbackInterface.OnJump;
                @Viewfinder.started -= m_Wrapper.m_WalkActionsCallbackInterface.OnViewfinder;
                @Viewfinder.performed -= m_Wrapper.m_WalkActionsCallbackInterface.OnViewfinder;
                @Viewfinder.canceled -= m_Wrapper.m_WalkActionsCallbackInterface.OnViewfinder;
                @Move.started -= m_Wrapper.m_WalkActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_WalkActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_WalkActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_WalkActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_WalkActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_WalkActionsCallbackInterface.OnLook;
                @Photograph.started -= m_Wrapper.m_WalkActionsCallbackInterface.OnPhotograph;
                @Photograph.performed -= m_Wrapper.m_WalkActionsCallbackInterface.OnPhotograph;
                @Photograph.canceled -= m_Wrapper.m_WalkActionsCallbackInterface.OnPhotograph;
                @Drag.started -= m_Wrapper.m_WalkActionsCallbackInterface.OnDrag;
                @Drag.performed -= m_Wrapper.m_WalkActionsCallbackInterface.OnDrag;
                @Drag.canceled -= m_Wrapper.m_WalkActionsCallbackInterface.OnDrag;
                @Buy.started -= m_Wrapper.m_WalkActionsCallbackInterface.OnBuy;
                @Buy.performed -= m_Wrapper.m_WalkActionsCallbackInterface.OnBuy;
                @Buy.canceled -= m_Wrapper.m_WalkActionsCallbackInterface.OnBuy;
                @Interact.started -= m_Wrapper.m_WalkActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_WalkActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_WalkActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_WalkActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Viewfinder.started += instance.OnViewfinder;
                @Viewfinder.performed += instance.OnViewfinder;
                @Viewfinder.canceled += instance.OnViewfinder;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Photograph.started += instance.OnPhotograph;
                @Photograph.performed += instance.OnPhotograph;
                @Photograph.canceled += instance.OnPhotograph;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
                @Buy.started += instance.OnBuy;
                @Buy.performed += instance.OnBuy;
                @Buy.canceled += instance.OnBuy;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public WalkActions @Walk => new WalkActions(this);
    public interface IWalkActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnViewfinder(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnPhotograph(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
        void OnBuy(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}