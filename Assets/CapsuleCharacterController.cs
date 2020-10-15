using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCharacterController : MonoBehaviour
{

    public float moveSpeed = 10;
    //Define the speed at which the object moves.

    public float lookSensitivity = 50;

    public float jumpForce = 100f;

    public Rigidbody myRB;

    public bool isGrounded = true;

    Animator myAnimatorThing;

    bool shouldJump = false;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myAnimatorThing = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // What Moves Us
        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis.

        if ((verticalInput != 0 || horizontalInput != 0) && isGrounded) {
            myAnimatorThing.SetBool("StartWalking", true);
        } else {
            myAnimatorThing.SetBool("StartWalking", false);
        }

        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.


        // get rotations from Stick 2
        float horizontalInput2 = Input.GetAxis("Mouse X");
        //Get the value of the Horizontal input axis.

        transform.Rotate(new Vector3(0, horizontalInput2, 0) * lookSensitivity * Time.deltaTime);
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.

    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            myRB.AddForce(transform.up * jumpForce);
            myAnimatorThing.SetTrigger("JumpTrigger");
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Ground") {
            // i dunno, something cool
            isGrounded = true;
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Ground") {
            // i dunno, something cool
            isGrounded = false;
        }
    }
}
