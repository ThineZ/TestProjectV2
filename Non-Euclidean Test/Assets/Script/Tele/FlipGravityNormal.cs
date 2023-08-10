using UnityEngine;

public class FlipGravityNormal : MonoBehaviour
{
    [Header("Player Object")]
    public GameObject PlayerObj;

    [SerializeField] public bool PlayerDectected = false;

    [Space]
    [Header("Euler Paramenters")]
    public float X;
    public float Y;
    public float Z;

    private void Update()
    {
        if (PlayerDectected)
        {
            Physics.gravity = new Vector3(0f, -9.81f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerDectected = true;
            PlayerObj.transform.rotation = Quaternion.Euler(X, Y, Z);
        }
    }
}
