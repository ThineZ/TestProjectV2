using UnityEngine;

public class CameraFollowTrigger : MonoBehaviour
{
    [Header("Follow Camera")]
    public Camera FollowCamera;

    [Header("Player Object Target & Player Main Camera")]
    public Transform PlayerObjectTarget;
    public Transform PlayerMainCamera;

    [Header("Offset Parameter")]
    public Vector3 Offset;
    public Quaternion PlayerCamRotation;
    public float OffsetFollowSpeed;
    public bool PlayerEnter = false;

    private void FixedUpdate()
    {
        if (PlayerEnter)
        {
            Vector3 ManualPosition = PlayerObjectTarget.position + Offset;
            Vector3 PostionWithSpeed = Vector3.Lerp(FollowCamera.transform.position, ManualPosition, OffsetFollowSpeed);
            FollowCamera.transform.position = PostionWithSpeed;
        }
    }

    private void Update()
    {
        if (PlayerEnter) 
        {
            // Consitent update of Player Camera Rotation Values in Quaternion
            PlayerCamRotation = PlayerMainCamera.rotation;
            
            // Set the "PlayerCamRotation Quaternion Values to FollowCamera Rotation"
            FollowCamera.transform.rotation = PlayerCamRotation;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerEnter = true;
        }
    }
}