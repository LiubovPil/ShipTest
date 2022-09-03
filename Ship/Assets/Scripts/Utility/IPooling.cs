using UnityEngine;

namespace ShipTest.Utility
{
    public interface IPooling 
    {
        public string PoolingName { get; }
        public void OnEnter(string objectName, Vector3 startPosition);
    }
}
