using IdleRun.Characters.Player;
using IdleRun.StateMachine;

namespace IdleRun
{
    public class PlayerDeathState : IEntityState<Player>
    {
        public void Enter(Player player)
        {
            player.Animator.SetBool(AnimationConstants.IsRun, false);
            player.Animator.SetBool(AnimationConstants.Dead, true);
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