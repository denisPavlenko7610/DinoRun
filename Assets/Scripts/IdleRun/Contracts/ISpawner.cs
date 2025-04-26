using UnityEngine;

namespace IdleRun.Contracts
{
    public interface ISpawner
    {
        void SpawnDino(Vector3 atPosition);
        void SpawnObstacle(Vector3 atPosition);
    }
}