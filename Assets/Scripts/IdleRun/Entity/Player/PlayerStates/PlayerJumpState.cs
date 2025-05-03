using IdleRun.Characters.Player;
using IdleRun.StateMachine;

namespace IdleRun
{
    public class PlayerJumpState : IEntityState<Player>
    {
        public void Enter(Player player)
        {
            player.Animator.SetBool(AnimationConstants.IsJump, true);
        }

        public void Tick(Player player)
        {
            
        }

        public void Exit(Player player)
        {
            player.Animator.SetBool(AnimationConstants.IsJump, false);
        }
    }
}