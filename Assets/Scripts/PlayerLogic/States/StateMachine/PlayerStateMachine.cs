using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Extensions;
using Fabrics;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using PlayerLogic.Animation;
using PlayerLogic.States.State;
using PlayerLogic.States.Transition;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PlayerLogic.States.StateMachine
{
    public class PlayerStateMachine : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private bool _isLocked;
        [SerializeField] private List<PlayerStateInfo> _stateInfos;

        private IInputService _inputService;
        private IFactoryTransition _factoryTransition;

        private Dictionary<Type, IState> _allState;
        private IState _currentState;


        private PlayerStateAnimator _animator;
        private CharacterController _characterController;
        private Transform _transform;
        private Dictionary<IState, IPlayerStatePayloaded> _queueStates;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _factoryTransition = new FactoryTransitions(inputService, this);
            _queueStates = new Dictionary<IState, IPlayerStatePayloaded>();
        }
        
        private void Awake()
        {
            _animator = GetComponent<PlayerStateAnimator>();
            _characterController = GetComponent<CharacterController>();
            _transform = transform;
            
            _allState = new Dictionary<Type, IState>
            {
                [typeof(IdleState)] = new IdleState(GetTransition(TypePlayerState.Idle), _animator),
                [typeof(PlayerMoveState)] = new PlayerMoveState(GetTransition(TypePlayerState.Move),
                    _inputService, Camera.main, _transform, _characterController, _animator),
                [typeof(AttackState)] = new AttackState(
                    GetTransition(TypePlayerState.Attack), _animator, this)
            };
        }

        private void Start() => 
            Enter<IdleState>();

        private void Update() => 
            _currentState.Update();

        public void Enter<TState>() where TState : class, IState
        {
            if(_isLocked)
                return;

            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayloaded>(TPayloaded payloaded)
            where TState : class, IState, IPlayerState<TPayloaded> where TPayloaded : IPlayerStatePayloaded
        {
            if(_isLocked)
                return;

            IPlayerState<TPayloaded> state = ChangeState<TState>();
            state.Enter(payloaded);
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            if (CurrentLevel() == playerProgress.WorldData.PositionOnLevel.Level)
            {
                Vector3Data savedPosition = playerProgress.WorldData.PositionOnLevel.Position;
                if(savedPosition != null)
                {
                    float offsetYSpawn = 0.5f;
                    _transform.position = savedPosition.AsUnityVector().AddY(offsetYSpawn);
                }
            }
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            playerProgress.WorldData.PositionOnLevel = new PositionOnLevel(CurrentLevel(),
                _transform.position.AsVectorData());
        }

        private List<ITransition> GetTransition(TypePlayerState stateType)
        {
            foreach (PlayerStateInfo stateInfo in _stateInfos.Where(stateInfo => stateInfo.State == stateType))
                return _factoryTransition.CreatTransitions(stateInfo.Transitions);
            return null;
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            TState newState = GetState<TState>();
            _currentState?.Exit();
            _currentState = newState;
            LockStateMachineForTime(_currentState.Duration);
            return newState;
        }

        public void Enqueue<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            _queueStates.Add(state, null);
        }

        public void Enqueue<TState, TPayloaded>(TPayloaded payloaded)
            where TState : class, IPlayerState<TPayloaded>, IState 
            where TPayloaded : IPlayerStatePayloaded
        {
            TState state = ChangeState<TState>();
            _queueStates.Add(state, payloaded);
        }

        public async void StartEnteringQueueStates()
        {
            foreach (KeyValuePair<IState, IPlayerStatePayloaded> pair in _queueStates)
            {
                IState state = pair.Key;
                IPlayerStatePayloaded payload = pair.Value;
                
                _currentState.Exit();
                _currentState = state;

                if (state is IPlayerState<IPlayerStatePayloaded> payloadedState)
                {
                    payloadedState.Enter(payload);
                    return;
                }
                state.Enter();
            }
        }
        private async void LockStateMachineForTime(float time)
        {
            if(time < 0.01)
                return;
            
            _isLocked = true;
            int timeInt = Mathf.RoundToInt(time * 1000);
            await Task.Delay(timeInt);
            _isLocked = false;
        }

        private void AddState<TState>(TState state) where TState : class, IState => 
            _allState.Add(typeof(TState), state);

        private TState GetState<TState>() where TState : class, IState => 
            _allState[typeof(TState)] as TState;

        private static string CurrentLevel() => 
            SceneManager.GetActiveScene().name;
    }
}