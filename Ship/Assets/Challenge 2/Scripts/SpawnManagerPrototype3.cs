using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class SpawnManagerPrototype3 : MonoBehaviour
    {
        [SerializeField] private GameObject obstaclePrefabs;

        private PlayerControllerPrototype3 playerController;

        private Vector3 spawnPos = new(25.0f, 0.0f, 0.0f);

        private float startDelay = 2.0f;
        private float repeatRate = 2.0f;
        // Start is called before the first frame update
        void Start()
        {
            playerController = GameObject.Find("Player").GetComponent<PlayerControllerPrototype3>();
            InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SpawnObstacle()
        {
            if (!playerController.GameOver)
            {
                Instantiate(obstaclePrefabs, spawnPos, obstaclePrefabs.transform.rotation);
            }
        }
    }
}
