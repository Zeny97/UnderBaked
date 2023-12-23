using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    GameObject cameraHolder;

    [Header("Look")]
    [SerializeField] private Vector2 mouseSensitivity;
    [SerializeField] private float lookRotation;
    Vector2 look;

    [Header("Movement")]
    [SerializeField] private float moveSpeedMultiplier;
    [SerializeField] private float maxMoveSpeed;
    Vector2 move;

    [Header("GroundCheck")]
    [SerializeField] bool isGrounded;
    [SerializeField] float playerWidth;
    [SerializeField] float playerHeigth;

    void Start()
    {
        PlayerValueSetup();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void PlayerValueSetup()
    {
        playerWidth = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
    }

    private void GroundCheck()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }
    private void LateUpdate()
    {
        
    }

    private void Move()
    {

        moveSpeed *= new Vector3(move.x,0,move.y) * moveSpeedMultiplier;
        rb.AddForce(moveSpeed, ForceMode.Force);

    }

    private void Look()
    {

    }

    public void OnJump()
    {
        Jump();
    }

    private void Jump()
    {

    }


    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }
}
