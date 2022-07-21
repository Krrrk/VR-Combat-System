using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Krrk
{
    public class DebugScreen : MonoBehaviour
    {
        private Text debugText;

        private void Awake()
        {
            debugText = GetComponentInChildren<Text>();
        }

        public void UpdateDebugText(string textToShow)
        {
            debugText.text = textToShow;
        }
    }
}
