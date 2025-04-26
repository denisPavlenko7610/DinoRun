using UnityEngine;

namespace IdleRun
{
    public abstract class CharacterDataSO : ScriptableObject
    {
        public GameObject Prefab;
        public RuntimeAnimatorController AnimatorController;
    }
}