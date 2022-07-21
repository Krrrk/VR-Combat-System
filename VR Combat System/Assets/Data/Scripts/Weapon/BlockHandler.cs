using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    public class BlockHandler : MonoBehaviour
    {
        private Animator animator;
        private WeaponTip weaponTip;

        private void Awake()
        {
            animator = GetComponentInParent<Animator>();
            weaponTip = GetComponentInChildren<WeaponTip>();
        }

        public void HandleBlock()
        {
            Debug.Log("Attack Blocked!");
            animator.CrossFade("GetHit", 0.2f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (weaponTip.colliderEnabled && collision.transform.CompareTag("PlayerWeapon"))
            {
                HandleBlock();
            }
        }
    }
}
