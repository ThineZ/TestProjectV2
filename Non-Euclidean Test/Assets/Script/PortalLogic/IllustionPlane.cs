using System.ComponentModel;
using UnityEngine;

public class IllustionPlane : MonoBehaviour
{
    [Header("Masked Layer Object")]
    public GameObject[] MaskedLayerObj;

    [Space]
    [Header("Layer Index")]
    public int LayerIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            foreach (GameObject i in MaskedLayerObj)
            {
                i.layer = LayerIndex;
            }
        }
    }
}
