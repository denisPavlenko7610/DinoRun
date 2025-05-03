using System;
using UnityEngine;

namespace IdleRun.Components
{
    [Serializable]
    public class JumpComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Rigidbody2D _targetRigidbody;
        [SerializeField] private bool _useRigidbody = true;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private int _maxJumps = 2;

        public event Action OnJump;
        public event Action OnLand;
        
        private bool _canJump;
        private int _jumpsCount;

        public void OnEnable()
        {
            _jumpsCount = _maxJumps;
        }
        
        public void CanJump(bool canJump) => _canJump = canJump;
        
        public void Jump()
        {
            if (!_canJump || _jumpsCount <= 0)
                return;
            
            OnJump?.Invoke();
            
            if (_useRigidbody)
            {
                _targetRigidbody.linearVelocity = new Vector2(_targetRigidbody.linearVelocity.x, 0f);
                _targetRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
            else
            {
                _target.position += Vector3.up * _jumpForce * Time.fixedDeltaTime;
            }
            
            _jumpsCount--;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.collider.CompareTag("Ground")) 
                return;
            
            _jumpsCount = _maxJumps;
            OnLand?.Invoke();
        }
    }
}