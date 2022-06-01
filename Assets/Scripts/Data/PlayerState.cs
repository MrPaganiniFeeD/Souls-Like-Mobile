using System;
using PlayerLogic.Stats;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlayerState
    {
        public PlayerStats PlayerStats;

        public PlayerState(IStatsProvider statsProvider)
        {
            PlayerStats = statsProvider.GetStats();
            PlayerStats.ShowInfoStats();
        }
    }
}