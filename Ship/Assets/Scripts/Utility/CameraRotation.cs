using UnityEngine;
using UnityEngine.InputSystem;

namespace ShipTest.Utility
{
    public class CameraRotation : MonoBehaviour
    {
        [Header("Speed of camera and player rotations")]
        [SerializeField] private float _cameraRotationYSpeed;
        [SerializeField] private float _cameraRotationXSpeed;

        [SerializeField] private float _newXRotation;
        [SerializeField] private float _newYRotation;

        [SerializeField] private Vector3 _rotation;

        private ShipTestController _shipTestController;

        private void Awake()
        {
            _shipTestController = new ShipTestController();
        }
        private void OnEnable()
        {
            _shipTestController.Camera.Rotation.Enable();
        }
        private void LateUpdate()
        {
            _newXRotation = (transform.rotation.eulerAngles.x - (_rotation.y * _cameraRotationYSpeed * Time.deltaTime));

            if (_newXRotation < 290 && _newXRotation >= 180)
            {
                _newXRotation = 290;
            }
            else if (_newXRotation > 70 && _newXRotation < 180)
            {
                _newXRotation = 70;
            }

            _newYRotation = (transform.rotation.eulerAngles.y + (_rotation.x * _cameraRotationXSpeed * Time.deltaTime));

            if (_newYRotation < 315 && _newYRotation >= 180)
            {
                _newYRotation = 315;
            }
            else if (_newYRotation > 45 && _newYRotation < 180)
            {
                _newYRotation = 45;
            }

            transform.rotation = Quaternion.Euler(_newXRotation, _newYRotation, transform.rotation.eulerAngles.z);
        }
        /// <summary>
        /// Is called from player Input (attached to the camera)
        /// </summary>
        /// <param name="inputValue"></param>
        private void OnRotation(InputValue inputValue)
        {
            _rotation = new Vector3(inputValue.Get<Vector2>().x, inputValue.Get<Vector2>().y, 0).normalized;
        }
        private void OnDisable()
        {
            _shipTestController.Camera.Rotation.Disable();
        }
    }
}
