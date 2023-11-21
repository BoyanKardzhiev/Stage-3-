using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;

    public float velocity;
    public float transitionTime;
    float remainingTime;
    bool up;
    bool forceApplied;

    void Start()
    {
        remainingTime = transitionTime;
        up = true;
        forceApplied = true;

        rb = GetComponent<Rigidbody>();
        rb.AddForce(Random.Range(-0.5f, 0.5f), -velocity, Random.Range(-0.5f, 0.5f), ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingTime >= transitionTime && forceApplied)
        {
            rb.AddForce(0, 2*velocity, 0, ForceMode.VelocityChange);

            up = true;
            forceApplied = false;
        }
        else if(remainingTime <= 0 && !forceApplied)
        {
            rb.AddForce(0, -2*velocity, 0, ForceMode.VelocityChange);

            up = false;
            forceApplied = true;
        }

        if(up)
        {
            remainingTime = remainingTime - Time.deltaTime;
        }
        else
        {
            remainingTime = remainingTime + Time.deltaTime;
        }
    }
}
