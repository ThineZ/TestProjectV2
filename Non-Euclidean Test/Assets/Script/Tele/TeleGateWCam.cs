using System.Collections;
using UnityEngine;

public class TeleGateWCam : MonoBehaviour
{
    public GameObject Receiver;
    public GameObject Player;
    public PlayerController PlayerController;
    public GameObject PickUpObj;
    public PickObject PickUpScript;

    public bool isEntered = false;

    [Space]
    [Header("Pos Values For Player")]
    public float X;
    public float Y;
    public float Z;

    private void Update()
    {
        StartCoroutine(Tele());

        if (PickUpScript.Dot.color == Color.yellow)
        {
            PickUpObj = PickUpScript.GCurrentObj;
        }
        else if (PickUpScript.Dot.color == Color.red)
        {
            PickUpObj = null;
        }
    }

    IEnumerator Tele()
    {
        if (isEntered)
        {
            if (isEntered && PickUpObj == null) 
            {
                PickUpObj = null;
            }
            else if (isEntered && PickUpObj != null)
            {
                PickUpObj.transform.parent = Player.transform;
            }
            PlayerController.isDead = true;
            yield return new WaitForSeconds(0.01f);
            Player.transform.rotation = Quaternion.Euler(Player.transform.rotation.eulerAngles + new Vector3(X,Y,Z));
            Player.transform.position = Receiver.transform.position;
            yield return new WaitForSeconds(0.01f);
            PlayerController.isDead = false;
            if (!isEntered && PickUpObj != null)
            {
                PickUpObj.transform.parent = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isEntered = true;
        }

        if (other.gameObject.layer == 10)
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

        if (other.gameObject.layer == 10)
        {
            isEntered = false;
        }
    }
}