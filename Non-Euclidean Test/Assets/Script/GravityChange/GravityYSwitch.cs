using System.Collections;
using UnityEngine;

public class GravityYSwitch : MonoBehaviour
{
    public GameObject Player;

    public bool isEntered = false;

    private void Update()
    {
        StartCoroutine(Switch());
    }

    IEnumerator Switch()
    {
        if (isEntered)
        {
            yield return new WaitForSeconds(0.01f);
            Physics.gravity = new Vector3(0,9.81f,0);
            //Player.transform.RotateAround(transform.position, transform.forward, -180);
            Player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }

        else if (isEntered && Player.transform.rotation == Quaternion.Euler(0,0,180))
        {
            yield return new WaitForSeconds(0.01f);
            Physics.gravity = new Vector3(0,-9.81f,0);
            Player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
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
