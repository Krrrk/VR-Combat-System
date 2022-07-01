using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Krrk
{
    public class TrackVelocity : MonoBehaviour
    {
        public float minSpeed;
        public float minTime;

        private Collider damageCollider;

        private TrailRenderer trailRenderer;

        private Vector3 previousPosition;
        private float speed;
        private float timeCounter;
        // Start is called before the first frame update
        void Start()
        {
            trailRenderer = GetComponent<TrailRenderer>();
            damageCollider = GetComponent<Collider>();
        }

        private void Update()
        {
            CheckSpeed();
        }

        //Gets the speed of the object and checks if the speed is above a speed threshold
        //and if the time it has been above the threshold is above a time threshold
        //If true, enables trail and collider, else disables them and resets time
        public void CheckSpeed()
        {
            speed = (transform.position - previousPosition).magnitude / Time.deltaTime;
            previousPosition = transform.position;

            if (speed > minSpeed)
            {
                timeCounter += 1 / Time.deltaTime;
                if (timeCounter > minTime)
                {
                    trailRenderer.emitting = true;
                    damageCollider.enabled = true;
                }
            }
            else
            {
                timeCounter = 0;
                trailRenderer.emitting = false;
                damageCollider.enabled = false;
            }
        }
    }
}
