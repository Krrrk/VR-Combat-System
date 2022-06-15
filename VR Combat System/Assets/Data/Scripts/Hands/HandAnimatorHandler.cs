using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    public class HandAnimatorHandler : MonoBehaviour
    {
        private Animator handAnimator;

        private void Start()
        {
            handAnimator = GetComponent<Animator>();
        }

        //Updates the float values in the animator to animate the hand
        public void UpdateHandAnimation(float triggerValue, float gripValue)
        {
            handAnimator.SetFloat("Trigger", triggerValue);
            handAnimator.SetFloat("Grip", gripValue);
        }
    }
}
