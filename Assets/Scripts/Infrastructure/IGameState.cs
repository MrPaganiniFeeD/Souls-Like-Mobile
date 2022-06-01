using DefaultNamespace.Infrastructure;

namespace Infrastructure
{
    public interface IGameGameState : IExitableGameState
    {
        void Enter();
    }
}