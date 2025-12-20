using System;
using System.Collections;
using UnityEngine;

namespace CustomerStuff
{
    public class CustomerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody _rigidbody;

        private Vector3 _wantedPosition;
        private Transform _transform;

        public event Action SetOnSpot;

        private void Awake()
        {
            _transform = transform;
        }

        public void SetPosition(Vector3 position)
        {
            _wantedPosition = position;
        }

        public IEnumerator Move()
        {
            while (enabled)
            {
                _transform.position = Vector3.MoveTowards(_transform.position, _wantedPosition, _speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<CustomerStopPoint>())
            {
                _transform.rotation = Quaternion.Euler(19.5f, -141.7f, 0);
                SetOnSpot?.Invoke();
            }
        }
    }
}