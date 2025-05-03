using System;
using IdleRun.Components;
using UnityEngine;
using UnityEngine.InputSystem;

namespace IdleRun.Characters.Player
{
    public class InputComponent : MonoBehaviour
    {
        [SerializeField] private JumpComponent _jumpComponent;
        [SerializeField] InputActionAsset _actions;
        
        private InputAction _jumpAction;

        private void Awake()
        {
            _jumpAction = _actions.FindAction("Player/Jump");
        }

        private void OnEnable()
        {
            _jumpAction.performed += Jump;
            _jumpAction.Enable();
        }

        private void OnDisable()
        {
            _jumpAction.performed -= Jump;
            _jumpAction.Disable();
        }

        private void Jump(InputAction.CallbackContext context)
        {
            _jumpComponent.Jump();
        }
    }
}