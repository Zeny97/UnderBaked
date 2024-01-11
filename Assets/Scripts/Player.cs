using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 7f;
    Vector2 inputVector = new Vector2 (0, 0);

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        // Player has the same magnitude in all directions including diagonal
        inputVector = inputVector.normalized;

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDirection * movespeed * Time.deltaTime;
        transform.forward = moveDirection;
    }

    //private void FixedUpdate()
    //{
    //    Move();
    //}

    //private void Move()
    //{
    //}

    //private void Look()
    //{

    //}

    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    move = context.ReadValue<Vector2>();
    //}

    //public void OnLook(InputAction.CallbackContext context)
    //{
    //    look = context.ReadValue<Vector2>();
    //}
}
