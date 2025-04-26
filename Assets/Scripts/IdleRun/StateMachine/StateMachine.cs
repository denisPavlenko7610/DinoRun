namespace IdleRun.StateMachine
{
    public class StateMachine<T>
    {
        public IState<T> CurrentState { get; private set; }

        public void Initialize(IState<T> startingState, T entity)
        {
            CurrentState = startingState;
            CurrentState.Enter(entity);
        }

        public void ChangeState(IState<T> newState, T entity)
        {
            CurrentState.Exit(entity);
            CurrentState = newState;
            CurrentState.Enter(entity);
        }

        public void Update(T entity)
        {
            CurrentState?.Execute(entity);
        }
    }
}