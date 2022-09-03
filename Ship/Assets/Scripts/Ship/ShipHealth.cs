using UnityEngine;
using ShipTest.Utility;

namespace ShipTest.Ship
{
    public class ShipHealth : HealthCount
    {
        [SerializeField] private int _shipHealth;

        private int _healthCount;

        private void OnEnable()
        {
            _healthCount = _shipHealth;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                if (--_healthCount == 0)
                    _zeroHealthEvent.Invoke(gameObject);
            }
        }
    }
}
