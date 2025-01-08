using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ShipTest
{
    public class SpawnManagerLab : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemies;
        [SerializeField] private GameObject powerup;

        private float zEnemySpawn = 12.0f;
        private float xSpawnRange = 16.0f;
        private float zPowerupRange = 5.0f;
        private float ySpawn = 0.65f;

        private float enemySpawnTime = 5.0f;
        private float powerupSpawnTime = 1.0f;
        private float startDelay = 1.0f;
        void Start()
        {
            InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
            InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void SpawnEnemy()
        {
            float xPos = Random.Range(-xSpawnRange, xSpawnRange);
            int index = Random.Range(0, enemies.Length);

            Vector3 spawnPos = new (xPos, ySpawn, zEnemySpawn);
            Instantiate(enemies[index], spawnPos, enemies[index].transform.rotation);
        }

        void SpawnPowerup()
        {
            float xPos = Random.Range(-xSpawnRange, xSpawnRange);
            float zPos = Random.Range(-zPowerupRange, zPowerupRange);

            Vector3 spawnPos = new(xPos, ySpawn, zPos);
            Instantiate(powerup, spawnPos, powerup.transform.rotation);
        }
    }
}
