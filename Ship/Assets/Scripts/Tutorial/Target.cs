using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class Target : MonoBehaviour
    {
        private GameManagerPrototype5 gameManager;

        [SerializeField] private int pointValue = 10;

        [SerializeField] private ParticleSystem particle;

        private Rigidbody rb;

        private float minSpeed = 12.0f;
        private float maxSpeed = 16.0f;
        private float maxTorque = 10.0f;
        private float xRange = 4;
        private float ySpawnPos = -2;
        void Start()
        {
            rb = GetComponent<Rigidbody>();

            rb.AddForce(RandomForce(), ForceMode.Impulse);

            rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

            gameManager = GameObject.Find("GameManager").GetComponent<GameManagerPrototype5>();

            transform.position = RandomSpawnPos();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private Vector3 RandomForce()
        {
            return Vector3.up * Random.Range(minSpeed, maxSpeed);
        }

        private float RandomTorque()
        {
            return Random.Range(-maxTorque, maxTorque);
        }

        private Vector3 RandomSpawnPos()
        {
            return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
        }

        private void OnMouseDown()
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(particle, transform.position, particle.transform.rotation);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Sensor")
            {
                Destroy(gameObject);
                if (!gameObject.CompareTag("Bad"))
                {
                    gameManager.GameOver();
                }
            }
        }
    }
}
