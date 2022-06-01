using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using PlayerLogic.Stats;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgress> ProgressesWriter { get; }
        List<ISavedProgressReader> ProgressesReader { get; }
        GameObject CreatePlayer(GameObject at);
        GameObject CreateScreenLoading();
        GameObject CreateHud();
        IStatsProvider CreateStatsProvider();
        void CleanUp();
        void Register(ISavedProgressReader savedProgressService);
    }
}