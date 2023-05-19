using UnityEngine;

public class ColorMatchLock : MonoBehaviour
{
    [Header("Key Object")]
    public GameObject KeyObj;

    [Space]
    [Space]
    public GameObject ColorHint;
    [Space]
    [Space]
    public Material Yellow;
    public MeshRenderer ControlPanelMR;

    [Header("Stencil Layer")]
    public GameObject GateQuad;

    [Header("Tele Object")]
    public GameObject Tele;

    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void Update()
    {
        if (KeyObj.tag == "Untagged")
        {
            GateQuad.layer = 6;
            Tele.SetActive(true);
        }        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == KeyObj)
        {
            KeyObj.transform.position = transform.position;
            KeyObj.transform.rotation = transform.rotation;

            KeyObj.GetComponent<Rigidbody>().isKinematic = true;
            KeyObj.GetComponent<Rigidbody>().useGravity = false;


            if (other.tag == "PickableObject")
            {
                KeyObj.tag = "Untagged";
                ColorHint.SetActive(false);
                ControlPanelMR.material = Yellow;
            }
        }
    }
}
