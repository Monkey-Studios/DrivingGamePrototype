using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(CharacterController))]

public class CharacterControllerScript : MonoBehaviour
{
    CharacterController characterController;
    public GameObject camera;
    public Text text;
    public float speed = 6.0f;
    public float rotationSpeed = 5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float interactionRange = 3f;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if(Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
        Interaction();
    }
    //Used to open and close the chest within the scene.
    void Interaction()
    {
        RaycastHit interactionObject;

        Debug.DrawRay(this.transform.position, this.transform.forward * interactionRange, Color.green);

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out interactionObject, interactionRange))
        {
            Debug.Log("I  can interact with " + interactionObject.collider.gameObject.name);
            text.enabled = true;

            if (Input.GetKeyDown(KeyCode.F))
            {
                interactionObject.collider.SendMessageUpwards("Interact");
            }
        }
        else
        {
            text.enabled = false;
        }
    }

}
