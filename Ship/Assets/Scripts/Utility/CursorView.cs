using UnityEngine;

namespace ShipTest.Utility
{
    public class CursorView : MonoBehaviour
    {
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
