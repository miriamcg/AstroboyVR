using Astroboy.Utils;
using UnityEngine;

namespace Astroboy.Stats {

    public class CharacterStats : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField]
        private int maxHealth = 6;
        [SerializeField] 
        private int damage = 0;

        private int _currentHealth = 6;

        public int GetCurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = maxHealth;
        }

        public int GetMaxHealth
        {
            get => maxHealth;
        }

        private void Start() 
        {
            _currentHealth = maxHealth;
            Debug.Log("Player health " + _currentHealth);
        }

        public void TakeDamage(int _damage) 
        {
            Debug.Log("Attack help... " + transform.name + " current health " + _currentHealth);
            _currentHealth -= _damage;

            if (_currentHealth <= 0) {
                Die();
            }
        }

        public virtual void Die() 
        {
            Debug.Log("I died... " + transform.name);
        }

        public int GetDamage() 
        {
            return damage;
        }

        public int GetHealth()
        {
            return _currentHealth;
        }
    }
}