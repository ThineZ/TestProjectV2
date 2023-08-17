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

    [Space]
    [Header("Lvl")]
    public GameObject Lvl;

    private void Update()
    {
        if(ObjectTrigger) 
        {
            ActiveObj.SetActive(true);
            Objects[0].SetActive(false);
            Lvl.SetActive(true);
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
