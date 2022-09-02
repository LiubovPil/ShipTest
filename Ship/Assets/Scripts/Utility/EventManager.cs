using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ShipTest.Ship;
using ShipTest.Projectile;

namespace ShipTest.Utility
{
    public class EventManager : MonoBehaviour
    {
        private static EventManager _instance = null;

        private List<HealthCount> _invokersZeroHealthEvent = new List<HealthCount>();
        private List<UnityAction<GameObject>> _listenersZeroHealthEvent = new List<UnityAction<GameObject>>();

        public static EventManager Instance
        {
            get
            {
                if (!_instance)
                {
                    Debug.LogError("EventManager isn't exist");
                }
                return _instance;
            }
        }
        private void Awake()
        {
            if (_instance == null)
                _instance = this;
        }
        public void AddInvokerZeroHealthEvent(HealthCount invoker)
        {
            _invokersZeroHealthEvent.Add(invoker);

            foreach (UnityAction<GameObject> listener in _listenersZeroHealthEvent)
                invoker.AddListenerZeroHealthEvent(listener);
        }
        public void AddListenerZeroHealthEvent(UnityAction<GameObject> listener)
        {
            _listenersZeroHealthEvent.Add(listener);

            foreach (HealthCount invoker in _invokersZeroHealthEvent)
                invoker.AddListenerZeroHealthEvent(listener);
        }
    }
}
