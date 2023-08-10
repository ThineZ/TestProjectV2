using UnityEngine;

public class PrismTriggerSnap : MonoBehaviour
{
    [Space]
    [Header("Objects to trigger")]
    public GameObject[] Objects;

    [Space]
    [Header("Active Object")]
    public GameObject ActiveObj;

    [Space]
    [Header("Bool Check")]
    public bool ObjectTrigger = false;

    private void Update()
    {
        if(ObjectTrigger) 
        {
            ActiveObj.SetActive(true);
            Objects[0].SetActive(false);
            Destroy(Objects[1]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Objects[0].name)
        {
            ObjectTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == Objects[0].name)
        {
            ObjectTrigger = false;
        } 
    }
}
