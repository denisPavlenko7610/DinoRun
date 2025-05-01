using IdleRun.Characters.Player;
using IdleRun.StateMachine;
using UnityEngine;

namespace IdleRun
{
    public class PlayerRunState : IEntityState<Player>
    {
        public void Enter(Player player)
        {
            player.Animator.SetBool(AnimationConstants.IsRun, true);
        }

        public void Tick(Player player)
        {
            // player.Move();
            // if (player.Input.Magnitude < 0.1f)
            //     player.StateMachine.ChangeState(player.IdleState, player);
        }

        public void Exit(Player player)
        {
        }
    }
}