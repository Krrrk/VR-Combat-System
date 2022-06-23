using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{

    public class EnemyAnimatorHandler : MonoBehaviour
    {
        public InputHandler inputHandler;
        private Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        //Plays the target animation
        private void PlayAnimation(string targetAnimation, bool isBeingHit)
        {
            animator.SetBool("isBeingHit", isBeingHit);
            animator.CrossFade(targetAnimation, 0.2f);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.tag == "PlayerWeapon")
            {
                PlayAnimation("GetHit", true);
            }
        }
    }
}
