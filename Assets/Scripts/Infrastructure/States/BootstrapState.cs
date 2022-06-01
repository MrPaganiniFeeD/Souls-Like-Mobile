﻿using DefaultNamespace.Infrastructure;
using DefaultNamespace.UI.Input;
using Infrastructure.AssetsManagement;
using Infrastructure.DI;
using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.Inventory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapGameState : IGameGameState
    {
        private const string SceneName = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _allServices;

        public BootstrapGameState(GameStateMachine stateMachine, SceneLoader sceneLoader, 
            AllServices allServices)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _allServices = allServices;

            RegisterServices();
        }

        public void Enter() 
            => _sceneLoader.Load(SceneName, onLoaded: EnterLoadScene);

        public void Exit()
        {
        }

        private void EnterLoadScene() => 
            _stateMachine.Enter<LoadProgressGameGameState>();

        private void RegisterServices()
        { 
            RegisterAssetsService();
            RegisterInventoryService();
            RegisterGameFactory();
            RegisterPersistentProgressService();
            RegisterInputService();
            RegisterSaveLoadService();
        }

        private void RegisterInventoryService() =>
            _allServices
                .RegisterSingle<IInventoryService>()
                .To<InventoryService>(new InventoryService(25));

        private void RegisterAssetsService() =>
            _allServices
                .RegisterSingle<IAssets>()
                .To(new AssetsProvider());

        private void RegisterGameFactory() =>
            _allServices
                .RegisterSingle<IGameFactory>()
                .To(new GameFactory(_allServices.Single<IAssets>()));

        private void RegisterPersistentProgressService() =>
            _allServices
                .RegisterSingle<IPersistentProgressService>()
                .To(new PersistentProgressService());

        private void RegisterSaveLoadService() => 
            _allServices
                .RegisterSingle<ISaveLoadService>()
                .To(new SaveLoadService(_allServices.Single<IPersistentProgressService>(),
                    _allServices.Single<IGameFactory>(), _allServices));

        private void RegisterInputService()
        {
            if (Application.isEditor)
                _allServices
                    .RegisterSingle<IInputService>()
                    .To(new StandaloneInputService());
            else if(Application.isMobilePlatform)
                _allServices
                    .RegisterSingle<IInputService>()
                    .To(new MobileInputService());
        }
        
    }
}