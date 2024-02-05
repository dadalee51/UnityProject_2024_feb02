using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public float speed = 5.0f;
    public float rotationSpeed = 500.0f;
    public float jumpForce = 8.0f;
    private float verticalVelocity;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the character is grounded
        isGrounded = characterController.isGrounded;

        // Handle player movement
        MovePlayer();

        // Handle player jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // Apply gravity
        ApplyGravity();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Calculate rotation towards the input direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);

            // Apply rotation
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Calculate movement
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection * speed * Time.deltaTime);
        }
    }

    void Jump()
    {
        verticalVelocity = jumpForce;
    }

    void ApplyGravity()
    {
        // Apply gravity only if the character is not grounded
        if (!isGrounded)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        // Apply vertical velocity
        characterController.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);
    }
}
