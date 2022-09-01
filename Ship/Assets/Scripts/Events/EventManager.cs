using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest.Event
{
    public class EventManager : MonoBehaviour
    {
        private static EventManager _instance = null;

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
    }
}
