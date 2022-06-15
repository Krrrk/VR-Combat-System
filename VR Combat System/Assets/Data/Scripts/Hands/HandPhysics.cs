using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    //Code from Valem Tutorials, (www.youtube.com/watch?v=VG8hLKyTiJQ)
    public class HandPhysics : MonoBehaviour
    {
        public Transform targetController;
        private Rigidbody rigid;

        // Start is called before the first frame update
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            //Moves hand position towards controller position
            rigid.velocity = (targetController.position - transform.position) / Time.fixedDeltaTime;

            //Rotates hand rotation towards controller rotation
            Quaternion rotationDifference = targetController.rotation * Quaternion.Inverse(transform.rotation);
            rotationDifference.ToAngleAxis(out float angleInDegrees, out Vector3 rotationAxis);

            Vector3 rotationDifferenceInDegrees = angleInDegrees * rotationAxis;

            rigid.angularVelocity = (rotationDifferenceInDegrees * Mathf.Deg2Rad / Time.fixedDeltaTime);
        }
    }
}
