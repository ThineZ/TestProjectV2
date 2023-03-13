using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    Vector3 movements = Vector3.zero;

    [Header("Player Parameters")]
    public float moveSpeed;
    public float JumpHeight;
    public bool canJump;
    private PlayerLook Look;


    [Header("Raycast Parameters")]
    public float interactionDistance;
    // Bool Check
    [SerializeField] private bool isInteract = false;
    [SerializeField] private bool isDrop = false;


    [Header("Transform")]
    public Transform GrabTransform;


    [Header("Pick Object Parameter")]
    public GameObject PickObject;
    public Rigidbody PickObjectRB;
    public bool isHolding = false;


    private void Update()
    {
        Movements();
        Raycasts();
    }

    private void Movements()
    {
        Vector3 moveVector = Vector3.zero;

        // Add the forward direction of the player multiplied by the forward force
        moveVector += transform.forward * movements.y;

        // Add the right direction of the player mutiplie by the right force
        moveVector += transform.right * movements.x;

        // Apply the movment vector multiplied by movement speed to the player's position
        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }

    private void Raycasts()
    {
        Look = GetComponent<PlayerLook>();

        Camera playerCamera = Look.PlayerCam;

        // Draw line that mimics the raycast.
        Debug.DrawLine(playerCamera.transform.position, playerCamera.transform.position + (playerCamera.transform.forward * interactionDistance));

        // Create local RaycastHit varible to store the raycast information
        RaycastHit hitInfo;

        // Check if the ray hits any objects
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, interactionDistance))
        {
            // Print the name of the object hit
            Debug.Log(hitInfo.transform.name);

            if (hitInfo.transform.tag == "PickableObject")
            {
                if (isInteract)
                {
                    Debug.Log("Is Grabing");
                    PickUpObject(hitInfo.transform.gameObject);
                    isHolding = true;
                }
            }

            if (hitInfo.transform.tag == "TargetedSpaces")
            {
                if (isDrop)
                {
                    if (isHolding)
                    {
                        Debug.Log("Is Droping");
                        DropObject();
                        isHolding = false;
                    }
                }
            }
            isInteract = false;
            isDrop = false;
        }
    }

    void PickUpObject(GameObject pickUpObject)
    {
        if (pickUpObject.GetComponent<Rigidbody>())
        {
            PickObject = pickUpObject;
            PickObjectRB = pickUpObject.GetComponent<Rigidbody>();
            PickObjectRB.isKinematic = true;
            PickObject.transform.parent = GrabTransform;
            PickObject.transform.position = GrabTransform.position;
            PickObject.transform.tag = "TargetedSpaces";
        }
    }

    void DropObject()
    {
        PickObjectRB.isKinematic = false;
        PickObject.transform.parent = null;
        PickObject.transform.tag = "PickableObject";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    void OnMove(InputValue moveValue)
    {
        movements = moveValue.Get<Vector2>();
    }

    void OnJump(InputValue jumpValue)
    {
        if (canJump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);
            canJump = false;
        }
    }

    void OnInteract(InputValue interactValue)
    {
        isInteract = true;
    }

    void OnDrop(InputValue dropValue)
    {
        isDrop = true;
    }
}
