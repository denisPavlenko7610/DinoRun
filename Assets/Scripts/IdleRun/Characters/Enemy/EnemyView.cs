using UnityEngine;
using IdleRun.StateMachine;

namespace IdleRun
{
    public class EnemyView : Character
    {
        public StateMachine<EnemyView> StateMachine;
        public EnemyPatrolState PatrolState;
        //public EnemyDeadState DeadState;

        [field: SerializeField] public Animator Animator { get; private set; }

        private void Awake()
        {
            StateMachine = new StateMachine<EnemyView>();
            PatrolState = new EnemyPatrolState();
            //DeadState = new EnemyDeadState();

            StateMachine.Initialize(PatrolState, this);
        }

        private void Update()
        {
            StateMachine.Tick(this);
        }
    }
}