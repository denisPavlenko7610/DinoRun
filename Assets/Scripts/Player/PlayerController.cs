using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Button _restartButton;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _playerAnimatior;
    private bool _isGround;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimatior = GetComponent<Animator>();
    }

    private void Update()
    {
        Run();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameManager._isGameStop = true;
            _playerAnimatior.SetBool("isDead", true);
            _restartButton.gameObject.SetActive(true);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _isGround = false;
    }

    private void Jump()
    {
        if (_isGround && Input.GetMouseButtonDown(0) && GameManager._isGameStart && GameManager._isGameStop == false)
        {
            _rigidbody2D.AddForce(Vector2.up * (_jumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
            _playerAnimatior.SetBool("isJump", true);
        }

        if (_isGround == false)
        {
            _playerAnimatior.SetBool("isJump", false);
        }
    }

    private void Run()
    {
        if (GameManager._isGameStart)
        {
            _playerAnimatior.SetBool("isStart", true);
        }
    }
}