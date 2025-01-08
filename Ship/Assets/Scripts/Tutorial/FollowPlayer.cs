using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private Vector3 offset;

        void LateUpdate()
        {
            transform.position = player.transform.position + offset;
        }
    }
}
