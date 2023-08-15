using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector3 movements = Vector3.zero;

    [Header("Player Parameters")]
    public float moveSpeed;
    public float runSpeed;
    private PlayerLook Look;

    [Header("Grab Parameters")]
    public Transform ObjPos;
    public GameObject PickObj;


    [Header("Raycast Parameters")]
    public float interactionDistance;
    // Bool Check
    [SerializeField] private bool isInteract = false;
    [SerializeField] bool isRunning = false;
    [SerializeField] bool isFire = false;

    [Header("Dead Check")]
    public bool isDead = false;

    [Space]
    [Header("Light")]
    public Light[] Lights;

    [Space]
    [Header("Puzzle Pieces")]
    public Transform PiecesOne;
    public Transform PiecesTwo;

    private void Update()
    {
        Movements();
        Raycasts();
        DeadCheck();
        Sprint();

        Cursor.visible = false;
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
                //if (isInteract) 
                //{
                    
                //}
            }

            if (isFire && hitInfo.transform.gameObject.layer == 12)
            {
                Lights[0].enabled = true;
                Lights[1].enabled = true;
                Lights[2].enabled = true;
            }

            // Left Pilar Move Left
            if (isInteract && hitInfo.transform.gameObject.name == "PieceOneMoveLeft" || isFire && hitInfo.transform.gameObject.layer == 12)
            {
                PiecesOne.position = new Vector3(PiecesOne.position.x, PiecesOne.position.y, PiecesOne.position.z - 2.5f);
            }
            
            // Right Pilar Move Right
            if (isInteract && hitInfo.transform.gameObject.name == "PieceOneMoveRight" || isFire && hitInfo.transform.gameObject.layer == 12)
            {
                PiecesOne.position = new Vector3(PiecesOne.position.x, PiecesOne.position.y, PiecesOne.position.z + 2.5f);
            }

            // Right Pilar Rotate ClockWise
            if (isInteract && hitInfo.transform.gameObject.name == "PieceOneRotateClockwise" || isFire && hitInfo.transform.gameObject.layer == 12)
            {
                PiecesOne.Rotate(PiecesOne.rotation.x, PiecesOne.rotation.y + 90f, PiecesOne.rotation.z, Space.World);
            }            
            
            // Left Pilar Rotate Counter-ClockWise
            if (isInteract && hitInfo.transform.gameObject.name == "PieceOneRotateCounterClockwise" || isFire && hitInfo.transform.gameObject.layer == 12)
            {
                PiecesOne.Rotate(PiecesOne.rotation.x, PiecesOne.rotation.y - 90f, PiecesOne.rotation.z, Space.World);
            }

            // Left Pilar Move Left
            if (isInteract && hitInfo.transform.gameObject.name == "PieceTwoMoveLeft" || isFire && hitInfo.transform.gameObject.layer == 12)
            {
                PiecesTwo.position = new Vector3(PiecesTwo.position.x, PiecesTwo.position.y, PiecesTwo.position.z - 2.5f);
            }

            // Right Pilar Move Right
            if (isInteract && hitInfo.transform.gameObject.name == "PieceTwoMoveRight" || isFire && hitInfo.transform.gameObject.layer == 12)
            {
                PiecesTwo.position = new Vector3(PiecesTwo.position.x, PiecesTwo.position.y, PiecesTwo.position.z + 2.5f);
            }

            // Left Pilar Rotate Counter-ClockWise
            if (isInteract && hitInfo.transform.gameObject.name == "PieceTwoRotateCounterClockwise" || isFire && hitInfo.transform.gameObject.layer == 12)
            {
                PiecesTwo.Rotate(PiecesTwo.rotation.x, PiecesTwo.rotation.y - 90f, PiecesTwo.rotation.z, Space.World);
            }

            // Right Pilar Rotate ClockWise
            if (isInteract && hitInfo.transform.gameObject.name == "PieceTwoRotateClockwise" || isFire && hitInfo.transform.gameObject.layer == 12)
            {
                PiecesTwo.Rotate(PiecesTwo.rotation.x, PiecesTwo.rotation.y + 90f, PiecesTwo.rotation.z, Space.World);
            }


            isInteract = false;
        }
    }

    private void Sprint()
    {
        if (isRunning)
        {
            Vector3 runVector = Vector3.zero;

            // Add the forward direction of the player multiplied by the forward force
            runVector += transform.forward * movements.y;

            // Add the right direction of the player mutiplie by the right force
            runVector += transform.right * movements.x;

            // Apply the movment vector multiplied by movement speed to the player's position
            transform.position += runVector * runSpeed * Time.deltaTime;
        }
        else
        {
            isRunning = false;
        }
    }

    void DeadCheck()
    {
        if (isDead)
        {
            moveSpeed = 0;
            Look.xSensitivity = 0;
            Look.ySensitivity = 0;
        }
        else if (!isDead)
        {
            moveSpeed = 5;
            Look.xSensitivity = 20;
            Look.ySensitivity = 20;
        }
    }

    void OnMove(InputValue moveValue)
    {
        movements = moveValue.Get<Vector2>();
    }

    void OnInteract(InputValue interactValue)
    {
        isInteract = true;
    }

    void OnRunPress()
    {
        isRunning = true;
    }

    void OnRunRelease()
    {
        isRunning = false;
    }

    void OnFire()
    {
        isFire = true;
    }
    
    void OnFireR()
    {
        isFire = false;
    }
}
