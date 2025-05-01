using IdleRun;
using IdleRun.Core;
using IdleRun.Location;
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
        GameObject player = Object.Instantiate(_config.playerView.Prefab, spawnPoint.position, Quaternion.identity);
        player.AddComponent<MoveLocationObjectComponent>();
        return player.GetComponent<Player>();
    }
}