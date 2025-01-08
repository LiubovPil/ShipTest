using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class PlayerControllerPrototype4 : MonoBehaviour
    {
        [SerializeField] private GameObject indicator;
        [SerializeField] private Vector3 indicatorOffet = new(0f, -0.45f, 0f);

        [SerializeField] private float speed = 5.0f;
        private Rigidbody plRigidbody;
        private GameObject focalPoint;

        [SerializeField] private float powerupStrenght = 15.0f;
        [SerializeField] private float powerupTime = 7.0f;
        private bool hasPowerup = false;
        void Start()
        {
            plRigidbody = GetComponent<Rigidbody>();
            focalPoint = GameObject.Find("FocalPoint");
            indicator.SetActive(hasPowerup);
        }

        // Update is called once per frame
        void Update()
        {
            float verticalInput = Input.GetAxis("Vertical");
            plRigidbody.AddForce(focalPoint.transform.forward * verticalInput * speed);

            indicator.transform.position = transform.position + indicatorOffet;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Powerup"))
            {
                hasPowerup = true;
                indicator.SetActive(hasPowerup);
                Destroy(other.gameObject);
                StartCoroutine(CountDownPowerup());
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
            {
                Rigidbody rbEnemy = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = rbEnemy.transform.position - transform.position;
                rbEnemy.AddForce(awayFromPlayer * powerupStrenght, ForceMode.Impulse);
            }
        }

        IEnumerator CountDownPowerup()
        {
            yield return new WaitForSeconds(powerupTime);
            hasPowerup = false;
            indicator.SetActive(hasPowerup);
        }
    }
}
