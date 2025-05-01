using UnityEngine;

namespace IdleRun.Core
{
    public interface IFactory<T>
    {
        T Create(string key, Transform parent = null);
    }
}