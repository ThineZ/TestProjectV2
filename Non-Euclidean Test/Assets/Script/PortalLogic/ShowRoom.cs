using UnityEngine;
using UnityEngine.Rendering;

public class ShowRoom : MonoBehaviour
{
    [Header("Room Location Box Collider")]
    public Transform Location;

    public GameObject PlayerObj;

    [SerializeField] private bool PlayerDetected = false;

    public float XRotation;
    public float YRotation;
    public float ZRotation;

    private void Update()
    {
        if (PlayerDetected)
        {
            XRotation = PlayerObj.transform.rotation.x;
            YRotation = PlayerObj.transform.rotation.y;
            ZRotation = PlayerObj.transform.rotation.z;

            var SetRotation = Quaternion.Euler(0f, 0.9989074f, 0f);
            var Rotation = Quaternion.Euler(XRotation,YRotation,ZRotation);

            if (Rotation == SetRotation)
            {
                PlayerObj.transform.position = Location.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerDetected = false;
        }
    }
}
