using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Inspiration from Sebastian Graves, (www.youtube.com/playlist?list=PLD_vBJjpCwJtrHIW1SS5_BNRk6KZJZ7_d)
namespace Krrk
{
    public class HealthBar : MonoBehaviour
    {
        private Slider slider;
        public Text text;

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        //Sets the max health and sets the current health to max
        public void SetMaxHealth(int maxHealth)
        {
            slider.maxValue = maxHealth;
            slider.value = maxHealth;
            }

        //Sets the current health
        public void SetCurrentHealth(int currentHealth, int maxHealth)
        {
            slider.value = currentHealth;
            text.text = $"{currentHealth}/{maxHealth}";
        }
    }
}
