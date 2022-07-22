using Astroboy.Stats;
using Astroboy.Utils;
using UnityEngine;

namespace Astroboy.Player.Gun
{
    public class GunController : MonoBehaviour
    {
        [SerializeField]
        private Camera cam;
        [SerializeField]
        public Transform sight;

        [Header("Param")]
        [SerializeField]
        private int damage = 10;
        [SerializeField]
        private float range = 100f;
        [SerializeField]
        private float fireRate = 15f;
        [SerializeField]
        private float impactForce = 30f;
        [SerializeField]
        private float speed = 15f;
        [SerializeField]
        private float arcRange = 15f;

        private static PoolingObject poolComponent;

        private Vector3 projectileDestination = Vector3.zero;
        private float nextTimeToFire = 0f;

        #region Pool
        private const string projectileTag = "Projectile";
        private const string enemyTag = "Enemy";
        private const string poolTag = "Pool";
        #endregion

        private void Start()
        {
            poolComponent = PoolingObject.Instance;
        }

        void Update()
        {
            if (Input.GetKeyDown("space") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }

        public void Shoot()
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                if (hit.transform.tag == enemyTag)
                {
                    EnemyStats stats = hit.transform.GetComponent<EnemyStats>();
                    if (stats != null) stats.TakeDamage(damage);
                }

                projectileDestination = hit.point;
            }
            else
            { 
                projectileDestination = ray.GetPoint(1000);
            }

            SpawnProjectile();
        }

        private void SpawnProjectile()
        {
            GameObject proj = poolComponent.Spawn(projectileTag, Vector3.zero, Quaternion.identity);
            proj.GetComponent<Rigidbody>().velocity = (projectileDestination + sight.position).normalized * speed;

            //iTween.PunchPosition(proj, new Vector3(UnityEngine.Random.Range(-arcRange, arcRange), UnityEngine.Random.Range(-arcRange, arcRange), UnityEngine.Random.Range(-arcRange, arcRange)),
                //UnityEngine.Random.Range(0.5f, 2f));
        }
    }

}