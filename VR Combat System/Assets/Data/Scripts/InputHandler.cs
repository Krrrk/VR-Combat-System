using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    public class InputHandler : MonoBehaviour
    {
        public float left_Trigger_Value;
        public float right_Trigger_Value;
        public float left_Grip_Value;
        public float right_Grip_Value;

        public bool left_Trigger_Input;
        public bool right_Trigger_Input;
        public bool left_Grip_Input;
        public bool right_Grip_Input;
        public bool a_Input;
        public bool b_Input;
        public bool x_Input;
        public bool y_Input;
        public bool menu_Input;
        public bool home_Input;
        public bool spacebar_Input;

        XRIDefaultInputActions inputActions;

        private void OnEnable()
        {
            if(inputActions == null)
            {
                inputActions = new XRIDefaultInputActions();

            }
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        //Handles the update of the InputHandler
        public void TickInput(float delta)
        {
            HandleInputs();
        }

        //Handles all inputs from the controllers
        private void HandleInputs()
        {
            HandleButtonPresses();
            HandleButtonValues();
            HandleSpaceBar();
        }

        //Handles all boolean values from button presses
        //Sets input bools to true if the corresponsing button has been pressed
        private void HandleButtonPresses()
        {
            inputActions.LeftController.TriggerPressed.performed += i => left_Trigger_Input = true;
            inputActions.LeftController.GripPressed.performed += i => left_Grip_Input = true;
            inputActions.RightController.TriggerPressed.performed += i => right_Trigger_Input = true;
            inputActions.RightController.GripPressed.performed += i => right_Grip_Input = true;
            inputActions.RightController.A.performed += i => a_Input = true;
            inputActions.RightController.B.performed += i => b_Input = true;
            inputActions.LeftController.X.performed += i => x_Input = true;
            inputActions.LeftController.Y.performed += i => y_Input = true;
            inputActions.LeftController.Menu.performed += i => menu_Input = true;
            inputActions.RightController.Home.performed += i => home_Input = true;
        }

        private void HandleSpaceBar()
        {
            inputActions.Keyboard.Spacebar.performed += i => spacebar_Input = true;
        }

        //Handles all float values from button presses
        private void HandleButtonValues()
        {
            //left_Trigger_Value = 0;
            //right_Trigger_Value = 0;
            //left_Grip_Value = 0;
            //right_Grip_Value = 0;

            //inputActions.LeftController.TriggerValue.performed += i => left_Trigger_Value = i.ReadValue<float>();
            //inputActions.RightController.TriggerValue.performed += i => right_Trigger_Value = i.ReadValue<float>();
            //inputActions.LeftController.GripValue.performed += i => left_Grip_Value = i.ReadValue<float>();
            //inputActions.RightController.GripValue.performed += i => right_Grip_Value = i.ReadValue<float>();

            //if (inputActions.LeftController.TriggerValue.ReadValue<float>() > 0.1f)
            left_Trigger_Value = inputActions.LeftController.TriggerValue.ReadValue<float>();
            //else
                //left_Trigger_Value = 0;

            //if (inputActions.RightController.TriggerValue.ReadValue<float>() > 0.1f)
            right_Trigger_Value = inputActions.RightController.TriggerValue.ReadValue<float>();
            //else
            //right_Trigger_Value = 0;

            //if (inputActions.LeftController.GripValue.ReadValue<float>() > 0.1f)
            left_Grip_Value = inputActions.LeftController.GripValue.ReadValue<float>();
            //else
                //left_Grip_Value = 0;

            //if (inputActions.RightController.GripValue.ReadValue<float>() > 0.1f)
            right_Grip_Value = inputActions.RightController.GripValue.ReadValue<float>();
            //else
                //right_Grip_Value = 0;
        }

        //Set all input bools to false in late update.
        //This makes it so buttons are only triggered once per buttonpress
        public void DisableInputs()
        {
            left_Trigger_Input = false;
            right_Trigger_Input = false;
            left_Grip_Input = false;
            right_Grip_Input = false;
            a_Input = false;
            b_Input = false;
            x_Input = false;
            y_Input = false;
            menu_Input = false;
            home_Input = false;
            spacebar_Input = false;
        }
    }
}
