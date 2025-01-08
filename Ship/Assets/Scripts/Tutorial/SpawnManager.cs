using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] items;
        [SerializeField] private float zRange = 8.0f;
        [SerializeField] private float yPos = 16.0f;
        [SerializeField] private float startInterval = 2.0f;
        [SerializeField] private float spawnInterval = 1.5f;

        private void Start()
        {
            InvokeRepeating("SpawnRandomItem", startInterval, spawnInterval);
        }

        private void SpawnRandomItem()
        {
            Vector3 pos = new Vector3(0.0f, yPos, Random.Range(-zRange, zRange));
            int index = Random.Range(0, items.Length);
            Instantiate(items[index], pos, items[index].transform.rotation);
        }

        public void Stop()
        {
            CancelInvoke("SpawnRandomItem");
        }
    }
}
