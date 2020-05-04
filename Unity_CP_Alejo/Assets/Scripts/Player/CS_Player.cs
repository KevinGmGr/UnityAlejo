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
    //TODO: create variable for Horizontal rotation speed named RotHorizontalSpeed
    //TODO: create variable for Vertical rotation speed named RotVerticalSpeed

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CCRef = this.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * RotHorizontalSpeed);

        this.gameObject.transform.GetChild(0).Rotate(Vector3.right * Input.GetAxis("Mouse Y") * RotVerticalSpeed);

        this.gameObject.transform.GetChild(0).localRotation = new Quaternion(
            Mathf.Clamp(this.gameObject.transform.GetChild(0).localRotation.x, -0.5f, 0.5f),
            this.gameObject.transform.GetChild(0).localRotation.y,
            this.gameObject.transform.GetChild(0).localRotation.z,
            this.gameObject.transform.GetChild(0).localRotation.w
            );



        if (CCRef.isGrounded)
        {
            //Refactor: Place this code inside of function LandedMovement ()
            //->
            //Movement = LandedMovement()
            Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Movement = this.gameObject.transform.TransformDirection(Movement);
            Movement *= Speed;
            //-<

            if (Input.GetButton("Jump"))
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
