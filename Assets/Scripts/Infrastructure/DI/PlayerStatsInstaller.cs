using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using PlayerLogic.Stats;
using UnityEngine;
using Zenject;

public class PlayerStatsInstaller : MonoInstaller
{
    private IStatsProvider _statsProvider;
    private PlayerStats _playerStats;
    public override void InstallBindings()
    {
        BindPlayerStats();
    }

    private void BindPlayerStats()
    {
        _statsProvider = new ClassStats(ClassType.Warrior);
        _playerStats = _statsProvider.GetStats();
        Container.Bind<PlayerStats>().FromInstance(_playerStats).AsSingle();
    }
}
