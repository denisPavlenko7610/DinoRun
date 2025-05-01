namespace IdleRun.StateMachine
{
    public interface IEntityState<T>
    {
        void Enter(T entity);
        void Tick(T entity);
        void Exit(T entity);
    }
}