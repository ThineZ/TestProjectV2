using System.Collections;
using UnityEngine;

public class TeleCollideStop : MonoBehaviour
{
    [Header("Gate Collider")]
    public GameObject GateCollider;
    public TeleGateWCam TeleGateWCamScript;

    bool ifCollided = false;

    private void Awake()
    {
        TeleGateWCamScript = GateCollider.GetComponent<TeleGateWCam>();
    }

    private void Update()
    {
        StartCoroutine(CheckIfCollided());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            ifCollided = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            ifCollided = false;
        }
    }

    IEnumerator CheckIfCollided()
    {

        if (ifCollided)
        {
            GateCollider.GetComponent<BoxCollider>().isTrigger = false;
            TeleGateWCamScript.enabled = false;

            yield return new WaitForSeconds(1.5f);

            GateCollider.GetComponent <BoxCollider>().isTrigger = true;
            TeleGateWCamScript.enabled = true;
        }
    }
}