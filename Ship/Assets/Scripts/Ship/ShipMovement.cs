using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest.Ship
{
    public class ShipMovement : MonoBehaviour
    {
        private bool _isActivated = false; 
        private int _shipSpeed;

        private void FixedUpdate()
        {
            if(_isActivated)
                Move();
        }
        private void Move()
        {

        }
        public void OnEnter(ShipData shipData)
        {
            _isActivated = true;
            _shipSpeed = shipData.Speed;
        }
        public void OnExit()
        {
            _isActivated = false;
        }
    }
}
