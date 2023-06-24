using UnityEngine;

public class TeleConfuse : MonoBehaviour
{
    //public Transform Location;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.transform.rotation = Quaternion.Euler(0f, -270f, 0f);
        }
    }
}
