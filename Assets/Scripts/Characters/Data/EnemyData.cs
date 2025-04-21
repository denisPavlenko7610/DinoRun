using UnityEngine;

namespace IdleRun
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Characters/Enemy Data")]
    public class EnemyData : CharacterData
    {
        public EnemyType EnemyType;
    }
}