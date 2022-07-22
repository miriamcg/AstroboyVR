using System.Collections;
using System.Collections.Generic;
using Astroboy.Utils;
using UnityEngine;

namespace Astroboy.Asteroid
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField]
        private Vector3 center;
        [SerializeField]
        private Vector3 size;
        [SerializeField]
        private float waitTime = 3f;

        private PoolingObject poolingObject;

        private float time = 0f;
        private Vector3 pos;

        private const string poolTag = "Asteroid";

        private void Start()
        {
            poolingObject = PoolingObject.Instance;

            time = waitTime - Time.deltaTime;
        }

        private void FixedUpdate()
        {
            time += Time.deltaTime;

            if (ShouldSpawn())
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            time = 0f;
            pos = center + new Vector3(Random.Range(-size.x / 2f, size.x /2f), Random.Range(-size.y / 2f, size.y / 2f), Random.Range(-size.z / 2f, size.z / 2f));

            poolingObject.Spawn(poolTag, pos, Random.rotation);
        }

        private bool ShouldSpawn()
        {
            return time > waitTime;
        }
    }
}
