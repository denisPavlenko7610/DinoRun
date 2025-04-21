using RD_Save.Runtime;
using RD_SimpleDI.Runtime.DI;
using RD_SimpleDI.Runtime.DI.Factory;
using UnityEngine;

namespace IdleRun
{
    [DefaultExecutionOrder(-40)]
    public class SceneContext : MonoBehaviour
    {
        [SerializeField] private Transform _playerStarterPoint;
        [SerializeField] private HeroesData _heroesDataSO;
        [SerializeField] private EnemyData _enemyDataSO;
        // [SerializeField] private HUD _hudPrefab;
        
        private SaveSystem _saveSystem;

        protected void Awake()
        {
            _saveSystem = DIContainer.Instance.Resolve<SaveSystem>();
            InitializeBindings();
            SpawnInitialCharacter();
            // Instantiate(_hudPrefab);
#if UNITY_EDITOR
            DIContainer.Instance.ValidateRegistrations();
#endif
        }

        void InitializeBindings()
        {
            DIContainer.Instance.Bind<ICharacterFactory, CharacterFactory>();
        }

        void SpawnInitialCharacter()
        {
            //PlayerData playerData = GetPlayerData();
            ICharacterFactory characterFactory = DIContainer.Instance.Resolve<ICharacterFactory>();
            // Player player = characterFactory.SpawnCharacter(_playerDataSO.Prefab, playerData.Position,
            //     Quaternion.identity, true);
            
            //player.SetupPlayerData(playerData);
        }

        // private PlayerData GetPlayerData()
        // {
        //     PlayerData playerData = _saveSystem.Load<PlayerData>();
        //     return playerData ?? new PlayerData(_playerStarterPoint.position, _playerDataSO.PlayerData.Health, _playerDataSO.PlayerData.Money);
        // }
    }
}
