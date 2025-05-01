using UnityEngine;

namespace IdleRun.Location
{
    public class MoveLocationObjectComponent : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.5f;
        
        private void Update()
        {
            transform.position += Vector3.right * (Time.deltaTime * _speed);
        }
    }
}