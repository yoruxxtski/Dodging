using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // ----- Attributes -----------------

    // * Attribute

    [Header("Movement Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Vector3 moveDirection;



    // * Component
    private Rigidbody playerRigidBody;

    // ----- Unity Functions ------------
    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ReadMovement();
    }

    void FixedUpdate()
    {
        if (moveDirection != Vector3.zero) {
            Move();
            // Rotate();
        }
    }
    // ----- User Defined Functions -----
    public void ReadMovement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontalInput, 0, verticalInput);
    }

    public void Move() {
        Vector3 newPosition = transform.position + moveDirection * speed * Time.fixedDeltaTime;
        playerRigidBody.MovePosition(newPosition);
    }
    public void Rotate() {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        Quaternion newRotation = Quaternion.RotateTowards(playerRigidBody.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        playerRigidBody.MoveRotation(newRotation);
    }
    // ----- Getter & Setter ------------
}
