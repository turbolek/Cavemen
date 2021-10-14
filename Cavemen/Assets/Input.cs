// GENERATED AUTOMATICALLY FROM 'Assets/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""GeneralActions"",
            ""id"": ""2f055d03-8cb7-4d36-a9a9-534760554d8a"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""64c85bbe-a29a-4924-a0ff-def919284761"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UpdateMousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""5f9cf343-9352-49df-8e90-2d6c3df6b9be"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ab7b9172-cec5-46e2-b1b6-95867e8e76e4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dac7b456-2718-440f-ace1-db89d745cef4"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpdateMousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UnitActions"",
            ""id"": ""84241be6-8afc-42af-891f-d02f2e3e5cd2"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""cc56ae32-c72b-4bce-a7be-69119d8173d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3a20a7c8-a836-4cd3-a7bf-565b649a5b3b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GeneralActions
        m_GeneralActions = asset.FindActionMap("GeneralActions", throwIfNotFound: true);
        m_GeneralActions_Select = m_GeneralActions.FindAction("Select", throwIfNotFound: true);
        m_GeneralActions_UpdateMousePosition = m_GeneralActions.FindAction("UpdateMousePosition", throwIfNotFound: true);
        // UnitActions
        m_UnitActions = asset.FindActionMap("UnitActions", throwIfNotFound: true);
        m_UnitActions_Move = m_UnitActions.FindAction("Move", throwIfNotFound: true);
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

    // GeneralActions
    private readonly InputActionMap m_GeneralActions;
    private IGeneralActionsActions m_GeneralActionsActionsCallbackInterface;
    private readonly InputAction m_GeneralActions_Select;
    private readonly InputAction m_GeneralActions_UpdateMousePosition;
    public struct GeneralActionsActions
    {
        private @Input m_Wrapper;
        public GeneralActionsActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_GeneralActions_Select;
        public InputAction @UpdateMousePosition => m_Wrapper.m_GeneralActions_UpdateMousePosition;
        public InputActionMap Get() { return m_Wrapper.m_GeneralActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActionsActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralActionsActions instance)
        {
            if (m_Wrapper.m_GeneralActionsActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_GeneralActionsActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_GeneralActionsActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_GeneralActionsActionsCallbackInterface.OnSelect;
                @UpdateMousePosition.started -= m_Wrapper.m_GeneralActionsActionsCallbackInterface.OnUpdateMousePosition;
                @UpdateMousePosition.performed -= m_Wrapper.m_GeneralActionsActionsCallbackInterface.OnUpdateMousePosition;
                @UpdateMousePosition.canceled -= m_Wrapper.m_GeneralActionsActionsCallbackInterface.OnUpdateMousePosition;
            }
            m_Wrapper.m_GeneralActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @UpdateMousePosition.started += instance.OnUpdateMousePosition;
                @UpdateMousePosition.performed += instance.OnUpdateMousePosition;
                @UpdateMousePosition.canceled += instance.OnUpdateMousePosition;
            }
        }
    }
    public GeneralActionsActions @GeneralActions => new GeneralActionsActions(this);

    // UnitActions
    private readonly InputActionMap m_UnitActions;
    private IUnitActionsActions m_UnitActionsActionsCallbackInterface;
    private readonly InputAction m_UnitActions_Move;
    public struct UnitActionsActions
    {
        private @Input m_Wrapper;
        public UnitActionsActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_UnitActions_Move;
        public InputActionMap Get() { return m_Wrapper.m_UnitActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UnitActionsActions set) { return set.Get(); }
        public void SetCallbacks(IUnitActionsActions instance)
        {
            if (m_Wrapper.m_UnitActionsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_UnitActionsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_UnitActionsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_UnitActionsActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_UnitActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public UnitActionsActions @UnitActions => new UnitActionsActions(this);
    public interface IGeneralActionsActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnUpdateMousePosition(InputAction.CallbackContext context);
    }
    public interface IUnitActionsActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
