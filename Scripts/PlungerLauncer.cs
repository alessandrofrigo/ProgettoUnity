using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerLauncer : MonoBehaviour
{ 
    public bool isTouched = false;
    public bool isKeyPress = false;
    // Ready for Launch
    public bool isActive = true;
    public bool toggle = false;
    // Timers
    float pressTime = 0f;
    float startTime = 0f;
    float powerIndex = 0;
    SpringJoint2D springJoint;
    Rigidbody2D rb;
    float force = 0f;          // current force generated
    public float maxForce;
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
                Debug.Log("spazio premuto");
                if (startTime == 0f)
                {
                    startTime = Time.time;
                }
                //pressing = true;
                if (powerIndex > -1f)
                {
                    powerIndex -= 0.003f;
                }
            }

            // on keyboard release 
            if (isKeyPress == false && isTouched == false && startTime != 0f)
            {
                Debug.Log("spazio rilasciato");
                // calculates current force of exertion
                force = powerIndex * maxForce;
                Debug.Log("force: "+force);
                // reset values
                pressTime = 0f;
                startTime = 0f;
                powerIndex = 0f;
            }
        }
    }
    void FixedUpdate()
    {
        // When force is not 0
        if (force != 0)
        {
            // release springJoint and power up
            rb.AddForce(Vector3.down * force);
            force = 0;
            toggle = true;
        }
        // When the plunger is held down
        else if (toggle)
        {
            // retract the springJoint distance and reduce the power
            toggle = false;
        }
    }
}
