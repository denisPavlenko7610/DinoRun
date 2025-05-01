using System;
using IdleRun.Components;
using UnityEngine;
using IdleRun.StateMachine;

namespace IdleRun
{
    public class Player : Character
    {
        [field: SerializeField] public Animator Animator { get; private set; }
        [SerializeField] private MoveComponent _moveComponent;

        public StateMachine<Player> StateMachine;
        public PlayerIdleState IdleState;
        private IEntityState<Player> _runState;

        public void Init(PlayerViewSO config)
        {
            Animator.runtimeAnimatorController = config.AnimatorController;
            StateMachine = new StateMachine<Player>();
            IdleState = new PlayerIdleState();
            _runState = new PlayerRunState();
            StateMachine.Initialize(_runState, this);
            //_moveComponent.AddCondition(_liveComponent.IsAlive);
        }

        private void OnEnable()
        {
            _moveComponent.OnEnable();
        }

        private void Update()
        {
            StateMachine?.Tick(this);
            _moveComponent.Update();
        }

        private void FixedUpdate()
        {
            _moveComponent.FixedUpdate();
        }
    }
}