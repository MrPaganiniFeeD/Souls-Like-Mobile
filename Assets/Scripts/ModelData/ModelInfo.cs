using System;
using UnityEngine;

namespace DefaultNamespace.ModelData
{
    [Serializable]
    public class ModelInfo : IModelInfo
    {
        [SerializeField] private bool _isNacktModelUnload = false;
        [SerializeField] private string[] _modelsName;

        public bool IsNacktModelUnload => _isNacktModelUnload;
        public string[] Names => _modelsName;
    }
}