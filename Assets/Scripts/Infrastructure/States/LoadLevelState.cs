using DefaultNamespace.Infrastructure;
using DefaultNamespace.UI.Scene;
using Enemy.Factory;
using Infrastructure.DI;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using PlayerCamera;
using PlayerLogic.States;
using UnityEngine;
using Zenject;

namespace Infrastructure.States
{
    public class LoadLevelGameState : IPayloadedGameState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private const string EnemySpawnerTag = "EnemySpawner";

        private readonly IPersistentProgressService _persistentProgressService;
        private readonly IGameFactory _gameFactory;
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private LoadingCurtain _loadingCurtain;
        private readonly DiContainer _diContainer;


        public LoadLevelGameState(GameStateMachine stateMachine, SceneLoader sceneLoader, DiContainer diContainer,
            IGameFactory gameFactory, IPersistentProgressService persistentProgressService)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
            _persistentProgressService = persistentProgressService;
            _sceneLoader = sceneLoader;
            _diContainer = diContainer;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain = InstantiateLoadingCurtain();
            _loadingCurtain.Show();
            _gameFactory.CleanUp();
            _sceneLoader.ChangeProgress += OnChangeProgressLoading;
            _sceneLoader.Load(sceneName, onLoaded: OnLoaded);
        }
        
        public void Exit()
        {
            _loadingCurtain.Hide();
            _sceneLoader.ChangeProgress -= OnChangeProgressLoading;
        }

        private void OnChangeProgressLoading(float value) => 
            _loadingCurtain.UpdateProgress(value);

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();
            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressesReader)
                progressReader.LoadProgress(_persistentProgressService.PlayerProgress);
        }

        private void InitGameWorld()
        {
            InitSpawners();
            Player player = CreatePlayer();
            CameraInit(player);
            CreateHud();
        }

        private void CameraInit(Player player) => 
            Camera.main.GetComponent<CameraFollow>().Construct(player.gameObject.transform);

        private void InitSpawners()
        {
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag(EnemySpawnerTag))
            {
                EnemySpawner spawner = gameObject.GetComponent<EnemySpawner>();
                _gameFactory.Register(spawner);
            }
            
        }
        private void CreateHud() => 
            _gameFactory.CreateHud();

        private LoadingCurtain InstantiateLoadingCurtain()
        {
            GameObject loadingCurtainPrefab = _gameFactory.CreateScreenLoading();
            return loadingCurtainPrefab.GetComponent<LoadingCurtain>();
        }
        

        private Player CreatePlayer()
        {
            GameObject spawnObject = GameObject.FindWithTag(InitialPointTag);
            GameObject playerPrefab = _gameFactory.CreatePlayer(spawnObject);
            Player player = playerPrefab.GetComponent<Player>();
            DiContainerSceneRef.Container.Bind<Player>().FromInstance(player).AsSingle();
            return player;
        }
    }
}