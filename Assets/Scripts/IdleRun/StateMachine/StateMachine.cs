namespace IdleRun.StateMachine
{
    public class StateMachine<T>
    {
        public IEntityState<T> CurrentState { get; private set; }

        public void Initialize(IEntityState<T> startingState, T entity)
        {
            CurrentState = startingState;
            CurrentState.Enter(entity);
        }

        public void ChangeState(IEntityState<T> newState, T entity)
        {
            CurrentState.Exit(entity);
            CurrentState = newState;
            CurrentState.Enter(entity);
        }

        public void Tick(T entity)
        {
            CurrentState?.Tick(entity);
        }
    }
}