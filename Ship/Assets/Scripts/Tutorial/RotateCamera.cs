using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class RotateCamera : MonoBehaviour
    {
        [SerializeField] private float speed = 30.0f;
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);
        }
    }
}
