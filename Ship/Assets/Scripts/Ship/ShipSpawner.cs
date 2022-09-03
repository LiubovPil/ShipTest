using UnityEngine;
using ShipTest.Utility;
using ShipTest.Pooler;

namespace ShipTest.Ship
{
    public class ShipSpawner : Creator
    {
        [SerializeField] private LayerMask _shipLayerMask;
        [Header("The settings of spawn")]
        [SerializeField] private int _minSpawnShipTime;
        [SerializeField] private int _maxSpawnShipTime;
        [SerializeField] private int _maxNumShip = 7;
        [SerializeField] private int _countShip = 0;

        private readonly string[] _shipNames = System.Enum.GetNames(typeof(ShipName));

        private Timer _spawnShipTimer;

        private bool _retrySpawnShip = false;

        private void Awake()
        {
            _spawnShipTimer = GetComponent<Timer>();

            ConfigurateTimer();
        }
        private void Update()
        {
            if (_spawnShipTimer.Finished || _retrySpawnShip)
                SpawnShip();
        }
        private void ConfigurateTimer()
        {
            int spawnShipTime = Random.Range(_minSpawnShipTime, _maxSpawnShipTime);
            _spawnShipTimer.Duration = spawnShipTime;
            _spawnShipTimer.Run();
        }
        private void SpawnShip()
        {
            if ((Physics.OverlapSphere(transform.position, 1.0f, _shipLayerMask)).Length == 0)
            {
                if (_countShip < _maxNumShip)
                {
                    _retrySpawnShip = false;
                    int indexShip = Random.Range(0, _shipNames.Length);

                    CreateGameobject(_shipNames[indexShip], transform.position);

                    _countShip++;
                    ConfigurateTimer();
                }
                else
                {
                    ConfigurateTimer();
                    Debug.LogWarning("Not more space in the scene");
                }
            }
            else
                _retrySpawnShip = true;
        }
        protected override void ReturnGameobject(GameObject _ship)
        {
            if(_ship.CompareTag("Ship"))
                _countShip--;
            base.ReturnGameobject(_ship);
        }    
    }
}
