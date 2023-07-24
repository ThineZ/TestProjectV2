using UnityEngine;

public class TriggerLightSnap : MonoBehaviour
{
    [Space]
    [Header("Light Object Name")]
    public GameObject LightBoxObjName;

    [Space]
    [Header("Bool")]
    public bool IfSnap = false;

    private void Update()
    {
        if (IfSnap)
        {
            LightBoxObjName.GetComponent<Rigidbody>().isKinematic = true;
            LightBoxObjName.transform.position = gameObject.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == LightBoxObjName.name)
        {
            IfSnap = false;

            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == LightBoxObjName.name) 
        {
            IfSnap = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
