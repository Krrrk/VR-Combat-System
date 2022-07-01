using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    public class PlayerStats : MonoBehaviour
    {
        private const int HEALTH_MULTIPLIER = 10;

        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;
        public bool dead;

        private HealthBar healthBar;
        private Collider col;
        private DeathHandler deathHandler;

        private void Awake()
        {
            healthBar = GetComponentInChildren<HealthBar>();
            col = GetComponent<Collider>();
            deathHandler = GetComponent<DeathHandler>();
        }

        private void Start()
        {
            maxHealth = CalculateMaxHealth();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetCurrentHealth(currentHealth, maxHealth);
        }

        private int CalculateMaxHealth()
        {
            return healthLevel * HEALTH_MULTIPLIER;
        }

        public void TakeDamage(int damage)
        {
            if (dead)
                return;

            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                dead = true;
                col.enabled = false;
                deathHandler.PlayerDeath();
            }
            healthBar.SetCurrentHealth(currentHealth, maxHealth);
        }
    }
}
