using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSx2D : MonoBehaviour
{
    public bool isKeyPress = false;
    public bool isTouched = false;
    public float speed = 0f;
    HingeJoint2D hingeJoint2D;
    JointMotor2D jointMotor;

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint2D = GetComponent<HingeJoint2D>();
        jointMotor = hingeJoint2D.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isKeyPress = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isKeyPress = false;
        }
    }
    void FixedUpdate()
    {
     if ((isKeyPress == true && isTouched == false) || (isKeyPress == false && isTouched == true))
        {
          jointMotor.motorSpeed = speed;
          hingeJoint2D.motor = jointMotor;
        }
     else  
        {
            // snap the motor back again
            jointMotor.motorSpeed = -speed;
            hingeJoint2D.motor = jointMotor;
        }
    } 
}
