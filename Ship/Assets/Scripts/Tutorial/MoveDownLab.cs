using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ShipTest
{
    public class MoveDownLab : MonoBehaviour
    {
        [SerializeField] private float speed = 3.5f;
        [SerializeField] private float limitZ = -10.0f;

        private Rigidbody objectRB;

        void Start()
        {
            objectRB = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            objectRB.AddForce(Vector3.forward * -speed);  
            if (transform.position.z < limitZ)
            {
                Destroy(gameObject);
            }
        }
    }
}
