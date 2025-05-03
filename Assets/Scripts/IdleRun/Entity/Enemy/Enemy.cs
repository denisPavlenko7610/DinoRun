using IdleRun.Entity;
using UnityEngine;

namespace IdleRun
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public static bool IsFlyingType(EnemyType type) => type is EnemyType.Raven or EnemyType.Monster or EnemyType.Dragon or EnemyType.Bee;
        
    }
}