using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace IdleRun.Core
{
    public class BootstrapLifetimeScope : LifetimeScope
    {
        [SerializeField] LevelConfigSO[] allLevelConfigs;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SaveService>(Lifetime.Singleton).As<ISaveService>();
            builder.Register<LevelService>(Lifetime.Singleton).As<ILevelService>()
                .WithParameter(allLevelConfigs).As<IStartable>();
            
            // Конфигурационные SO сразу передаются в LevelService,
            // но если нужно — можно ещё и регистрировать
            // builder.RegisterInstance(allLevelConfigs).As<LevelConfigSO[]>();
        }
        
        protected override void Awake()
        {
            DontDestroyOnLoad(gameObject);
            base.Awake();
        }
    }
}