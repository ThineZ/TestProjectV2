using UnityEngine;

public class FlipGravityNormal : MonoBehaviour
{
    [Header("Player Object")]
    public GameObject PlayerObj;

    [SerializeField] public bool PlayerDectected = false;

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
            PlayerObj.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
