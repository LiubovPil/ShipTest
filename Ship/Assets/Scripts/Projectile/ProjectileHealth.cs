using UnityEngine;
using ShipTest.Utility;


namespace ShipTest.Projectile
{
    [RequireComponent(typeof(Timer))]
    public class ProjectileHealth : HealthCount
    {
        [SerializeField]
        private int _projectileLifetime; 

        private Timer _projectileTimer;
        private void OnEnable()
        {
            _projectileTimer = GetComponent<Timer>();

            _projectileTimer.Duration = _projectileLifetime;
            _projectileTimer.Run();
        }
        private void Update()
        {
            if (_projectileTimer.Finished)
                _zeroHealthEvent.Invoke(gameObject);
        }
    }
}
