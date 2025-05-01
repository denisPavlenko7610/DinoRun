using System;
using UnityEngine;

namespace IdleRun.Components
{
    [Serializable]
    public class MoveComponent
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Rigidbody2D _targetRigidbody;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private Vector3 _direction;
        [SerializeField] private bool _canMove;
        [SerializeField] private bool _useRigidbody = true;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private int _maxJumps = 2;
        
        private readonly CompositeCondition _condition = new();
        private int _jumpsCount;

        public void OnEnable()
        {
            _jumpsCount = _maxJumps;
        }

        public void Update()
        {
            if (!_useRigidbody && _condition.IsTrue() && _canMove)
            {
                _target.position += _direction * (_speed * Time.deltaTime);
            }
        }

        public void FixedUpdate()
        {
            if (_useRigidbody && _condition.IsTrue() && _canMove)
            {
                _targetRigidbody.MovePosition(_target.position + _direction * (_speed * Time.fixedDeltaTime));
            }
        }

        public void SetDirection(Vector3 direction) => _direction = direction;

        public void AddCondition(Func<bool> condition) => _condition.AddCondition(condition);

        public void Jump()
        {
            if (_jumpsCount <= 0)
                return;
            
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
            if (collision.collider.CompareTag("Ground"))
                _jumpsCount = _maxJumps;
        }
    }
}