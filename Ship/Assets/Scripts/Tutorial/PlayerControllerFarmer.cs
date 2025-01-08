using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class PlayerControllerFarmer : MonoBehaviour
    {
        [SerializeField] private GameObject projectile;
        [SerializeField] private float horizontalInput;
        [SerializeField] private float speed = 10.0f;
        [SerializeField] private float xRange = 10.0f;
        void Start()
        {
        
        }

        void Update()
        {
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }

            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectile, transform.position, projectile.transform.rotation);
            }
        }
    }
}
