using IdleRun;
using IdleRun.Core;
using UnityEngine;

public class PlayerFactory : IPlayerFactory
{
    private readonly LevelConfigSO _config;
    public PlayerFactory(ILevelService levelService)
    {
        _config = levelService.CurrentConfig;
    }

    public Player CreatePlayer(Transform spawnPoint)
    {
        return Object.Instantiate(_config.playerView.Prefab, spawnPoint.position, Quaternion.identity)
            .GetComponent<Player>();
    }
}