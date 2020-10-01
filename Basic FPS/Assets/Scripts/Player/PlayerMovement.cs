using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;

    public float movementSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float thrustSpeed = 10f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        MovePlayer();
        Jump();
        ApplyGravity();
    }

    void MovePlayer()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = transform.right * xInput + transform.forward * zInput;
        
        if(Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(transform.up * thrustSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            characterController.Move(new Vector3(0f, -0.05f, 0f));
        }

        if (Physics.CheckSphere(groundCheck.position, groundDistance, groundMask))
        {
            characterController.Move(movementDirection * movementSpeed * Time.deltaTime);
        }
        else
        {
            characterController.Move(movementDirection * thrustSpeed * Time.deltaTime);
        }
    }

    void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void Teleport(Vector3 position)
    {
        characterController.transform.position = position + new Vector3(0f, 1f, 0f);
        characterController.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
