using UnityEngine;
using ShipTest.Utility;

namespace ShipTest.Ship
{
    public class ShipHealth : HealthCount
    {
        [SerializeField] private int _shipHealth;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Projectile"))
            {
                if (--_shipHealth == 0)
                    _zeroHealthEvent.Invoke(gameObject);
            }
        }
    }
}
