using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform portalOther;

    void Update()
    {
        offSet();
    }

    public void offSet()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - portalOther.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDifference = Quaternion.Angle(portal.rotation, portalOther.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifference, Vector3.up);
        Vector3 newCamDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCamDirection, Vector3.up);
    }
}