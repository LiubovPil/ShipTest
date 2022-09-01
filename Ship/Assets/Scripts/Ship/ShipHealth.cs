using UnityEngine;
using UnityEngine.Events;
using ShipTest.Events;
using ShipTest.Utility;

namespace ShipTest
{
    public class ShipHealth : MonoBehaviour
    {
        [SerializeField] private int _shipHealth;

        private DestroyShipEvent _destroyShipEvent = new DestroyShipEvent();

        private void Start()
        {
            EventManager.Instance.AddInvokerChangeHealthEvent(this);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Projectile"))
            {
                if (--_shipHealth == 0)
                {
                    _destroyShipEvent.Invoke(gameObject);
                }
            }
        }
        public void AddListenerDestroyShipEvent(UnityAction<GameObject> listener)
        {
            _destroyShipEvent.AddListener(listener);
        }
    }
}
