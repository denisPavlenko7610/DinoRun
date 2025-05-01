using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace IdleRun.Core
{
    public interface IAddressablesService : IGameService
    {
        void LoadScene(string sceneKey, bool additive = false, Action onLoaded = null);
        void LoadAsset<T>(string address, Action<T> onLoaded) where T : UnityEngine.Object;
    }
    
    public class AddressablesService : IAddressablesService
    {
        public void Initialize()
        {
             /* предзагрузка, конфигурации и т.п. */
        }

        public void LoadScene(string sceneKey, bool additive = false, Action onLoaded = null)
        {
            Addressables.LoadSceneAsync(sceneKey, additive ? LoadSceneMode.Additive : LoadSceneMode.Single)
                .Completed += (AsyncOperationHandle<SceneInstance> handle) =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                    onLoaded?.Invoke();
                else
                    Debug.LogError($"Loading scene error: {sceneKey}");
            };
        }

        public void LoadAsset<T>(string address, Action<T> onLoaded) where T : UnityEngine.Object
        {
            Addressables.LoadAssetAsync<T>(address)
                .Completed += (AsyncOperationHandle<T> handle) =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                    onLoaded?.Invoke(handle.Result);
                else
                    Debug.LogError($"Loading assets error: {address}");
            };
        }
    }
}