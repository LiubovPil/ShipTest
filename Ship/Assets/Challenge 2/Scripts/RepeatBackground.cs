using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class RepeatBackground : MonoBehaviour
    {
        private Vector3 startPos;
        private float width;
        // Start is called before the first frame update
        void Start()
        {
            startPos = transform.position;
            width = GetComponent<BoxCollider>().size.x; 
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x < startPos.x - width / 2)
            {
                transform.position = startPos;
            }
        }
    }
}
