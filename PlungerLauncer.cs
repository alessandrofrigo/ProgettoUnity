using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerLauncer : MonoBehaviour
{ 
    public bool isTouched = false;
    public bool isKeyPress = false;
    // Ready for Launch
    public bool isActive = true;
    // Timers
    float pressTime = 0f;
    float startTime = 0f;
    int powerIndex;
    SpringJoint2D springJoint;
    Rigidbody2D rb;
    float force = 0f;          // current force generated
    public float maxForce = 90f;
    // Start is called before the first frame update
    void Start()
    {
        springJoint = GetComponent<SpringJoint2D>();
        springJoint.distance = 0f; 
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown("space"))
            {
                isKeyPress = true;
            }

            if (Input.GetKeyUp("space"))
            {
                isKeyPress = false;
            }

            // on keyboard press or touch hotspot
            if (isKeyPress == true && isTouched == false || isKeyPress == false && isTouched == true)
            {
                if (startTime == 0f)
                {
                    startTime = Time.time;
                }
            }

            // on keyboard release 
            if (isKeyPress == false && isTouched == false && startTime != 0f)
            {
                // #1
                // calculates current force of exertion
                force = powerIndex * maxForce;
                // reset values
                pressTime = 0f;
                startTime = 0f;
                while (powerIndex >= 0)
                {
                    powerIndex--;
                }
            }
        }
    }
    void FixedUpdate()
    {
        // When force is not 0
        if (force != 0)
        {
            // release springJoint and power up
            springJoint.distance = 0.3f;
            rb.AddForce(Vector3.up * force);
            force = 0;
        }
        // When the plunger is held down
        if (pressTime != 0)
        {
            // retract the springJoint distance and reduce the power
            springJoint.distance = 0f;
            rb.AddForce(Vector3.down * 400);
        }
    }
}
