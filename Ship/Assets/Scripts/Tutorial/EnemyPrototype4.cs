using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class EnemyPrototype4 : MonoBehaviour
    {
        [SerializeField] private float speed = 3.0f;
        private Rigidbody enemyRB;
        private GameObject player;
        void Start()
        {
            enemyRB = GetComponent<Rigidbody>();
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRB.AddForce(lookDirection * speed);

            if (transform.position.y < -2.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
