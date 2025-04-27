using IdleRun.Characters.Player;
using IdleRun.StateMachine;

namespace IdleRun
{
    public class PlayerIdleState : IState<Player>
    {
        public void Enter(Player player)
        {
            player.Animator.SetBool(AnimationConstants.IsRun, false);
        }

        public void Execute(Player player)
        {
            //game started
            //     player.StateMachine.ChangeState(player.RunState, player);
        }

        public void Exit(Player player)
        {
            // ничего не нужно
        }
    }
}