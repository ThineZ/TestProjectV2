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
            FollowCamera.transform.rotation = Quaternion.EulerAngles(PlayerMainCamera.rotation.x, PlayerObjectTarget.rotation.y, 0);
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