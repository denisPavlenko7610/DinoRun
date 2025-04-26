using IdleRun;
using UnityEngine;

public interface IPlayerFactory
{
    PlayerView CreatePlayer(Transform spawnPoint);
}

// PlayerFactory.cs