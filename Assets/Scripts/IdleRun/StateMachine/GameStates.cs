namespace IdleRun.StateMachine
{
    public class GameStates
    {
        private IState _current;

        public void Initialize(IState startState)
        {
            ChangeState(startState);
        }

        public void ChangeState(IState next)
        {
            _current?.Exit();
            _current = next;
            _current.Enter();
        }

        public void Update() => _current?.Tick();
    }
}