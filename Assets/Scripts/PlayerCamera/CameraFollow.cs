using UnityEngine;
using Zenject;

namespace PlayerCamera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _selfTransform;
        [SerializeField] private float _smooth;
        private Transform _target;

        private Vector3 _offset;
        
        public void Construct(Transform target)
        {
            Debug.Log("cameraFollow construct");
            _target = target;
            _offset = _selfTransform.position - _target.position;
        }
        private void Follow()
        {
            Vector3 newPosition = _target.position + _offset;
            _selfTransform.position = Vector3.Lerp(_selfTransform.position, newPosition, _smooth * Time.deltaTime);
        }
        private void LateUpdate()
        {
            Follow();
        }
    }
}
