using IdleRun.StateMachine;
using UnityEngine;

namespace IdleRun
{
    public class PlayerRunState : IState<PlayerView>
    {
        public void Enter(PlayerView player)
        {
            player.Animator.SetBool("IsRun", true);
            Debug.Log("Method Enter called");
            Debug.Log("IsRun value: " + player.Animator.GetBool("IsRun"));
        }

        public void Execute(PlayerView player)
        {
            // player.Move();  // своя логика движения
            // if (player.Input.Magnitude < 0.1f)
            //     player.StateMachine.ChangeState(player.IdleState, player);
        }

        public void Exit(PlayerView player)
        {
        }
    }
}