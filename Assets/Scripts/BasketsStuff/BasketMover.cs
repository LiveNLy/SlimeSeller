using UnityEngine;

namespace BasketsStuff
{
    public class BasketMover : MonoBehaviour
    {
        [SerializeField] private float _standartSpeed = 20;
        [SerializeField] private float _standartRotationSpeed = 10;

        private Quaternion _standartRotationPosition;
        private Transform _transform;
        private float _speed;
        private float _rotationSpeed;

        private void Awake()
        {
            _transform = transform;
            _standartRotationPosition = _transform.rotation;
            SetStandartValues();
        }

        public void Move(Vector3 targetPosition)
        {
            Vector3 direction = (targetPosition - _transform.position).normalized;
            float angle = direction.x * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            _transform.position = Vector3.MoveTowards(_transform.position, targetPosition, _speed * Time.deltaTime);
        }

        public void SetStandartValues()
        {
            _speed = _standartSpeed;
            _rotationSpeed = _standartRotationSpeed;
        }

        public void SetStandartRotation()
        {
            _transform.rotation = _standartRotationPosition;
        }
    }
}