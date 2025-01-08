using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class SpawnManagerPrototype4 : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        [SerializeField] private GameObject powerup;
        [SerializeField] private float range = 9.0f;

        private int waveCount = 1;
        private int enemyCount = 0;
        void Start()
        {
            SpawnEnemyWave(waveCount);

            Instantiate(powerup, GenerateRandomPosition(), enemy.transform.rotation);
        }

        // Update is called once per frame
        void Update()
        {
            enemyCount = FindObjectsOfType<EnemyPrototype4>().Length;
            if (enemyCount == 0)
            {
                waveCount++;
                SpawnEnemyWave(waveCount);
                Instantiate(powerup, GenerateRandomPosition(), enemy.transform.rotation);
            }
        }

        private Vector3 GenerateRandomPosition()
        {
            float randomX = Random.Range(-range, range);
            float randomZ = Random.Range(-range, range);
            return new Vector3(randomX, 0, randomZ);
        }

        private void SpawnEnemyWave(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Instantiate(enemy, GenerateRandomPosition(), enemy.transform.rotation);
            }
        }
    }
}
