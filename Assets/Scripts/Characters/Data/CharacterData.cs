using UnityEngine;

namespace IdleRun
{
    public class CharacterData : ScriptableObject
    {
        public GameObject Prefab;
        public Transform SpawnPoint;
        public RuntimeAnimatorController AnimatorController;
    }
}