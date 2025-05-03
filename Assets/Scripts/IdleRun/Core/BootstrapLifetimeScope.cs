using IdleRun.StateMachine;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace IdleRun.Core
{
    public class BootstrapLifetimeScope : LifetimeScope
    {
        [SerializeField] LevelConfigSO[] allLevelConfigs;
        [SerializeField] private InputActionAsset _actions;

        private GameStates _gameStates;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SaveService>(Lifetime.Singleton).As<ISaveService>();
            builder.Register<LevelService>(Lifetime.Singleton).As<ILevelService>()
                .WithParameter(allLevelConfigs).As<IStartable>();
        }

        protected override void Awake()
        {
            base.Awake();

            _gameStates = new GameStates();
            _gameStates.Initialize(new PlayState(_gameStates, _actions));

            DontDestroyOnLoad(gameObject);
        }
        
        private void Update()
        {
            _gameStates.Update();
        }
    }
}