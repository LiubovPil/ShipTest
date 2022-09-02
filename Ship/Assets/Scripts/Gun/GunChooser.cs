using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipTest.Gun
{
    public class GunChooser : MonoBehaviour
    {
        [Header("The list of available guns")]
        [SerializeField] private List<GunShoot> _guns;

        private ShipTestController _shipTestController;

        private void OnEnable()
        {
            _shipTestController.Gun.Choose.Enable();
        }
        /// <summary>
        /// Is called from player Input (attached to the player)
        /// </summary>
        private void OnChoose()
        {

        }

        /*    public void GoToNextWeapon()
    {
        List<Gun> availableGuns = guns.Where(item => item.available == true).ToList();
        int maximumAvailableGunIndex = availableGuns.Count - 1;
        int equippedAvailableGunIndex = availableGuns.IndexOf(guns[equippedGunIndex]);

        equippedAvailableGunIndex += 1;
        if (equippedAvailableGunIndex > maximumAvailableGunIndex)
        {
            equippedAvailableGunIndex = 0;
        }

        EquipGun(guns.IndexOf(availableGuns[equippedAvailableGunIndex]));
    }
         
         public void EquipGun(int gunIndex)
        {
            equippedGunIndex = gunIndex;
            guns[equippedGunIndex].gameObject.SetActive(true);
            for (int i = 0; i < guns.Count; i++)
            {
                if (equippedGunIndex != i)
                {
                    guns[i].gameObject.SetActive(false);
                }
            }
            GameManager.UpdateUIElements();
        }*/
        private void OnDisable()
        {
            _shipTestController.Gun.Choose.Enable();
        }
    }
}
