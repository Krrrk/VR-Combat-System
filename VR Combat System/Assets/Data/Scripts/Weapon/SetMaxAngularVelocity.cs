using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    public class SetMaxAngularVelocity : MonoBehaviour
    {
        public float maxAngularVelocity = 15;
        private Rigidbody rigid;
        // Start is called before the first frame update
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
            rigid.maxAngularVelocity = maxAngularVelocity;
        }
    }
}
