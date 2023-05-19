using System.Collections;
using UnityEngine;

public class RotatingPlatfrom : MonoBehaviour
{
    [Header("Player Object")]
    public GameObject Player;
    public PlayerController PlayerController;
    [Space]
    [Header("Teleport Object")]
    public GameObject TeleCollider;

    public bool isEnter = false;

    private void Update()
    {
        StartCoroutine(Tele());
    }

    IEnumerator Tele()
    {
        if (isEnter)
        {
            PlayerController.isDead = true;
            yield return new WaitForSeconds(0.01f);
            Player.transform.Rotate(Vector3.right / 180);
            Player.transform.position = TeleCollider.transform.position;
            yield return new WaitForSeconds(0.01f);
            PlayerController.isDead = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isEnter = false;
        }
    }
}
