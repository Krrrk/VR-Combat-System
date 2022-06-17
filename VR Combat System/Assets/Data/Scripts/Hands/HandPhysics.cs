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
        private Collider[] handColliders;

        // Start is called before the first frame update
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
            handColliders = GetComponentsInChildren<Collider>();
        }

        public void EnableHandColliderDelay(float delay)
        {
            Invoke("EnableHandColliders", delay);
        }

        public void EnableHandColliders()
        {
            foreach (Collider collider in handColliders)
                collider.enabled = true;
        }

        public void DisableHandColliders()
        {
            foreach (Collider collider in handColliders)
                collider.enabled = false;
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
