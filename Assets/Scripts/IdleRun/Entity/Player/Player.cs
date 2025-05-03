using IdleRun.Components;
using IdleRun.Entity;
using UnityEngine;
using IdleRun.StateMachine;

namespace IdleRun
{
    [RequireComponent(typeof(JumpComponent), typeof(CollideComponent))]
    public class Player : Character
    {
        [field: SerializeField] public Animator Animator { get; private set; }
        [SerializeField] private JumpComponent _jumpComponent;
        [SerializeField] private CollideComponent _collideComponent;

        private StateMachine<Player> _stateMachine;
        private IEntityState<Player> _idleState;
        private IEntityState<Player> _runState;
        private IEntityState<Player> _deadState;
        private IEntityState<Player> _jumpState;

        public void Init(PlayerViewSO config)
        {
            Animator.runtimeAnimatorController = config.AnimatorController;
            _stateMachine = new StateMachine<Player>();
            _idleState = new PlayerIdleState();
            _runState = new PlayerRunState();
            _deadState = new PlayerDeathState();
            _jumpState = new PlayerJumpState();
            
            _stateMachine.Initialize(_runState, this);
            _jumpComponent.CanJump(true);
        }

        private void OnEnable()
        {
            _collideComponent.OnCollide += OnPlayerCollide;
            _jumpComponent.OnJump += OnPlayerJump;
            _jumpComponent.OnLand += OnPlayerLand;
        }

        private void OnDisable()
        {
            _collideComponent.OnCollide -= OnPlayerCollide;
            _jumpComponent.OnJump -= OnPlayerJump;
            _jumpComponent.OnLand -= OnPlayerLand;
        }

        private void Update()
        {
            _stateMachine?.Tick(this);
        }

        private void OnPlayerCollide(IEnemy obj)
        {
            _jumpComponent.CanJump(false);
            _stateMachine.ChangeState(_deadState, this);
        }
        
        private void OnPlayerJump()
        {
            _stateMachine.ChangeState(_jumpState, this);
        }
        
        private void OnPlayerLand()
        {
            _stateMachine.ChangeState(_runState, this);
        }
    }
}