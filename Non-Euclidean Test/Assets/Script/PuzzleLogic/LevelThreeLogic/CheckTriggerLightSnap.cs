using UnityEngine;
using System.Linq;

public class CheckTriggerLightSnap : MonoBehaviour
{
    [Space]
    [Header("Light Box Object List")]
    public GameObject[] LightBox;

    [Space]
    [Header("Pramide")]
    public GameObject Pri;

    [Space]
    [Header("Projection Plane")]
    public GameObject ProjectionPlane;


    private void LateUpdate()
    {
        foreach (GameObject i in LightBox)
        {
            if (LightBox.All(LightBox => LightBox.GetComponent<Rigidbody>().isKinematic == true))
            {
                Pri.SetActive(true);
                ProjectionPlane.GetComponent<MeshRenderer>().enabled = true;
                break;
            }
        }
    }
}
