using UnityEngine;
using ShipTest.Utility;
using ShipTest.Pooler;

namespace ShipTest.Ship
{
    public class ShipSpawner : MonoBehaviour
    {
        [SerializeField] private int _minSpawnShipTime;
        [SerializeField] private int _maxSpawnShipTime;
        [SerializeField] private int _maxNumShip;
        [SerializeField] private int _layerMask;

        private Timer _spawnShipTimer;

        private string[] _shipNames = System.Enum.GetNames(typeof(ShipName));

        private bool _retrySpawnShip = false;

        private int _countShip = 0;

        private void Awake()
        {
            _spawnShipTimer = GetComponent<Timer>();

            ConfigurateTimer();
        }
        private void Start()
        {
            EventManager.Instance.AddListenerChangeHealthEvent(ReturnShip);
        }
        private void Update()
        {
            if (_spawnShipTimer.Finished || _retrySpawnShip)
                SpawnShip();
        }
        private void ConfigurateTimer()
        {
            int spawnShipTime = Random.Range(_minSpawnShipTime, _maxSpawnShipTime);
            Debug.Log("Duration " + spawnShipTime);
            _spawnShipTimer.Duration = spawnShipTime;
            _spawnShipTimer.Run();
        }
        private void SpawnShip()
        {
            if ((Physics.OverlapSphere(transform.position, 1.0f, _layerMask)).Length == 0)
            {
                if (_countShip < _maxNumShip)
                {
                    _retrySpawnShip = false;
                    int indexShip = Random.Range(0, _shipNames.Length);

                    GameObject ship = PoolerController.Instance.GetFromPool(_shipNames[indexShip]);
                    ship.SetActive(true);
                    ship.GetComponent<ShipMovement>().OnEnter(_shipNames[indexShip], transform.position);

                    _countShip++;
                    ConfigurateTimer();
                }
                else
                {
                    ConfigurateTimer();
                    Debug.Log("Not more");
                }
            }
            else
                _retrySpawnShip = true;
        }
        private void ReturnShip(GameObject _ship)
        {
            _countShip--;
            string shipName = _ship.GetComponent<ShipMovement>().OnExit();
            PoolerController.Instance.ReturnToPool(_ship, shipName);
        }    
    }
}
