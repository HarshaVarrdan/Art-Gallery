using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 5f;
    public float rotationSpeed = 200f;

    private CharacterController characterController;

    public bool bCanMove = true;

    public static PlayerController pc_Instance;

    private void Awake()
    {
        if(pc_Instance == null)
            pc_Instance = this;
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(bCanMove) 
        {
            // Player movement
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = transform.forward * moveVertical * movementSpeed * Time.deltaTime;
            characterController.Move(movement);

            // Player rotation
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, rotation, 0f);
        }
    }
}


