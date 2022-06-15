using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    //This class handles all updates connected to the player
    public class PlayerManager : MonoBehaviour
    {
        InputHandler inputHandler;
        public HandAnimatorHandler leftHandAnimatorHandler;
        public HandAnimatorHandler rightHandAnimatorHandler;

        // Start is called before the first frame update
        void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            //handAnimatorHandler = GetComponent<HandAnimatorHandler>();
            //GetHandAnimatorHandlers();
        }

        //private void GetHandAnimatorHandlers()
        //{
        //    HandAnimatorHandler[] handAnimatorHandlers = GetComponentsInChildren<HandAnimatorHandler>();
        //    foreach (HandAnimatorHandler handAnimatorHandler in handAnimatorHandlers)
        //    {
        //        if (handAnimatorHandler.CompareTag("LeftHand"))
        //            leftHandAnimatorHandler = handAnimatorHandler;
        //        else
        //            rightHandAnimatorHandler = handAnimatorHandler;
        //    }
        //}

        // Update is called once per frame
        void Update()
        {
            float delta = Time.deltaTime;
            inputHandler.TickInput(delta);
            leftHandAnimatorHandler.UpdateHandAnimation(inputHandler.left_Trigger_Value, inputHandler.left_Grip_Value);
            rightHandAnimatorHandler.UpdateHandAnimation(inputHandler.right_Trigger_Value, inputHandler.right_Grip_Value);
        }

        //Called last on every frame
        private void LateUpdate()
        {
            inputHandler.DisableInputs();
        }
    }
}
