using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astroboy.Asteroid
{
    public class GenerateField : MonoBehaviour
    {
        public Transform asteroid;
        public Transform field;

        [SerializeField]
        public int fiedlRadius = 100;
        [SerializeField]
        public int asteroidCount = 100;
        [SerializeField]
        public float minimumSize = 0.5f;
        [SerializeField]
        public float maximumSize = 5f;

        public void GenerateAsteroids()
        {
            CleanObjects(field);

            for (int i = 0; i < asteroidCount; i++)
            {
                Transform t = Instantiate(asteroid, Random.insideUnitSphere * fiedlRadius, Random.rotation);
                t.localScale = t.localScale * Random.Range(minimumSize, maximumSize);
                t.SetParent(field);
            }
        }

        protected void CleanObjects(Transform field)
        {
            foreach (Transform child in field)
            {
                DestroyImmediate(child.gameObject);
            }
        }
    }
}
