using UnityEngine;

namespace IdleRun
{
    [CreateAssetMenu(fileName = "EnemyViewSO", menuName = "Entity/Enemy DataSO")]
    public class EnemyViewSO : CharacterDataSO
    {
        public EnemyType EnemyType;
    }
}