using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class RotatePropeller : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 10.0f;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
