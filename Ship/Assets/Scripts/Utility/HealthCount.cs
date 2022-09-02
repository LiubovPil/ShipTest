using UnityEngine;
using UnityEngine.Events;
using ShipTest.Events;

namespace ShipTest.Utility
{
    public class HealthCount : MonoBehaviour
    {
        protected ZeroHealthEvent _zeroHealthEvent = new ZeroHealthEvent();

        private void Start()
        {
            EventManager.Instance.AddInvokerZeroHealthEvent(this);
        }
        public void AddListenerZeroHealthEvent(UnityAction<GameObject> listener)
        {
            _zeroHealthEvent.AddListener(listener);
        }
    }
}
