using System.Collections;
using System.Collections.Generic;
using Astroboy.Utils;
using UnityEngine;

namespace Astroboy.Asteroid
{
    public class AsteroidBehaviour : MonoBehaviour, IPoolingObject
    {
        [SerializeField]
        private GameObject player;
        [SerializeField]
        private Rigidbody rb;

        [Header("Param")]
        [SerializeField]
        private float speed = 1f;
        [SerializeField]
        private float maxLifetime = 5f;

        private float lifeTime;
        private float angle;
        private Vector3 dir = Vector3.zero;
        private Vector3 mov = Vector3.zero;

        private PoolingObject poolingObject;

        private const string poolTag = "Asteroid";

        private void Start()
        {
            poolingObject = PoolingObject.Instance;
        }

        public void OnObjectSpawn()
        {
            Movement();
        }

        private void Update()
        {
            lifeTime += Time.deltaTime;
            Movement();

            if (lifeTime > maxLifetime)
            {
                lifeTime = Time.deltaTime;
                poolingObject.ReturnPool(poolTag, this.gameObject);
            }
        }

        private void Movement()
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        private void OnEnable()
        {
            lifeTime = 0f;
        }
    }
}
