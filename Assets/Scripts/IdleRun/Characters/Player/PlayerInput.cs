using System;
using IdleRun.Components;
using UnityEngine;
using UnityEngine.InputSystem;

namespace IdleRun.Characters.Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;

        private PlayerInput_Actions _inputActions;

        private void Awake()
        {
            _inputActions = new PlayerInput_Actions();
        }

        private void OnEnable()
        {
            _inputActions.Enable();
            _inputActions.Player.Jump.started += Jump;
        }

        private void OnDisable()
        {
            _inputActions.Player.Jump.started -= Jump;
            _inputActions.Disable();
        }

        private void Jump(InputAction.CallbackContext context)
        {
            

            _moveComponent.Jump();
        }

        
    }
}