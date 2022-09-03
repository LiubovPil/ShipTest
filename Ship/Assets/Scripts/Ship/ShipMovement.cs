using System.Collections.Generic;
using UnityEngine;
using ShipTest.Utility;

namespace ShipTest.Ship
{
    public class ShipMovement : MonoBehaviour, IPooling
    {
        [Header("The settings of movement")]
        [SerializeField] private List<Transform> _wayPoints;
        [SerializeField] private float _minShipSpeed;
        [SerializeField] private float _maxShipSpeed;

        private readonly float _offset = 0.3f;

        private bool _isReversed = false;

        private string _currentShipName;

        private float _currentShipSpeed;
        private int _currentWayPointIndex = 0;

        public string PoolingName
        {
            get { return _currentShipName; } 
        }

        private void FixedUpdate()
        {
            Move();
        }
        private void Move()
        {
            GoToNextPoint();
            transform.position = Vector3.MoveTowards(transform.position, 
                _wayPoints[_currentWayPointIndex].position, _currentShipSpeed);
        }
        private void GoToNextPoint()
        {
            Vector3 target = _wayPoints[_currentWayPointIndex].position;
            if (Vector3.Distance(transform.position, target) <= _offset)
            { 
                int wayPointMaxIndex = _wayPoints.Count - 1;
                if (!_isReversed)
                    ++_currentWayPointIndex;
                else
                    --_currentWayPointIndex;

                if (_currentWayPointIndex == wayPointMaxIndex)
                    _isReversed = true;
                else if (_currentWayPointIndex == 0)
                    _isReversed = false;
            }
        }
        public void OnEnter(string shipName, Vector3 startPosition)
        {
            transform.position = startPosition;
            _currentShipSpeed = Random.Range(_minShipSpeed, _maxShipSpeed);
            _currentShipName = shipName;
        }
    }
}
