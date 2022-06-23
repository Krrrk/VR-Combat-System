using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Velocity = " + (transform.position - previousPosition).magnitude / Time.deltaTime);
        speed = (transform.position - previousPosition).magnitude / Time.deltaTime;
        previousPosition = transform.position;

        if(speed > minSpeed)
        {
            timeCounter += 1 / Time.deltaTime;
            if(timeCounter > minTime)
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
