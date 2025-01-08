using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class PlayerControllerLab : MonoBehaviour
    {
        public float gravityModifier = 1.5f;
        public float speed = 5.0f;
        public float turnSpeed = 5.0f;

        public float zbound = 6.0f;

        private Rigidbody playerRb;
        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;
        }

        // Update is called once per frame
        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            playerRb.AddForce(Vector3.forward * speed * verticalInput);
            playerRb.AddForce(Vector3.right * turnSpeed * horizontalInput);

            if (transform.position.z < -zbound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, - transform.position.z);
            }
            if (transform.position.z > zbound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {

            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Powerup"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
