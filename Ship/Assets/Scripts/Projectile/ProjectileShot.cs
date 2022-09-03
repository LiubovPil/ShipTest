using ShipTest.Utility;
using UnityEngine;

namespace ShipTest.Projectile
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    public class ProjectileShot : MonoBehaviour, IPooling
    {
        [Header("Projectile settings")]
        [SerializeField] private int _projectileDistance;
        [SerializeField] private int _projectileSpeed;

        private readonly Vector3 _aimCenter = new Vector3(0.5f, 0.5f, 0f);

        private Rigidbody _projectileRigidbody;

        private string _projectaleName;

        private void Awake()
        {
            _projectileRigidbody = GetComponent<Rigidbody>();
        }
        public void OnEnter(string projectileName, Vector3 startPosition)
        {
            _projectaleName = projectileName;

            transform.position = startPosition;

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
        public string OnExit()
        {
            _projectileRigidbody.velocity = new Vector3(0f, 0f, 0f);
            _projectileRigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
            return _projectaleName;
        }
    }
}
