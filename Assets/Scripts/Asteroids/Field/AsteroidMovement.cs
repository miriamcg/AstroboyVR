using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astroboy.Asteroid
{
    public class AsteroidMovement : MonoBehaviour
    {
        [Header("Param")]
        [SerializeField]
        private float minSpeed = 1f;
        [SerializeField]
        private float maxSpeed = 5f;
        [SerializeField]
        private float minThrust = 0.1f;
        [SerializeField]
        private float maxThrust = 0.5f;

        Rigidbody rg = null;

        private float spinSpeed;
        private float thrust;

        void Start()
        {
            spinSpeed = Random.Range(minSpeed, maxSpeed);
            thrust = Random.Range(minThrust, maxThrust);

            rg = GetComponent<Rigidbody>();
            rg.AddForce(transform.forward * thrust, ForceMode.Impulse);
        }

        void Update()
        {
            transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        }
    }
}
