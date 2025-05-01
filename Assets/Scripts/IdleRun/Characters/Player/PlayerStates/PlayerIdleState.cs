using IdleRun.Characters.Player;
using IdleRun.StateMachine;

namespace IdleRun
{
    public class PlayerIdleState : IEntityState<Player>
    {
        public void Enter(Player player)
        {
            player.Animator.SetBool(AnimationConstants.IsRun, false);
        }

        public void Tick(Player player)
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