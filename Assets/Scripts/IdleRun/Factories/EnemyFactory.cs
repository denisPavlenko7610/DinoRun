using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Pool;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace IdleRun.Core
{
    public class EnemyFactory : IFactory<GameObject>
    {
        private readonly ObjectPool<GameObject> _pool;
        private readonly string _addressPrefix;

        public EnemyFactory(string addressPrefix = "Enemies/", int initialCapacity = 10)
        {
            _addressPrefix = addressPrefix;
            _pool = new ObjectPool<GameObject>(
                createFunc: () => Addressables.LoadAssetAsync<GameObject>($"{_addressPrefix}DefaultEnemy").WaitForCompletion(),
                actionOnGet: enemy => enemy.SetActive(true),
                actionOnRelease: enemy => enemy.SetActive(false),
                defaultCapacity: initialCapacity);
        }

        public GameObject Create(string key, Transform parent = null)
        {
            // Получаем или создаём экземпляр
            var enemy = _pool.Get();

            // Если адрес отличается от Default, грузим нужный
            if (key != "DefaultEnemy")
            {
                var prefab = Addressables.LoadAssetAsync<GameObject>($"{_addressPrefix}{key}").WaitForCompletion();
                Object.Destroy(enemy);
                enemy = Object.Instantiate(prefab, parent);
            }
            else
            {
                enemy.transform.SetParent(parent);
            }

            enemy.name = key;
            return enemy;
        }

        public void Release(GameObject enemy)
        {
            _pool.Release(enemy);
        }
    }
}