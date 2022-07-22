using System.Collections;
using Astroboy.Stats;
using UnityEngine;

namespace Astroboy.Asteroid
{
    public class AsteroidHealth : MonoBehaviour
    {
        [Header("Feedback")]
        public Color colorDamage;

        private CharacterStats stats;

        private const string weaponTag = "Projectile";

        private void Start()
        {
            stats = GetComponent<CharacterStats>();
        }
    }
}