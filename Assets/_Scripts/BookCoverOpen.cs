using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCoverOpen : MonoBehaviour
{
    public GameObject bookCover; //book cover game object
    public HingeJoint hinge; //hinge joint for the book cover
    public JointMotor motor; //motor for the hinge joint


    // Start is called before the first frame update
    void Start()
    {
        var hinge = bookCover.GetComponent<HingeJoint>();
        hinge.useMotor = false;
    }

    //function to open the book cover
    public void OpenBookCover()
    {
        var hinge = bookCover.GetComponent<HingeJoint>();
        hinge.useMotor = true; //use motor to open the book cover
        var motor = hinge.motor; //get the motor for the hinge joint
        motor.force = 1000; //force to open the book cover
        motor.targetVelocity = 100; //target velocity to open the book cover
        hinge.motor = motor; //set the motor for the hinge joint

        //debug log for motor not working
        Debug.Log("motor is working" + hinge.motor); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
