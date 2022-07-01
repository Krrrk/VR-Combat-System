using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    public class EnemyManager : MonoBehaviour
    {
        public bool hasInvincibilityFrames;

        private Animator animator;
        private EnemyAttacker enemyAttacker;

        private InputHandler inputHandler;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            enemyAttacker = GetComponent<EnemyAttacker>();

            inputHandler = FindObjectOfType<InputHandler>();
        }

        // Update is called once per frame
        void Update()
        {
            hasInvincibilityFrames = animator.GetBool("hasInvincibilityFrames");

            if (inputHandler.x_Input || inputHandler.a_Input || inputHandler.spacebar_Input)
            {
                enemyAttacker.PerformAttack();
            }
        }

    }
}
