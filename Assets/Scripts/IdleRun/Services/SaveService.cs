using UnityEngine;

namespace IdleRun.Core
{
    public class SaveService : ISaveService
    {
        private const string KEY = "CurrentLevel";
        public int GetSavedLevel()
        {
            return PlayerPrefs.GetInt(KEY, 1);
        }
        public void SaveLevel(int level)
        {
            PlayerPrefs.SetInt(KEY, level);
        }
    }
}