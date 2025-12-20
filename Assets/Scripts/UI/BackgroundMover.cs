using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class BackgroundMover : MonoBehaviour
    {
        [SerializeField] private List<Point> _pointsToMove;
        [SerializeField] private int _speed;

        private int _index = 0;

        private void Update()
        {
            if (_index == _pointsToMove.Count)
            {
                _index = 0;
            }

            transform.position = Vector3.MoveTowards(transform.position,
                _pointsToMove[_index].transform.position, _speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Point>(out Point point))
            {
                _index++;
            }
        }
    }
}