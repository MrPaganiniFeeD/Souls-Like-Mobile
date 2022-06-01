using System;
using UnityEngine;

namespace DefaultNamespace.Bot.Data
{
    [Serializable]
    public struct FollowInfo : IFollowInfo
    {
        [SerializeField] private float _distance;

        public float Distance => _distance;
    }
}