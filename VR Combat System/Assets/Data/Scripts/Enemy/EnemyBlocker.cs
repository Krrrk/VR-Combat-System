using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    public class EnemyBlocker : MonoBehaviour
    {
        public Transform playerSword;
        public Transform blockPoint;
        public Rigidbody handRotation;

        public DebugScreen debugScreen;

        public Collider playerSwordCollider;
        private Rigidbody rigid;

        private bool recentlyFlipped;
        private bool blockingLeft;

        private Vector2 playerSwordVector2;
        private Vector2 handRotationVector2;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody>();
            //playerSwordCollider = GetComponentInChildren<Collider>();
        }

        private Vector3 GetClosestPoint()
        {
            Vector3 closestPoint = playerSwordCollider.ClosestPoint(transform.position);

            //closestPoint.x -= 0.5f;
            //closestPoint.y -= 0.22f;

            return closestPoint;
        }

        IEnumerator FlipWeapon()
        {
            if(!recentlyFlipped)
            {
                recentlyFlipped = true;
                Vector3 newRotation = handRotation.rotation.eulerAngles;
                newRotation.z += 180;
                //handRotation.rotation = Quaternion.Euler(newRotation);
                handRotation.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 270f));
                yield return new WaitForSeconds(0.1f);
                if (blockingLeft)
                    handRotation.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                else
                    handRotation.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(new Vector3(0f, 0f, 180f));
                yield return new WaitForSeconds(2f);
                blockingLeft = !blockingLeft;
                recentlyFlipped = false;
            }
        }

        private void AngleSword()
        {
            //string str = Quaternion.Dot(handRotation.rotation, playerSword.rotation).ToString("n2");
            //string str2 = Vector3.Cross(handRotation.rotation.eulerAngles, playerSword.rotation.eulerAngles).sqrMagnitude.ToString();

            handRotationVector2 = new Vector2(handRotation.rotation.eulerAngles.x, handRotation.rotation.eulerAngles.z);
            playerSwordVector2 = new Vector2(playerSword.rotation.eulerAngles.x, playerSword.rotation.eulerAngles.z);

            string str3 = Vector2.Dot(handRotationVector2.normalized, playerSwordVector2.normalized).ToString("n2");
            
            debugScreen.UpdateDebugText(str3);
        }

        public void MoveSwordToBlock()
        {
            
        }

        private void FixedUpdate()
        {
            Vector3 closestPoint = playerSwordCollider.ClosestPoint(transform.position);

            rigid.velocity = (GetClosestPoint() - blockPoint.position) / Time.fixedDeltaTime;

            if ((closestPoint - transform.position).sqrMagnitude < (closestPoint - blockPoint.position).sqrMagnitude)
            {
                StartCoroutine(FlipWeapon());
            }

            AngleSword();

            //Quaternion rotationDifference = playerSword.rotation * Quaternion.Inverse(handRotation.rotation);
            //rotationDifference.ToAngleAxis(out float angleInDegrees, out Vector3 rotationAxis);

            //Vector3 rotationDifferenceInDegrees = angleInDegrees * rotationAxis;

            //handRotation.angularVelocity = (rotationDifferenceInDegrees * Mathf.Deg2Rad / Time.fixedDeltaTime);
        }
    }
}
