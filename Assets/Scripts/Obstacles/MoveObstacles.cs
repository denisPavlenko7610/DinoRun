using UnityEngine;
public class MoveObstacles : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private void Update()
    {
        if (GameManager._isGameStop == false)
        {
            transform.Translate(Vector2.left * (speed * Time.deltaTime));
        }
    }
}
