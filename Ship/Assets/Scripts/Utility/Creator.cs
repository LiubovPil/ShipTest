using UnityEngine;
using ShipTest.Pooler;

namespace ShipTest.Utility
{
    public class Creator : MonoBehaviour
    {
        private void Start()
        {
            EventManager.Instance.AddListenerZeroHealthEvent(ReturnGameobject);
        }
        protected virtual void CreateGameobject(string gameObjectName, Vector3 startPosition)
        {
            GameObject gameObject = PoolerController.Instance.GetFromPool(gameObjectName);
            gameObject.SetActive(true);
            gameObject.GetComponent<IPooling>().OnEnter(gameObjectName, startPosition);
        }
        protected virtual void ReturnGameobject(GameObject gameObject)
        {
            string gameObjectName = gameObject.GetComponent<IPooling>().OnExit();
            PoolerController.Instance.ReturnToPool(gameObject, gameObjectName);
        }
    }
}
