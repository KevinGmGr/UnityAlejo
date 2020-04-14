using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player : MonoBehaviour
{
    CharacterController CCRef;
    float Speed = 10; 
    float JumpForce = 10;
    Vector3 Movement = Vector3.zero;

    
    void Start()
    {
        CCRef = this.gameObject.GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {        
        if(CCRef.isGrounded)
        {
            Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Movement = this.gameObject.transform.TransformDirection(Movement);
            Movement *= Speed;

            if(Input.GetButton("Jump"))
            {
                Movement.y += JumpForce;
            }
        }
        else
        {
            Movement += Physics.gravity * Time.deltaTime;
        }

        

        CCRef.Move(Movement * Time.deltaTime);
        
    }
}
