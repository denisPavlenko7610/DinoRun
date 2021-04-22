using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _speed;
    [SerializeField] private Transform playerSpawnPosition;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();

        MoveRight();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        transform.position = new Vector3(playerSpawnPosition.position.x, transform.position.y,
            playerSpawnPosition.position.z);
    }

    private void MoveRight()
    {
        transform.position += Vector3.right * (_speed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody2D.AddForce(Vector2.up * (_jumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
        }
    }
}