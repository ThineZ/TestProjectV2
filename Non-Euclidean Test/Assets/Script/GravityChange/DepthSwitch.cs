using System.Collections;
using UnityEngine;

public class DepthSwitch : MonoBehaviour
{
    [Header("Materials")]
    public Material Opaque;
    public Material Transparent;

    [Header("Depth Gate")]
    public GameObject DepthGateTransparent;
    public GameObject DepthGateOpaque;

    [SerializeField] bool isSwitched = false;
    [SerializeField] int SwitchedCount = 0;

    private void Update()
    {
        StartCoroutine(ShaderTypeSwitch()); 

        if(SwitchedCount >= 3)
        {
            SwitchedCount = 0;
        }
    }

    private IEnumerator ShaderTypeSwitch()
    {
        if (isSwitched)
        {
            Opaque.CopyPropertiesFromMaterial(Transparent);
            Transparent.CopyPropertiesFromMaterial(Opaque);

            DepthGateTransparent.SetActive(false);
            DepthGateOpaque.SetActive(true);
        }

        if (isSwitched && !DepthGateTransparent.activeInHierarchy) 
        {
            Opaque.CopyPropertiesFromMaterial(Opaque);
            Transparent.CopyPropertiesFromMaterial(Transparent);

            DepthGateTransparent.SetActive(true);
            DepthGateOpaque.SetActive(false);
        }

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isSwitched = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isSwitched = false;
        }
    }
}
