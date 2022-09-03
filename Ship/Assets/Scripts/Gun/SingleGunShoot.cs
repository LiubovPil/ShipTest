using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShipTest.Utility;

namespace ShipTest.Gun
{
    public class SingleGunShoot : GunShoot
    {
        [SerializeField] private int _rechargeTime;
        
        private Timer _singleGunShootTimer;

        private bool _isActive = true;
        private void Awake()
        {
            _singleGunShootTimer = GetComponent<Timer>();
            _singleGunShootTimer.Duration = _rechargeTime;
            _singleGunShootTimer.Run();
        }
        private void Update()
        {
            if (_singleGunShootTimer.Finished)
                _isActive = true;
        }
        /// <summary>
        /// Is called from player Input (attached to the each gun)
        /// </summary>
        protected override void OnShoot()
        {
            if (_isActive)
            {
                base.OnShoot();
                _isActive = false;
                _singleGunShootTimer.Run();
            }
        }
    }
}
