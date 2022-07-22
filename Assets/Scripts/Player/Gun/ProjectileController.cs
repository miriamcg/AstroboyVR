using Astroboy.Utils;
using Astroboy.Stats;
using UnityEngine;

namespace Astroboy.Player.Gun
{
    public class ProjectileController : MonoBehaviour
    {
        [Header("Params")]
        [SerializeField]
        private float timeLife = 5f;

        private PoolingObject poolingObject;
        private ImpactController ImpactController;

        private float time = 0f;

        private const string playerTag = "Player";
        private const string projectileTag = "Projectile";
        private const string enemyTag = "Enemy";

        private void Start()
        {
            poolingObject = PoolingObject.Instance;
            ImpactController = ImpactController.Instance;
        }

        private void FixedUpdate()
        {
            time += Time.deltaTime;

            if (ShouldSpawn())
            {
                DeactiveProjectile();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag != playerTag && collision.gameObject.tag != projectileTag)
            {
                ImpactController.ActivateImpact(collision.contacts[0].point);
                DeactiveProjectile();
            }
        }

        private void DeactiveProjectile()
        {
            poolingObject.ReturnPool(projectileTag, this.gameObject);
        }

        private bool ShouldSpawn()
        {
            return time > timeLife;
        }
    }
}
