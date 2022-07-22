using Astroboy.Utils;
using Astroboy.Asteroid;
using UnityEngine;

namespace Astroboy.Stats {

    public class EnemyStats : CharacterStats {

        private PoolingObject _poolingObject;
        private Point _point;

        private const string poolTag = "Asteroid";

        private void Start()
        {
            _poolingObject = PoolingObject.Instance;
            _point = GetComponent<Point>();
        }

        public override void Die()
        {
            Debug.Log("I died... " + transform.name);
            _point.AddPoint();
            _poolingObject.ReturnPool(poolTag, this.gameObject);
        }
    }
}
