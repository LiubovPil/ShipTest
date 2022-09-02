using UnityEngine;
using ShipTest.Utility;

namespace ShipTest.Gun
{
    public class GunShoot : Creator
    {
        protected readonly string _projectileName = "Projectile";

        private readonly Vector3 _offset = new Vector3(0f, 0.135f, 0.62f);

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
            CreateGameobject(_projectileName, transform.position + _offset);
        }
        private void OnDisable()
        {
            _shipTestController.Gun.Shoot.Enable();
        }
    }
}
