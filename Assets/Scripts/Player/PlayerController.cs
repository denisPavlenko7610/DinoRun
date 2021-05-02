using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameManager._isGameStop = true;
        }
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody2D.AddForce(Vector2.up * (_jumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
        }
    }
}