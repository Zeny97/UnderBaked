using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header ("Interaction")]
    private Rigidbody rb;
    [SerializeField] private LayerMask countersLayerMask;

    [Header("Movement")]
    private Vector2 inputVector;
    [Range(0f, 1000f)] [SerializeField] private float movespeed = 600f;
    [Range(0f, 20f)] [SerializeField] private float rotationSpeed = 10f;
    [Range(0f, 1f)] [SerializeField] private float dashCooldown;
    [SerializeField] private float dashMultiplier = 1.5f;
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private bool canDash;
    [SerializeField] private bool isDashing;
    private Vector3 moveDirection;
    private float moveDistance;

    [Header("Animation")]
    [SerializeField] private bool isWalking;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Application.targetFrameRate = 60;
    }
    private void FixedUpdate()
    {
        HandleMovement(inputVector);
        
    }


    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        inputVector = callbackContext.ReadValue<Vector2>();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            HandleInteraction();
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started && canDash)
        {
            rb.AddForce(moveDirection * moveDistance * dashMultiplier, ForceMode.Impulse);
            isDashing = true;
            canDash = false;
            StartCoroutine(C_DashReset());
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
        }
    }

    private IEnumerator C_DashReset()
    {
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleMovement(Vector2 _inputVector)
    {
        if (isDashing)
        {
            return;
        }

        // Player has the same magnitude in all directions including diagonal
        inputVector = inputVector.normalized;

        // Move Player
        moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        moveDistance = movespeed * Time.fixedDeltaTime;
        rb.velocity = moveDirection * moveDistance;

        // parameter for Animation
        isWalking = moveDirection != Vector3.zero;

        // Player rotation
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotationSpeed * Time.fixedDeltaTime);
    }

    private void HandleInteraction()
    {
        float interactDistance = 2f;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, countersLayerMask))
        {
            IInteractable InteractObject = hit.collider.GetComponent<IInteractable>();

            if (InteractObject != null)
            {
                InteractObject.Interact();
            }
        }
    }
}
