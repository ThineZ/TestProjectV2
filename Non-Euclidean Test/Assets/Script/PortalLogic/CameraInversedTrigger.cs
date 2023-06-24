using UnityEngine;

public class CameraInversedTrigger : MonoBehaviour
{
    [Header("Follow Camera")]
    public Camera FollowCamera;
    [Space]
    [Header("Player Object Target & Player Main Camera")]
    public Transform PlayerObjectTarget;
    public Transform PlayerMainCamera;
    [Space]
    [Header("OffSet Parameter")]
    public Vector3 OffSet;
    public float OffsetFollowSpeed;
    public bool PlayerEnter = false;
    [Space]
    [Header("Projection Camera Rotation Values")]
    public float X;
    public float Y;
    public float Z;

    private void FixedUpdate()
    {
        if (PlayerEnter)
        {
            Vector3 ManualPosition = PlayerObjectTarget.position + OffSet;
            Vector3 PostionWithSpeed = Vector3.Lerp(FollowCamera.transform.position, ManualPosition, OffsetFollowSpeed);
            FollowCamera.transform.position = PostionWithSpeed;
        }
    }

    private void Update()
    {
        if (PlayerEnter)
        {
            Quaternion InversedRotation = Quaternion.Inverse(PlayerMainCamera.rotation);
            FollowCamera.transform.rotation = Quaternion.Euler(X,Y,Z) * Quaternion.Inverse(InversedRotation);
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
