using UnityEngine;

public class TriggerToLevelOne : MonoBehaviour
{
    [Header("Box Collider To Level One")]
    public GameObject BoxTrigger;
    [SerializeField] private bool PlayerTrigger = false;
    [Space]
    [Header("Player Object")]
    public GameObject PlayerObj;
    [Space]
    [Header("Location Transform")]
    public Transform LocationObj;
 
    private void Update()
    {
        if (PlayerTrigger)
        {
            BoxTrigger.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.name == "Player")
        {
            PlayerTrigger = false;
        }
    }
}
