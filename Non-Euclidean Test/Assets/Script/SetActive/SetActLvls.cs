using UnityEngine;

public class SetActLvls : MonoBehaviour
{
    [Header("Lvl List")]
    [Space]
    public GameObject LevelName;

    [Space]
    public bool isTrigger = false;

    private void Update()
    {
        if (isTrigger)
        {
            LevelName.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player") 
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isTrigger = false;
        }
    }
}
