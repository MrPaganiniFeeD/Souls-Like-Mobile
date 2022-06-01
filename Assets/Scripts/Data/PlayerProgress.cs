using System;
using PlayerLogic.Stats;

namespace Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;
        public KillData KillData;
        public PlayerState PlayerState;
        

        public PlayerProgress(string initialLevel, IStatsProvider statsProvider)
        {
            WorldData = new WorldData(initialLevel);
            PlayerState = new PlayerState(statsProvider);
            KillData = new KillData();
        }
    }
}