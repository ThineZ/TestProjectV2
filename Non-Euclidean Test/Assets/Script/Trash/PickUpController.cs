using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public GameObject Player;
    public Transform GrabTransform;

    [Header("Parameters")]
    public float throwForce = 500f;
    public float pickUpRange = 5f;
    public float RotationSensitivity = 1f;

    [Header("Pickup Settings")]
    public GameObject PickObject;
    public Rigidbody PickObjectRB;
    [SerializeField] private bool canDrop = false;
    private int LayerIndex;

    private void Start()
    {
        LayerIndex = LayerMask.NameToLayer("HoldLayer");
    }

    private void Update()
    {
        PickUp();
    }

    private void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PickObject = null)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    if (hit.transform.gameObject.tag == "PickableObject")
                    {
                        PickUpObject(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                if (canDrop)
                {
                    StopClipping();
                    DropObject();
                }
            }
        }
        if (PickObject != null)
        {
            MoveObject();

            if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop == true)
            {
                StopClipping();
                ThrowObject();
            }
        }
    }

    void PickUpObject(GameObject pickUpObject)
    {
        if (pickUpObject.GetComponent<Rigidbody>())
        {
            PickObject = pickUpObject;
            PickObjectRB = pickUpObject.GetComponent<Rigidbody>();
            PickObjectRB.isKinematic = true;
            PickObjectRB.transform.parent = GrabTransform.transform;
            PickObject.layer = LayerIndex;

            Physics.IgnoreCollision(PickObject.GetComponent<Collider>(), Player.GetComponent<Collider>(), true);
        }
    }

    void DropObject()
    {
        Physics.IgnoreCollision(PickObject.GetComponent<Collider>(), Player.GetComponent<Collider>(), false);
        PickObject.layer = 0;
        PickObjectRB.isKinematic = false;
        PickObject.transform.parent = null;
        PickObject = null;
    }

    void MoveObject()
    {
        PickObject.transform.position = GrabTransform.transform.position;
    }

    void ThrowObject()
    {
        //same as drop function, but add force to object before undefining it
        Physics.IgnoreCollision(PickObject.GetComponent<Collider>(), Player.GetComponent<Collider>(), false);
        PickObject.layer = 0;
        PickObjectRB.isKinematic = false;
        PickObject.transform.parent = null;
        PickObjectRB.AddForce(transform.forward * throwForce);
        PickObject = null;
    }

    void StopClipping()
    {
        var clipRange = Vector3.Distance(PickObject.transform.position, transform.position);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);

        if (hits.Length > 1)
        {
            PickObject.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
        }
    }
}