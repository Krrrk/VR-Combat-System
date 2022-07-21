using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    public class DamageCollider : MonoBehaviour
    {
        private Collider col;
        private WeaponHandler weaponHandler;

        private void Awake()
        {
            col = GetComponent<Collider>();
            weaponHandler = GetComponentInParent<WeaponHandler>();
        }
        public void EnableCollider()
        {
            col.enabled = true;
        }

        public void DisableCollider()
        {
            col.enabled = false;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (this.tag == "PlayerWeapon" && collision.tag == "Enemy")
            {
                EnemyStats enemyStats = collision.GetComponent<EnemyStats>();

                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(weaponHandler.weaponDamage);
                }
            }
            else if (this.CompareTag("EnemyWeapon") && collision.CompareTag("Player"))
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();

                if (playerStats != null)
                {
                    playerStats.TakeDamage(weaponHandler.weaponDamage);
                }
            }
            //else if (this.CompareTag("EnemyWeapon") && collision.CompareTag("PlayerWeapon")) {
            //    BlockHandler blockHandler = this.GetComponentInParent<BlockHandler>();

            //    blockHandler.HandleBlock();
            //}
        }
    }
}
