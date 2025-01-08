using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private float horizontalInput;
        [SerializeField] private float speed = 10.0f;
        [SerializeField] private float bound = 10.0f;

        void Update()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            Vector3 newPos = Vector3.forward * horizontalInput * Time.deltaTime * speed;
            if (transform.position.z + newPos.z < bound && transform.position.z + newPos.z > -bound)
            {
                transform.Translate(newPos);
            }
        }
    }
}
