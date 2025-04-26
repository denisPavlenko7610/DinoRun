namespace IdleRun.StateMachine
{
    public interface IState<T>
    {
        void Enter(T entity);
        void Execute(T entity);
        void Exit(T entity);
    }
}