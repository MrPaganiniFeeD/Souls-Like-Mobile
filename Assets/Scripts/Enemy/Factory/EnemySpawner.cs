using Data;
using DefaultNamespace.Enemy.Factory;
using DefaultNamespace.Logic;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Enemy.Factory
{
    public class EnemySpawner : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private MonsterTypeId MonsterTypeId;

        [SerializeField] private bool _slain;
        private string _id;

        private void Awake() => 
            _id = GetComponent<UniqueId>().Id;

        public void LoadProgress(PlayerProgress playerProgress)
        {
            if (playerProgress.KillData.ClearedSpawners.Contains(_id))
                _slain = true;
            else
                Spawn();
        }

        private void Spawn()
        {
            ;
        }
        public void UpdateProgress(PlayerProgress playerProgress)
        {
            if (_slain)
                playerProgress.KillData.ClearedSpawners.Add(_id);
        }
    }
}