using System.Collections.Generic;
using UnityEngine;
using ShipTest.Utility;

namespace ShipTest.Ship
{
    public class ShipSpawner : MonoBehaviour
    {
        [SerializeField]
        private List<ShipData> _listOfShips;

        private Timer _spawnShipTimer;

        private int _maxNumShip;
        private int _countShip;

        private void Awake()
        {
            _spawnShipTimer = GetComponent<Timer>();
        }
        private void Update()
        {
            
        }
        private void SpawnShip()
        {
            int indexShip = Random.Range(0, _listOfShips.Count);

        }
            
    }
}
