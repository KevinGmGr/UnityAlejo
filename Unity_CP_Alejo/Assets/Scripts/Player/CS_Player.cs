using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player : MonoBehaviour
{
    CharacterController CCRef;

    [SerializeField]
    float Speed = 10;
    [SerializeField] //SerializeField makes variables editable from Unity Editor
    float JumpForce = 10;
    Vector3 Movement = Vector3.zero;

    //TODO: create variable for Horizontal rotation speed named RotHorizontalSpeed
    //TODO: create variable for Vertical rotation speed named RotVerticalSpeed

    void Start()
    {
        CCRef = this.gameObject.GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Add rotation on Y axis by using transform.Rotate() and reading Input.GetAxis("Mouse X") and multiply by RotHorizontalSpeed
        //TODO: Add rotation on X axis to gameObject Camera by using transform.Rotate() and reading Input.GetAxis("Mouse Y") and multiply by RotVerticalSpeed
        if (CCRef.isGrounded)
        {
            //Refactor: Place this code inside of function LandedMovement ()
            //->
            //Movement = LandedMovement()
            Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Movement = this.gameObject.transform.TransformDirection(Movement);
            Movement *= Speed;
            //-<

            if(Input.GetButton("Jump"))
            {
                //Place this code inside of function Jump ()
                //->
                Movement.y += JumpForce;
                //-<
            }
        }
        else
        {
            Movement += Physics.gravity * Time.deltaTime;
        }        

        
        CCRef.Move(Movement * Time.deltaTime);        
    }

    //TODO: Create function for Landed Movement -> Vector3 LandedMovement ()

    //TODO: Create function of Jump 

}
