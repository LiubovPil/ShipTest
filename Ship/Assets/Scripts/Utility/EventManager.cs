using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ShipTest.Utility
{
    public class EventManager : MonoBehaviour
    {
        private static EventManager _instance = null;

        private List<ShipHealth> _invokersDestroyShipEvent = new List<ShipHealth>();
        private List<UnityAction<GameObject>> _listenersDestroyShipEvent = new List<UnityAction<GameObject>>();

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
        public void AddInvokerChangeHealthEvent(ShipHealth invoker)
        {
            _invokersDestroyShipEvent.Add(invoker);

            foreach (UnityAction<GameObject> listener in _listenersDestroyShipEvent)
                invoker.AddListenerDestroyShipEvent(listener);
        }
        public void AddListenerChangeHealthEvent(UnityAction<GameObject> listener)
        {
            _listenersDestroyShipEvent.Add(listener);

            foreach (ShipHealth invoker in _invokersDestroyShipEvent)
                invoker.AddListenerDestroyShipEvent(listener);
        }
    }
}
