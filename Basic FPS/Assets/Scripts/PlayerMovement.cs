using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;

    public float movementSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public Transform grenade;

    bool atGrenade = false;
    Vector3 grenadePosition;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        grenadePosition = grenade.transform.position;
        Debug.Log(grenadePosition);
        if (!atGrenade)
        {
          characterController.transform.position = grenadePosition;
          atGrenade = true;
          Debug.Log(characterController.transform.position);
        }
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

        characterController.Move(movementDirection * movementSpeed * Time.deltaTime);
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
}
