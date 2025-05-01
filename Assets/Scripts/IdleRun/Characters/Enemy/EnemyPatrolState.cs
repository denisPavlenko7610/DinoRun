using IdleRun.StateMachine;
using UnityEngine;

namespace IdleRun
{
    public class EnemyPatrolState : IEntityState<EnemyView>
    {
        private static readonly int IsWalk = Animator.StringToHash("IsWalk");

        public void Enter(EnemyView enemy)
        {
            enemy.Animator.SetBool(IsWalk, true);
        }

        public void Tick(EnemyView enemy)
        {
            // enemy.Patrol();
            // if (enemy.CanSeePlayer)
            //     enemy.StateMachine.ChangeState(enemy.ChaseState, enemy);
        }

        public void Exit(EnemyView enemy)
        {
            enemy.Animator.SetBool(IsWalk, false);
        }
    }
}