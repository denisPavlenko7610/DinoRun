using IdleRun;
using UnityEngine;

public interface IPlayerFactory
{
    Player CreatePlayer(Transform spawnPoint);
}