using System;
using UnityEngine;
using IdleRun.StateMachine;

namespace IdleRun
{
    public class Player : Character
    {
        [field: SerializeField] public Animator Animator { get; private set; }

        public StateMachine<Player> StateMachine;
        public PlayerIdleState IdleState;
        private PlayerRunState RunState;

        public void Init(PlayerViewSO config)
        {
            Animator.runtimeAnimatorController = config.AnimatorController;
            StateMachine = new StateMachine<Player>();
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