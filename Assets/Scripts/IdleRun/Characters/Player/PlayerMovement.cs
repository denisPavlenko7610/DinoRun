using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace IdleRun.Characters.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float runSpeed = 5f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private int maxJumps = 2;

        [SerializeField] private Rigidbody2D _rigidbody2D;

        private PlayerInput_Actions _inputActions;
        private int _jumpsCount;

        private void Awake()
        {
            _inputActions = new PlayerInput_Actions();
        }

        private void OnEnable()
        {
            _jumpsCount = maxJumps;
            _inputActions.Enable();
            _inputActions.Player.Jump.started += Jump;
        }

        private void OnDisable()
        {
            _inputActions.Player.Jump.started -= Jump;
            _inputActions.Disable();
        }

        private void Update()
        {
            _rigidbody2D.linearVelocity = new Vector2(runSpeed, _rigidbody2D.linearVelocity.y);
        }

        private void Jump(InputAction.CallbackContext context)
        {
            if (_jumpsCount <= 0)
                return;

            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, 0f);
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _jumpsCount--;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ground"))
                _jumpsCount = maxJumps;
        }
    }
}