using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Tutorial
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;
        [SerializeField] private TextMeshProUGUI rpmtext;

        [SerializeField] private List<WheelCollider> allWheels = new();

        [SerializeField] private GameObject centerOfMass;
        [SerializeField] private float speed;
        [SerializeField] private float rpm;
        [SerializeField] private float turnSpeed = 20.0f;
        [SerializeField] private float horseForce = 1.0f;

        private Rigidbody rb;

        private int wheelsOnGround;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = centerOfMass.transform.position;
        }

        void FixedUpdate()
        {
            //Move the vehicle forward
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (IsOnGround())
            {
                //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
                rb.AddRelativeForce(Vector3.forward * horseForce * verticalInput);
                speed = Mathf.RoundToInt(rb.velocity.magnitude * 2.237f);
                rpm = Mathf.RoundToInt((speed % 30) * 40);
                textMeshProUGUI.SetText("Speed: " + speed.ToString());
                rpmtext.SetText("RPM: " + rpm.ToString());

                transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
            }
        }

        bool IsOnGround()
        {
            wheelsOnGround = 0;
            foreach (WheelCollider wheel in allWheels)
            {
                if (wheel.isGrounded)
                {
                    wheelsOnGround++;
                }
            }
            if (wheelsOnGround == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
