using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public Transform reciever;

    private bool playerIsOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            // If this is true: The player has moved across the portal
            if (dotProduct < 0f)
            {
                // Teleport him!
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerIsOverlapping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TargetedSpaces")
        {
            playerIsOverlapping = true;
        }

        if (other.tag == "PickableObject")
        {
            playerIsOverlapping = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TargetedSpaces")
        {
            playerIsOverlapping = false;
        }

        if (other.tag == "PickableObject")
        {
            playerIsOverlapping = false;
        }
    }
}