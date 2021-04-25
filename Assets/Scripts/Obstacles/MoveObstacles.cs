using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private void Update()
    {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
    }
}
