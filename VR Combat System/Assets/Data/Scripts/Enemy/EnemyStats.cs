using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inspiration from Sebastian Graves, (www.youtube.com/playlist?list=PLD_vBJjpCwJtrHIW1SS5_BNRk6KZJZ7_d)
namespace Krrk
{
    public class EnemyStats : MonoBehaviour
    {
        private const int HEALTH_MULTIPLIER = 10;

        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;
        public bool dead;
        public bool invicibilityFrame;

        private HealthBar healthBar;
        private Collider col;
        private EnemyAnimatorHandler animatorHandler;
        private Animator animator;
        private EnemyManager enemyManager;

        private void Awake()
        {
            healthBar = GetComponentInChildren<HealthBar>();
            col = GetComponent<Collider>();
            animatorHandler = GetComponentInChildren<EnemyAnimatorHandler>();
            enemyManager = GetComponent<EnemyManager>();
            animator = GetComponentInChildren<Animator>();
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
            if (dead || enemyManager.hasInvincibilityFrames)
                return;

            currentHealth -= damage;

            //animatorHandler.PlayAnimation("GetHit", true);
            animator.Play("GetHit");
            animator.SetBool("hasInvincibilityFrames", true);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                //animatorHandler.PlayAnimation("Death", false);
                animator.Play("Death");
                dead = true;
                col.enabled = false;
                healthBar.gameObject.SetActive(false);
            }
            healthBar.SetCurrentHealth(currentHealth, maxHealth);
        }
    }
}
