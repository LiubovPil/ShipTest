using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest
{
    public class PlayerControllerPrototype3 : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosionParticle;
        [SerializeField] private ParticleSystem dirtParticle;

        [SerializeField] private AudioClip jumpSound;
        [SerializeField] private AudioClip crashSound;

        [SerializeField] private float jumpForce = 10.0f;
        [SerializeField] private float gravityModifier = 1.0f;

        [SerializeField] private bool isOnGround;

        public bool GameOver;

        private Rigidbody playerRb;
        private Animator animator;
        private AudioSource audioSource;

        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;

            animator = GetComponent<Animator>();

            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                animator.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                audioSource.PlayOneShot(jumpSound, 1.0f);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
                dirtParticle.Play();
            }
            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                explosionParticle.Play();
                dirtParticle.Stop();
                audioSource.PlayOneShot(crashSound, 1.0f);

                GameOver = true;
                animator.SetBool("Death_b", true);
                animator.SetInteger("DeathType_int", 1);
            }
        }
    }
}
