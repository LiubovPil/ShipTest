using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ShipTest
{
    public class Ground : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Food") || collision.gameObject.CompareTag("Bad"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
