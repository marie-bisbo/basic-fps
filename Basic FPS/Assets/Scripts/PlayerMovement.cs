using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;

    public float movementSpeed = 12f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = transform.right * xInput + transform.forward * zInput;

        characterController.Move(movementDirection * movementSpeed * Time.deltaTime);
    }
}
