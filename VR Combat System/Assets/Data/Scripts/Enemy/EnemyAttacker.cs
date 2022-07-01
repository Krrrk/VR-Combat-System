using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    public class EnemyAttacker : MonoBehaviour
    {
        Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        public void PerformAttack()
        {
            animator.CrossFade("MeleeAttack_OneHanded", 0.2f);
        }
    }
}
