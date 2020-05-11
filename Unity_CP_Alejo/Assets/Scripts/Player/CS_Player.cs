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

    [SerializeField]
    float RotHorizontalSpeed = 1;
    [SerializeField]
    float RotVerticalSpeed = 1;


    [SerializeField]
    float LateraStrafe = 5f;
    [SerializeField]
    float FowardStrafe = 5f;
    [SerializeField]
    float BackwardStrafe = 2.5f;
    [SerializeField]
    float AirSpeed = 10f;


    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CCRef = this.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        CameraRotation();

        if (CCRef.isGrounded)
        {
            Movement = LandedMovement(); 
            
            if (Input.GetButton("Jump"))
            {

                Jump();
                
            }
        }
        else
        {
            Movement += Physics.gravity * Time.deltaTime;
            Movement += AirMovement() * Time.deltaTime ;
        }


        CCRef.Move(Movement * Time.deltaTime);
    }

    
    Vector3 LandedMovement()
    {
        Vector3 LandedMovementCalc = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        LandedMovementCalc = this.gameObject.transform.TransformDirection(LandedMovementCalc);
        LandedMovementCalc *= Speed;
        return LandedMovementCalc; 
    }
    void Jump()
    {
        Movement.y += JumpForce;

    }

    Vector3 AirMovement()
    {
        Vector3 AirMovementCalc = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        AirMovementCalc.x *= AirSpeed * LateraStrafe;
        if (AirMovementCalc.z > 0)
        {
            AirMovementCalc.z *= AirSpeed * FowardStrafe;
        }
        else
        {
            AirMovementCalc.z *= AirSpeed * BackwardStrafe;
        }

        AirMovementCalc = this.gameObject.transform.TransformDirection(AirMovementCalc);
        return AirMovementCalc;

    }

    void CameraRotation()
    {
        this.gameObject.transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * RotHorizontalSpeed);

        this.gameObject.transform.GetChild(0).Rotate(Vector3.right * Input.GetAxis("Mouse Y") * -1 *RotVerticalSpeed);

        this.gameObject.transform.GetChild(0).localRotation = new Quaternion(
            Mathf.Clamp(this.gameObject.transform.GetChild(0).localRotation.x, -0.5f, 0.5f),
            this.gameObject.transform.GetChild(0).localRotation.y,
            this.gameObject.transform.GetChild(0).localRotation.z,
            this.gameObject.transform.GetChild(0).localRotation.w
            );

    }
    //TODO: Create function of Jump 

}
