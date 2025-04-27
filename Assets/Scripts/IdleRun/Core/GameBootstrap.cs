using UnityEngine;
using VContainer.Unity;

namespace IdleRun.Core
{
    public class GameBootstrap : IStartable
    {
        readonly IPlayerFactory _playerFactory;
        //readonly IObstacleFactory _obstacleFactory;
        //readonly IEnemyFactory _enemyFactory;
        readonly ILevelService _levelService;

        readonly Transform _playerSpawnPoint;
        readonly Transform _obstaclesSpawnPoint;
        readonly Transform _enemiesSpawnPoint;
        PlayerViewSO _playerViewSo;

        public GameBootstrap(
            IPlayerFactory playerFactory,
            //IObstacleFactory obstacleFactory,
            //IEnemyFactory enemyFactory,
            ILevelService levelService,
            Transform playerSpawnPoint,
            Transform obstaclesSpawnPoint,
            Transform enemiesSpawnPoint,
            PlayerViewSO playerViewSo)
        {
            _playerFactory = playerFactory;
            //_obstacleFactory = obstacleFactory;
            //_enemyFactory = enemyFactory;
            _levelService = levelService;
            _playerSpawnPoint = playerSpawnPoint;
            _obstaclesSpawnPoint = obstaclesSpawnPoint;
            _enemiesSpawnPoint = enemiesSpawnPoint;
            _playerViewSo = playerViewSo;
        }

        public void Start()
        {
            var playerView = _playerFactory.CreatePlayer(_playerSpawnPoint);
            playerView.Init(_playerViewSo);

            //_obstacleFactory.SpawnAll();
            //_enemyFactory.SpawnAll();

            // playerGO.GetComponent<PlayerMovement>().OnDied += () =>
            // {
            //     _levelService.LoadNextLevel();
            //     UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            // };
        }
    }
}