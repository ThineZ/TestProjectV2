using System.Collections;
using UnityEngine;

public class FlipGravity : MonoBehaviour
{
    [Header("Player Object")]
    public GameObject PlayerObj;

    [SerializeField] public bool PlayerDectected = false;
    [Space]
    [Header("Gravity Values")]
    public float X;
    public float Y;
    public float Z;
    [Space]
    [Header("Player Rotation")]
    public float RotX;
    public float RotY;
    public float RotZ;


    private void Update()
    {
        StartCoroutine(Gravity());
    }

    IEnumerator Gravity()
    {
        if (PlayerDectected)
        {
            Physics.gravity = new Vector3(X, Y, Z);
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerDectected = true;
            PlayerObj.transform.rotation = Quaternion.Euler(RotX, RotY, RotZ);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerDectected = false;
        }
    }
}
