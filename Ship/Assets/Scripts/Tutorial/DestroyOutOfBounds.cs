using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class DestroyOutOfBounds : MonoBehaviour
    {
        [SerializeField] private float topBound = 30.0f;
        [SerializeField] private float lowerBound = -15.0f;
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.z > topBound || transform.position.z < lowerBound)
            {
                Destroy(gameObject);
            }
        }
    }
}
