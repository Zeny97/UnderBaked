using System;
using UnityEngine;
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

    [Header("Animation")]
    [SerializeField] private bool isWalking;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
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
            HandleInteractions();
        }
    }
    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleMovement(Vector2 _inputVector)
    {
        // Player has the same magnitude in all directions including diagonal
        inputVector = inputVector.normalized;

        // Move Player
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        float moveDistance = movespeed * Time.deltaTime;
        rb.velocity = moveDirection * moveDistance;

        // parameter for Animation
        isWalking = moveDirection != Vector3.zero;

        // Player rotation
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotationSpeed * Time.deltaTime);
    }

    private void HandleInteractions()
    {
        float interactDistance = 2f;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, interactDistance, countersLayerMask))
        {
            IInteractable InteractObject = hit.collider.GetComponent<IInteractable>();

            if (InteractObject != null)
            {
                InteractObject.Interact();
            }
        }
    }
}
