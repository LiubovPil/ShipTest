using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class MoveLeft : MonoBehaviour
    {
        [SerializeField] private float speed = 30.0f;
        [SerializeField] private float leftBound = -15.0f;

        private PlayerControllerPrototype3 playerController;

        private void Start()
        {
            playerController = GameObject.Find("Player").GetComponent<PlayerControllerPrototype3>();
        }
        void Update()
        {
            if (!playerController.GameOver)
            {
                transform.Translate(speed * Time.deltaTime * Vector3.left);
            }

            if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
    }
}