using System.Linq;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace IdleRun.Core
{
    public class LevelService : ILevelService, IStartable
    {
        private readonly ISaveService _save;
        private readonly LevelConfigSO[] _allConfigs;
        public LevelConfigSO CurrentConfig { get; private set; }

        public LevelService(ISaveService save, LevelConfigSO[] allConfigs)
        {
            _save = save;
            _allConfigs = allConfigs;
        }

        public void Start()
        {
            LoadCurrent();
        }

        private void LoadCurrent()
        {
            int lvl = _save.GetSavedLevel();
            CurrentConfig = _allConfigs.FirstOrDefault(c => c.scene.BuildIndex == lvl)
                            ?? _allConfigs.OrderBy(c => c.scene.BuildIndex).First();
            SceneManager.LoadScene(CurrentConfig.scene.BuildIndex);
        }

        public void LoadNextLevel()
        {
            int nextID = CurrentConfig.scene.BuildIndex + 1;
            var nextConfig = _allConfigs.FirstOrDefault(c => c.scene.BuildIndex == nextID);

            if (nextConfig != null)
            {
                _save.SaveLevel(nextConfig.scene.BuildIndex);
                SceneManager.LoadScene(nextConfig.scene.BuildIndex);
            }
            else
            {
                var firstConfig = _allConfigs
                    .OrderBy(c => c.scene.BuildIndex)
                    .First();

                _save.SaveLevel(firstConfig.scene.BuildIndex);
                SceneManager.LoadScene(firstConfig.scene.BuildIndex);
            }
        }
    }
}