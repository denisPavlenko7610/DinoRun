using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        if (GameManager._isGameStop == false && GameManager._isGameStart)
        {
            transform.position += Vector3.left * (speed * Time.deltaTime);
        }
    }
}