using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    public class WeaponHandler : MonoBehaviour
    {
        public int weaponDamage = 10;

        public int minimumSpeedToEnableCollider = 5;
        public int minimumTimeToEnableCollider = 100;

        private WeaponTip weaponTip;


        private void Awake()
        {
            weaponTip = GetComponentInChildren<WeaponTip>();
        }
        // Start is called before the first frame update
        void Start()
        {
            weaponTip.SetMinimumSpeedAndTime(minimumSpeedToEnableCollider, minimumTimeToEnableCollider);
        }

        // Update is called once per frame
        void Update()
        {
            weaponTip.TrackSpeed();
        }
    }
}
