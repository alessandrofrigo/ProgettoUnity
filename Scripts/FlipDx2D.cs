using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipDx2D : MonoBehaviour
{
    //ciaooo
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
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isKeyPress = true;
            //print("RightArrow key was pressed");
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isKeyPress = false;
        }
    } 
    
    void FixedUpdate()
    {
     if ((isKeyPress == true && isTouched== false) || (isKeyPress == false && isTouched == true))
        {
          jointMotor.motorSpeed = -speed;
          hingeJoint2D.motor = jointMotor;
        }
     else  
        {
            // snap the motor back again
            jointMotor.motorSpeed = speed;
            hingeJoint2D.motor = jointMotor;
        }
    } 
}
