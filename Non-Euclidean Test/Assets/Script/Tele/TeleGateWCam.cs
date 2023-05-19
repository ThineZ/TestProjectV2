using System.Collections;
using UnityEngine;

public class TeleGateWCam : MonoBehaviour
{
    public GameObject GateObject;
    public GameObject Player;
    public PlayerController PlayerController;

    public bool isEntered = false;

    private void Update()
    {
        StartCoroutine(Tele());
    }

    IEnumerator Tele()
    {
        if (isEntered)
        {
            PlayerController.isDead = true;
            yield return new WaitForSeconds(0.01f);
            Player.transform.Rotate(Vector3.up * 180);
            Player.transform.position = GateObject.transform.position;
            yield return new WaitForSeconds(0.01f);
            PlayerController.isDead = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isEntered = false;
        }
    }
}