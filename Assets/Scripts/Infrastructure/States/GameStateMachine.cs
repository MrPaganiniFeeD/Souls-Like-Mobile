using System;
using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Zenject;

namespace Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableGameState> _states;
        private IExitableGameState _currentState;

        public GameStateMachine(SceneLoader sceneLoader, AllServices allServices, DiContainer diContainer)
        {
            _states = new Dictionary<Type, IExitableGameState>()
            {
                [typeof(BootstrapGameState)] = new BootstrapGameState(this, sceneLoader, allServices),
                [typeof(LoadProgressGameGameState)] = new LoadProgressGameGameState(this,
                        allServices.Single<IPersistentProgressService>(),
                        allServices.Single<ISaveLoadService>()),
                [typeof(LoadLevelGameState)] = new LoadLevelGameState(this, sceneLoader, diContainer,
                    allServices.Single<IGameFactory>(),
                    allServices.Single<IPersistentProgressService>()),
                [typeof(GameLoopState)] = new GameLoopState(this, sceneLoader, allServices)
            };
        }
        
        public void Enter<TState>() where TState : class, IGameGameState
        {
            TState newState = ChangeState<TState>();
            newState.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedGameState<TPayload>
        {
            IPayloadedGameState<TPayload> newGameState = ChangeState<TState>();
            newGameState.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableGameState
        {
            TState newState = GetState<TState>();
            _currentState?.Exit();
            _currentState = newState;
            return newState;
        }

        private TState GetState<TState>() where TState : class, IExitableGameState =>
            _states[typeof(TState)] as TState;
    }
}