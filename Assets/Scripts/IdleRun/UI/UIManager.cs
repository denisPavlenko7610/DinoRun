using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace IdleRun.UI
{
    public class UIManager : IUIManager
    {
        private readonly Dictionary<string, GameObject> _panels = new Dictionary<string, GameObject>();

        public void Initialize()
        {
            // Здесь можно заранее прогрузить некоторые панели, если нужно
        }

        public void ShowPanel(string panelName)
        {
            if (_panels.TryGetValue(panelName, out var panel))
            {
                panel.SetActive(true);
                return;
            }

            // Асинхронно загружаем префаб по ключу Addressables
            Addressables.LoadAssetAsync<GameObject>($"UI/{panelName}")
                .Completed += handle => OnPanelLoaded(panelName, handle);
        }

        private void OnPanelLoaded(string panelName, AsyncOperationHandle<GameObject> handle)
        {
            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"Не удалось загрузить UI панель: {panelName}");
                return;
            }

            var panel = Object.Instantiate(handle.Result);
            panel.name = panelName;
            //DontDestroyOnLoad(panel);
            _panels[panelName] = panel;
        }

        public void HidePanel(string panelName)
        {
            if (_panels.TryGetValue(panelName, out var panel))
                panel.SetActive(false);
        }
    }
}