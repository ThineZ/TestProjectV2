using UnityEngine;

public class SimlessPassThru : MonoBehaviour
{
    [Header("Layer Array")]
    public GameObject[] LayerObject;

    [Header("Player Camera")]
    public Camera MainCamera;

    public int[] LayerIndex;

    public bool isTrigger = false;

    private void Update()
    {
        TriggerEnable();
        TriggerDisable();
    }

    private void TriggerEnable()
    {
        if (isTrigger)
        {
            LayerObject[0].layer = LayerIndex[0];
            LayerObject[1].layer = LayerIndex[1];
        }
        isTrigger = false;
    }

    private void TriggerDisable() 
    {        
        if (isTrigger == true && LayerObject[0].layer == LayerIndex[0])
        {
            LayerObject[0].layer = LayerIndex[1];
            LayerObject[1].layer = LayerIndex[0];
        }
        isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera") 
        {
            isTrigger = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Main Camera")
        {
            isTrigger = true;
        }
    }
}