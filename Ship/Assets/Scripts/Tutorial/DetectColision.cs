using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class DetectColision : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
