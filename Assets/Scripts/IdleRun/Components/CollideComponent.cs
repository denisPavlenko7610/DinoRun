using System;
using IdleRun.Entity;
using UnityEngine;

namespace IdleRun.Components
{
    public class CollideComponent : MonoBehaviour
    {
        public event Action<IEnemy> OnCollide;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out IEnemy enemy))
            {
                OnCollide?.Invoke(enemy);
            }    
        }
    }
}