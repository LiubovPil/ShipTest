using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest.Ship
{
    public class ShipMovement : MonoBehaviour
    {
        [SerializeField] private int _minShipSpeed;
        [SerializeField] private int _maxShipSpeed;

        private bool _isActivated = false;

        private string _currentShipName;

        private int _currentShipSpeed;

        private void FixedUpdate()
        {
            if(_isActivated)
                Move();
        }
        private void Move()
        {
            //MoveTowards until checkPoint
        }
        public void OnEnter(string shipName, Vector3 startPosition)
        {
            transform.position = startPosition;
            _currentShipSpeed = Random.Range(_minShipSpeed, _maxShipSpeed);
            _currentShipName = shipName;
            _isActivated = true;
        }
        public string OnExit()
        {
            _isActivated = false;
            return _currentShipName;
        }
    }
}
