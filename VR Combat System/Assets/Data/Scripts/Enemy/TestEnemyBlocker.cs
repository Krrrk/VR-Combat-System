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
        public Transform testRotation;
        public Transform handPosition;

        public DebugScreen debug;

        public float distance = 1f;

        private Vector3 rotationLeft;
        private Vector3 rotationRight;



        private Rigidbody rigid;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            rotationLeft = new Vector3(0, 90, 0);
            rotationRight = new Vector3(0, -90, 0);
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

            //Vector3 temp = new Vector3(endPosition.position.x, endPosition.position.y, endPosition.position.z);

            rigid.velocity = (endPosition.position - blockPoint.position) / Time.fixedDeltaTime;

            endPosition.position += endPosition.forward * 1f;
            //if(endPosition.localEulerAngles.x > 0)
            //{
            //AngleSword(endPosition.rotation);
            //}
            //else
            //{
            //endPosition.localEulerAngles = new Vector3(endPosition.localEulerAngles.x, endPosition.localEulerAngles.y - 180f, endPosition.localEulerAngles.z);
            //AngleSword(endPosition.rotation);

            //Vector3 testVector3 = new Vector3(endPosition.position.x, -endPosition.position.y, endPosition.position.z);

            //testRotation.LookAt(endPosition.position);
            blockPoint.LookAt(endPosition.position);
            //testRotation.LookAt(testVector3);


            if(((endPosition.localEulerAngles.x >= 0 && endPosition.localEulerAngles.x <= 90) && endPosition.localEulerAngles.y == 270f) || ((endPosition.localEulerAngles.x <= 360 && endPosition.eulerAngles.x >= 270) && endPosition.localEulerAngles.y == 90))
            {
                //testRotation.localEulerAngles = new Vector3(testRotation.localEulerAngles.x, testRotation.localEulerAngles.y, testRotation.localEulerAngles.z + 180f);
                testRotation.localEulerAngles = new Vector3(blockPoint.localEulerAngles.x, testRotation.localEulerAngles.y, blockPoint.localEulerAngles.z + 180f);
            }
            else
            {
                testRotation.localEulerAngles = new Vector3(blockPoint.localEulerAngles.x, testRotation.localEulerAngles.y, blockPoint.localEulerAngles.z);
            }

            debug.UpdateDebugText("X: " + endPosition.localEulerAngles.x.ToString("n2") + "\nY: " + endPosition.localEulerAngles.y.ToString("n2"));

            //rigid.velocity = (endPosition.position - blockPoint.position) / Time.fixedDeltaTime;
            //}

        }

        private void AngleSword(Quaternion rot)
        {

            //Quaternion rotationDifference = Quaternion.Euler(rotation) * Quaternion.Inverse(handRotation.rotation);
            Quaternion rotationDifference = rot * Quaternion.Inverse(handRotation.rotation);
            rotationDifference.ToAngleAxis(out float angleInDegrees, out Vector3 rotationAxis);

            Vector3 rotationDifferenceInDegrees = angleInDegrees * rotationAxis;

            handRotation.angularVelocity = (rotationDifferenceInDegrees * Mathf.Deg2Rad / Time.fixedDeltaTime);
        }

    }
}
