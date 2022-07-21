using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    public class TestEnemyBlocker : MonoBehaviour
    {
        public Collider sphereCollider;
        public Transform endPosition;
        public Transform playerSword;
        public Collider playerSwordCollider;
        public Transform blockPoint;
        public Rigidbody handRotation;

        public float distance = 1f;
    

        private Rigidbody rigid;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody>();
        }

        //private Vector3 GetClosestPoint()
        //{
        //    return playerSwordCollider.ClosestPoint(transform.position);
        //}

        private void FixedUpdate()
        {
            Vector3 closestPointPlayerSword = playerSwordCollider.ClosestPoint(transform.position);

            //Vector3 closestPointSphereCollider = sphereCollider.ClosestPoint(closestPointPlayerSword);


            endPosition.position = sphereCollider.transform.position;

            Vector3 newPoint = new Vector3(closestPointPlayerSword.x, closestPointPlayerSword.y, sphereCollider.transform.position.z);
            Vector3 newPoint2 = new Vector3(closestPointPlayerSword.x, closestPointPlayerSword.y, transform.position.z);
            //sphereCollider.transform.LookAt(newPoint);

            //Vector3 endPosition = sphereCollider.transform.forward;
            endPosition.LookAt(newPoint);

            //endPosition.localEulerAngles = new Vector3(endPosition.localEulerAngles.x, 0f, endPosition.localEulerAngles.z);

            //endPosition.rotation..x = 0f;
            //= Mathf.Clamp(transform.eulerAngles.y, -90, 90);

            //transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.y, -90, 90), 0, 0);

            //float f = transform.eulerAngles.y;

            endPosition.position += endPosition.forward * distance;

            rigid.velocity = (endPosition.position - blockPoint.position) / Time.fixedDeltaTime;

            Quaternion rotationDifference = endPosition.rotation * Quaternion.Inverse(handRotation.rotation);
            rotationDifference.ToAngleAxis(out float angleInDegrees, out Vector3 rotationAxis);

            Vector3 rotationDifferenceInDegrees = angleInDegrees * rotationAxis;

            handRotation.angularVelocity = (rotationDifferenceInDegrees * Mathf.Deg2Rad / Time.fixedDeltaTime);
        }

    }
}
