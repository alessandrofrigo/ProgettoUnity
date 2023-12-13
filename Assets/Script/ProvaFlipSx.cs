using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaFlipSx : MonoBehaviour
{
    public bool isKeyPress = false;
    public bool isTouched = false;
    HingeJoint hinge;
    JointMotor motor;
    public float speed = 1000;

    // Start is called before the first frame update
    void Start()
    {
       hinge = GetComponent<HingeJoint>();
       motor = hinge.motor;
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
        // on press keyboard or touch Screen
         if (isKeyPress == true && isTouched == false) //||isKeyPress == false && isTouched == true
         {
            motor.force = -speed;
            //motor.targetVelocity = 90;
            //motor.freeSpin = false;
            hinge.motor = motor;
         }
         else  
         {
            // snap the motor back again
            //motor.motorSpeed = speed;
            //hinge.motor = motor;
         }
    }
}
