using System;
using UnityEngine;
using IdleRun.StateMachine;

namespace IdleRun
{
    public class PlayerView : Character
    {
        private static readonly int IsRun = Animator.StringToHash("IsRun");
        private static readonly int Dead = Animator.StringToHash("Dead");
        private static readonly int IsJump = Animator.StringToHash("IsJump");
        [field: SerializeField] public Animator Animator { get; private set; }

        public StateMachine<PlayerView> StateMachine;
        public PlayerIdleState IdleState;
        private PlayerRunState RunState;

        public void Init(PlayerViewSO config)
        {
            Animator = GetComponentInChildren<Animator>();
            Animator.runtimeAnimatorController = config.AnimatorController;
            StateMachine = new StateMachine<PlayerView>();
            IdleState = new PlayerIdleState();
            RunState = new PlayerRunState();
            StateMachine.Initialize(RunState, this);
        }

        private void Update()
        {
            StateMachine?.Update(this);
        }
    }
}