using UnityEngine;
using ShipTest.Utility;

namespace ShipTest.Gun
{
    public class GunShoot : Creator
    {
        [SerializeField] protected Transform _shotPosition; 

        protected readonly string _projectileName = "Projectile";

        private ShipTestController _shipTestController;
        private void OnEnable()
        {
            _shipTestController = new ShipTestController();

            _shipTestController.Gun.Shoot.Enable();
        }
        /// <summary>
        /// Is called from player Input (attached to the each gun)
        /// </summary>
        protected virtual void OnShoot()
        {
            CreateGameobject(_projectileName, _shotPosition.position);
        }
        private void OnDisable()
        {
            _shipTestController.Gun.Shoot.Enable();
        }
    }
}
