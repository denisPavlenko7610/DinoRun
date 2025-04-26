using IdleRun.StateMachine;

namespace IdleRun
{
    public class PlayerIdleState : IState<PlayerView>
    {
        public void Enter(PlayerView player)
        {
            player.Animator.SetBool("IsRun", false);
        }

        public void Execute(PlayerView player)
        {
            //game started
            //     player.StateMachine.ChangeState(player.RunState, player);
        }

        public void Exit(PlayerView player)
        {
            // ничего не нужно
        }
    }
}