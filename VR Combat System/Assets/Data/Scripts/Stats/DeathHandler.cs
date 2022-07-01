using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Krrk
{
    public class DeathHandler : MonoBehaviour
    {
        public Canvas ui;

        public void PlayerDeath()
        {
            ui.enabled = true;
        }
    }
}
