using UnityEngine;

namespace ShipTest.Utility
{
    public interface IPooling 
    {
        public void OnEnter(string objectName, Vector3 startPosition);

        public string OnExit(); 
    }
}
