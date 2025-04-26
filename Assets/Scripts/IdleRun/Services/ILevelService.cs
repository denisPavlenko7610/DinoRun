namespace IdleRun.Core
{
    public interface ILevelService
    {
        public LevelConfigSO CurrentConfig { get; }
        public void LoadNextLevel();
    }
}