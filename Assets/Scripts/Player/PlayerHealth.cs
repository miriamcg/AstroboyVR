using System.Collections;
using Astroboy.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace Astroboy.Player {

    public class PlayerHealth : MonoBehaviour {

        [Header("Feedback")]
        public Color colorDamage;

        [Header("HUD")]
        public Sprite[] hearts;
        public Image lifebar;
        public Image healthFill;

        private static CharacterStats stats;

        private float lerpSpeed;
        private Color healthFillColor;

        private const string enemyTag = "Enemy";

        void Start() {
            stats = GetComponent<PlayerStats>();
        }

        private void Update()
        {
            lerpSpeed = 3f * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other) {

            if (other.CompareTag(enemyTag)) {
                Debug.Log("Oh oh an asteroid attacks me!");
                CharacterStats enemyStats = other.GetComponent<CharacterStats>();
                if (other.tag == enemyTag) stats.TakeDamage(enemyStats.GetDamage());

                if (lifebar != null)
                {
                    UpdateHealthBar();
                }
                else
                {
                    UpdateHealthFiller();
                }
            }
        }

        private void UpdateHealthBar() 
        {
            lifebar.sprite = hearts[stats.GetHealth()];
        }

        private void UpdateHealthFiller()
        {
            healthFill.fillAmount = Mathf.Lerp(healthFill.fillAmount, stats.GetHealth() / stats.GetMaxHealth, lerpSpeed);
            UpdateColor();
        }

        private void UpdateColor()
        {
            healthFillColor = Color.Lerp(Color.white, Color.blue, (stats.GetHealth() / stats.GetMaxHealth));
            healthFill.color = healthFillColor;
        }

        public void ResetLife()
        {
            stats.GetCurrentHealth = 6;
            if (lifebar != null) lifebar.sprite = hearts[stats.GetHealth() - 1];
            if (healthFill != null)
            {
                healthFill.fillAmount = 100;
                healthFillColor = Color.blue;
            }
        }
    }
}