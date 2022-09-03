using System.Collections.Generic;
using UnityEngine;

namespace ShipTest.Gun
{
    public class GunChooser : MonoBehaviour
    {
        [Header("The list of available guns")]
        [SerializeField] private List<GunShoot> _guns;

        private ShipTestController _shipTestController;

        int _currentGunIndex = 0;
        private void Awake()
        {
            _shipTestController = new ShipTestController();
        }
        private void OnEnable()
        {
            _shipTestController.Gun.Choose.Enable();
        }
        /// <summary>
        /// Is called from player Input (attached to the player)
        /// </summary>
        private void OnChoose()
        {
            int gunsMaxIndex = _guns.Count - 1;

            if (++_currentGunIndex > gunsMaxIndex)
                _currentGunIndex = 0;

            _guns[_currentGunIndex].gameObject.SetActive(true);

            for (int i = 0; i < _guns.Count; i++)
            {
                if (_currentGunIndex != i)
                {
                    _guns[i].gameObject.SetActive(false);
                }
            }
        }
        private void OnDisable()
        {
            _shipTestController.Gun.Choose.Enable();
        }
    }
}
