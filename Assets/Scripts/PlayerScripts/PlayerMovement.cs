using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCD;
    public float airMultiplier;
    bool CDElapsed = true;

    [Header("Keybinds")]
    public KeyCode jump = KeyCode.Space;

    [Header("Check for Ground")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    MessageUI message;
    private void Start()
    {
        message = FindObjectOfType<MessageUI>();
        message.SetNewMessage();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //checking for ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();
        SpeedLimit();

        //drag control
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //jumping implementation
        if(Input.GetKey(jump) && CDElapsed && grounded)
        {
            CDElapsed = false;
            Jump();
            Invoke(nameof(ResetJumpBool), jumpCD);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction. you always look at the direction you're going to
        moveDirection = orientation.forward * verticalInput + orientation. right * horizontalInput;

        //on ground forces
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        //in air forces
        else if(!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedLimit()
    {
        Vector3 flatSpeed = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limiting the speed if it crosses the boundaries
        if(flatSpeed.magnitude > moveSpeed)
        {
            Vector3 limitedSpeed = flatSpeed.normalized * moveSpeed; //calculate maximum velocity
            rb.velocity = new Vector3(limitedSpeed.x, rb.velocity.y, limitedSpeed.z); // apply it
        }
    }

    private void Jump()
    {
        //reset y velocity to 0
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); //impulse is used to jump only once
    }

    private void ResetJumpBool()
    {
        CDElapsed = true;
    }
}
