using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    public class TestEnemyBlocker1 : MonoBehaviour
    {
        public Collider sphereCollider;
        public Transform endPosition;
        public Transform playerSword;
        public Collider playerSwordCollider;
        public Transform blockPoint;
        public Rigidbody handRotation;
        public Transform testRotation;
        public Transform handPosition;
        public Transform rotationPoint;

        public bool weaponFlipped;

        public DebugScreen debug;

        public float distance = 1f;
        public float speedOfrotation = 1f;

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

        private void FixedUpdate()
        {
            Vector3 closestPointPlayerSword = playerSwordCollider.ClosestPoint(transform.position);
            endPosition.position = sphereCollider.transform.position;
            Vector3 newPoint = new Vector3(closestPointPlayerSword.x, closestPointPlayerSword.y, sphereCollider.transform.position.z);
            //Vector3 newPoint = new Vector3(closestPointPlayerSword.x, closestPointPlayerSword.y, sphereCollider.transform.position.z);
            //Vector3 newPoint = new Vector3(closestPointPlayerSword.x, sphereCollider.transform.position.y, closestPointPlayerSword.z);

            //var lookPos = closestPointPlayerSword - transform.position;
            //Quaternion lookRot = Quaternion.LookRotation(lookPos);
            //lookRot.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, lookRot.eulerAngles.z);
            //lookRot.eulerAngles = new Vector3(closestPointPlayerSword.x, lookRot.eulerAngles.y, closestPointPlayerSword.z);
            //transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * speedOfrotation);



            //endPosition.LookAt(newPoint);
            Vector3 difference = closestPointPlayerSword - endPosition.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            endPosition.rotation = Quaternion.Euler(endPosition.localEulerAngles.x, endPosition.localEulerAngles.y, rotationZ);

            endPosition.position += endPosition.right * distance;
            rigid.velocity = (endPosition.position - blockPoint.position) / Time.fixedDeltaTime;
            endPosition.position += endPosition.right * 1f;


            //blockPoint.LookAt(endPosition.position);

            //rotationPoint.LookAt(endPosition.position);
            Vector3 difference2 = endPosition.position - rotationPoint.position;
            float rotationZ2 = Mathf.Atan2(difference2.y, difference2.x) * Mathf.Rad2Deg;
            rotationPoint.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ2);

            //if (((endPosition.localEulerAngles.x >= 0 && endPosition.localEulerAngles.x <= 90) && endPosition.localEulerAngles.y == 270f) || ((endPosition.localEulerAngles.x <= 360 && endPosition.eulerAngles.x >= 270) && endPosition.localEulerAngles.y == 90))
            if (endPosition.localEulerAngles.z >= 0 && endPosition.localEulerAngles.z <= 180f)
            {
                //endPosition.localEulerAngles = new Vector3(endPosition.localEulerAngles.x, endPosition.localEulerAngles.y, 180f);
                Debug.Log("In HERE");
                //rotationPoint.localEulerAngles = new Vector3(rotationPoint.localEulerAngles.x, rotationPoint.localEulerAngles.y, rotationPoint.localEulerAngles.z + 180f);
                
                //rotationPoint.localEulerAngles = new Vector3(rotationPoint.localEulerAngles.x, rotationPoint.localEulerAngles.y, rotationPoint.localEulerAngles.z + 180f);
                //blockPoint.localEulerAngles = new Vector3(blockPoint.localEulerAngles.x, blockPoint.localEulerAngles.y, blockPoint.localEulerAngles.z + 180f);
            }
         
            debug.UpdateDebugText("Rotation: " + endPosition.localEulerAngles.z.ToString("n2") + "\nWeapon Flipped: " + weaponFlipped.ToString());

            //if((endPosition.localEulerAngles.x >= 75 && endPosition.localEulerAngles.x <= 100) || (endPosition.localEulerAngles.x <= 285 && endPosition.eulerAngles.x >= 260))
            //{
            //    //rotationPoint.rotation = blockPoint.rotation;
            //    return;
            //}



            if(endPosition.localEulerAngles.z >= 30 && endPosition.localEulerAngles.z <= 150f)
            {
                weaponFlipped = true;
            }
            else if(endPosition.localEulerAngles.z >= 230 && endPosition.localEulerAngles.z <= 360f)
            {
                weaponFlipped = false;
            }

            if(weaponFlipped)
            {
                rotationPoint.localEulerAngles = new Vector3(rotationPoint.localEulerAngles.x, rotationPoint.localEulerAngles.y, rotationPoint.localEulerAngles.z + 180f);
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, rotationPoint.rotation, Time.deltaTime * speedOfrotation);
            //AngleSword(rotationPoint.rotation);

            //var lookPos = endPosition.position - transform.position;
            //Quaternion lookRot = Quaternion.LookRotation(lookPos);
            //lookRot.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, lookRot.eulerAngles.y, transform.rotation.eulerAngles.z);
            //transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * speedOfrotation);
            //var lookPos = closestPointPlayerSword - transform.position;
            //Quaternion lookRot = Quaternion.LookRotation(lookPos);
            //lookRot.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, lookRot.eulerAngles.y, transform.rotation.eulerAngles.z);
            //transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * speedOfrotation);
        }

        private void AngleSword(Quaternion rot)
        {

            //Quaternion rotationDifference = Quaternion.Euler(rotation) * Quaternion.Inverse(handRotation.rotation);
            Quaternion rotationDifference = rot * Quaternion.Inverse(handRotation.rotation);
            rotationDifference.ToAngleAxis(out float angleInDegrees, out Vector3 rotationAxis);

            Vector3 rotationDifferenceInDegrees = angleInDegrees * rotationAxis;

            rigid.angularVelocity = (rotationDifferenceInDegrees * Mathf.Deg2Rad / Time.fixedDeltaTime);
        }

    }
}
