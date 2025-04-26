using RDTools;
using UnityEngine;

namespace IdleRun
{
    [CreateAssetMenu(menuName = "Configs/LevelConfig")]
    public class LevelConfigSO : ScriptableObject
    {
        public Scene scene;
        public PlayerViewSO playerView;
        //public ObstacleViewSO[] obstacleViews;
        public EnemyViewSO[] enemyViews;
    }
}