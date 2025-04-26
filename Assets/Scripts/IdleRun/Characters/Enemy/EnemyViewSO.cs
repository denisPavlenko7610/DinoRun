using UnityEngine;

namespace IdleRun
{
    [CreateAssetMenu(fileName = "EnemyViewSO", menuName = "Characters/Enemy DataSO")]
    public class EnemyViewSO : CharacterDataSO
    {
        public EnemyType EnemyType;
    }
}