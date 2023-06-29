using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector3 movements = Vector3.zero;

    [Header("Player Parameters")]
    public Transform orientation;
    Vector3 moveDirection;
    Rigidbody rb;
    private PlayerLook Look;
    float horizontalInput;
    float verticalInput;
    public float moveSpeed;

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
    [SerializeField] float LightCounter;

    private void Update()
    {
        Movements();
        Raycasts();
        DeadCheck();
        Sprint();

        Cursor.visible = false;
    }

    private void Awake()
    {
        isFire = false;
        LightCounter = 0;
    }

    private void Movements()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
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

            isInteract = false;
        }
    }

    private void Sprint()
    {
        if (isRunning)
        {
            moveSpeed = 8;
        }
        else
        {
            isRunning = false;
            moveSpeed = 5;
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
