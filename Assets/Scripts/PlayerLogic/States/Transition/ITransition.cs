using PlayerLogic.States.StateMachine;

namespace PlayerLogic.States.Transition
{
    public interface ITransition
    {
        PlayerStateMachine PlayerStateMachine { get; }
    
        void Enter();
        void Update();
        void Exit();
        void Transit();
    }
}
