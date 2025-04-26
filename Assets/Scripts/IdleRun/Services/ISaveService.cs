namespace IdleRun.Core
{
    public interface ISaveService
    {
        int GetSavedLevel();
        void SaveLevel(int level);
    }
}