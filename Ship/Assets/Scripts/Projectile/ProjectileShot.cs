using ShipTest.Utility;
using UnityEngine;

namespace ShipTest.Projectile
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    public class ProjectileShot : MonoBehaviour, IPooling
    {
        [Header("Projectile settings")]
        [SerializeField] private int _projectileSpeed;
        [SerializeField] private int _projectileDistance;
        [SerializeField] private Vector3 _velocity;

        private readonly Vector3 _aimCenter = new Vector3(0.5f, 0.5f, 0f);

        private Rigidbody _projectileRigidbody;

        private string _projectaleName = "Projectile";

        public string PoolingName
        {
            get { return _projectaleName; }
        }

        private void OnEnable()
        {
            _projectileRigidbody = GetComponent<Rigidbody>();
        }
        public void OnEnter(string projectileName, Vector3 startPosition)
        {
            _projectaleName = projectileName;

            transform.position = startPosition;

            _projectileRigidbody.velocity = Vector3.zero;
            _projectileRigidbody.angularVelocity = Vector3.zero;

            RaycastHit hitInformation;
            Vector3 projectileGoal;
            Vector3 projectileDirection;

            Ray ray = Camera.main.ViewportPointToRay(_aimCenter);

            if (Physics.Raycast(ray, out hitInformation))
                projectileGoal = hitInformation.point;
            else
                projectileGoal = ray.GetPoint(transform.position.z + _projectileDistance);

            projectileDirection = projectileGoal - transform.position;

            _projectileRigidbody.AddForce
            (projectileDirection.normalized * _projectileSpeed, ForceMode.Impulse);
        }
    }
}
