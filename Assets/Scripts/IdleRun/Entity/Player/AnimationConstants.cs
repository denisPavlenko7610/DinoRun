using UnityEngine;

namespace IdleRun.Characters.Player
{
    public static class AnimationConstants
    {
        public static readonly int IsRun = Animator.StringToHash("IsRun");
        public static readonly int Dead = Animator.StringToHash("Dead");
        public static readonly int IsJump = Animator.StringToHash("IsJump");
    }
}