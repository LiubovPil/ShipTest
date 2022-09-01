using UnityEngine;

namespace ShipTest.Ship
{
    [CreateAssetMenu(fileName = "New ShipData", menuName = "Ship Data")]
    public class ShipData : ScriptableObject
    {
        #region Field
        [SerializeField] private GameObject _shipPrefab;
        [SerializeField] private int _speed;
        [SerializeField] private int _health;
        #endregion

        #region Properties
        public GameObject ShipPrefab
        {
            get { return _shipPrefab; }
            set { _shipPrefab = value; }
        }
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        #endregion
    }
}
