using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace IdleRun.Core
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] Transform _playerSpawnPoint;
        [SerializeField] Transform _obstaclesSpawnPoint;
        [SerializeField] Transform _enemiesSpawnPoint;
        [SerializeField] private PlayerViewSO _playerViewSo;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<PlayerFactory>(Lifetime.Scoped).As<IPlayerFactory>();
            // builder.Register<ObstacleFactory>(Lifetime.Scoped).As<IObstacleFactory>();
            // builder.Register<EnemyFactory>(Lifetime.Scoped).As<IEnemyFactory>();

            builder.RegisterEntryPoint<GameBootstrap>()
                .WithParameter("playerSpawnPoint", _playerSpawnPoint)
                .WithParameter("obstaclesSpawnPoint", _obstaclesSpawnPoint)
                .WithParameter("enemiesSpawnPoint", _enemiesSpawnPoint)
                .WithParameter("playerViewSo", _playerViewSo);
        }
    }
}