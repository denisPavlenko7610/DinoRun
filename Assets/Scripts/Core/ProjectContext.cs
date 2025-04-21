using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RD_Save.Runtime;
using RD_SimpleDI.Runtime.DI;
using RD_SimpleDI.Runtime.LifeCycle;
using RD_Tween.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IdleRun
{
    public class ProjectContext : MonoBehaviour
    {
        [SerializeField] private SaveFormat _saveFormat;
        [SerializeField] private string _saveFilePath;

        [SerializeField] private RunnerUpdater _runnerUpdater;
        [SerializeField] private TweenUpdater _tweenUpdater;

        [SerializeField] private List<GameObject> _dontDestroyList = new();
        //private InputAction _pauseAction;
        private SaveSystem _saveSystem;

        protected async void Awake()
        {
            try
            {
                InitializeBindings();
                Subscribe();
                SetUnityLogStatus();
                SetupDontDestroy();
                await LoadMainScene();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
       
        private void SetupDontDestroy()
        {
            foreach (GameObject dontDestroyObject in _dontDestroyList)
            {
                DontDestroyOnLoad(dontDestroyObject);
            }
            
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(_tweenUpdater);
            DontDestroyOnLoad(_runnerUpdater);
        }

        void InitializeBindings()
        {
            _saveSystem = new SaveSystem(SaveSystemFactory.GetSerializer(_saveFormat), _saveFormat, _saveFilePath);
            DIContainer.Instance.Bind(_saveSystem);
        }
        
        void Subscribe()
        {
            // _pauseAction = InputSystem.actions.FindAction("Pause");
            // _pauseAction.performed += OnPausePerformed;
        }
        
        void SetUnityLogStatus() => Debug.unityLogger.logEnabled = Debug.isDebugBuild;

        private async Task LoadMainScene()
        {
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync("Level_1");
            while (!loadSceneAsync.isDone)
            {
                await Task.Yield();
            }
        }
        
        public static T Resolve<T>() => DIContainer.Instance.Resolve<T>();
        
        //private void OnPausePerformed(InputAction.CallbackContext context) => GameState.TogglePause();

        void Unsubscribe()
        {
            // if (_pauseAction != null)
            // {
            //     _pauseAction.performed -= OnPausePerformed;
            // }
        }

        protected void OnDestroy()
        {
            Unsubscribe();
        }
    }
}
