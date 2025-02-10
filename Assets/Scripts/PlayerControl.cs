using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeedForward;
    [SerializeField] private float moveSpeedBackward;
    [SerializeField] private float moveSpeedSideways;

    [SerializeField] private Transform orientation;

    private float horizontalInput;
    private float verticalInput;
    private bool upInput;
    private bool downInput;

    private Vector3 moveDirection;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;


    }

    private void FixedUpdate()
    {
        MyInput();
        MovePlayer();
        SpeedControl();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        upInput = Input.GetKeyDown(KeyCode.Space);
        downInput = Input.GetKeyDown(KeyCode.LeftControl);

    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //if (upInput)
        //{
        //    rb.AddForce(0f, moveSpeedBackward * 10f, 0f, ForceMode.Force);
        //}
        //if (downInput)
        //{
        //    rb.AddForce(0f, moveSpeedBackward * -10f, 0f, ForceMode.Force);
        //}

        rb.AddForce(moveDirection * moveSpeedForward * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = rb.velocity;

        if (flatVel.magnitude > moveSpeedForward)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeedForward;
            rb.velocity = limitedVel;
        }
    }
}
