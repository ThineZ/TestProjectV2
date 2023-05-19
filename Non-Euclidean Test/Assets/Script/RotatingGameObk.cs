using System.Collections;
using UnityEngine;

public class RotatingGameObk : MonoBehaviour
{
    [Header("Position")]
    public GameObject In;
    public GameObject Out;
    [Space]
    [Header("Colliders")]
    public GameObject InCollider;
    public GameObject OutCollider;
    [Space]
    [Header("Player Object")]
    public PlayerController PlayerController;
    public GameObject Player;

    public GameObject R;

    bool EnterCheck = false;

    private void Update()
    {
        if (EnterCheck)
        {
            StartCoroutine(TeleIn());
            RotateObj();
        }
        else 
        {
            StartCoroutine(TeleOut());
            RotateObjBack();
        }
        StartCoroutine(TeleOut());
    }

    private void RotateObj()
    {
        R.transform.Rotate(Vector3.forward, -90);
    }

    private void RotateObjBack() 
    {
        R.transform.Rotate(Vector3.forward, 90);
    }

    IEnumerator TeleIn()
    {
        if (EnterCheck) 
        {
            PlayerController.isDead = true;
            yield return new WaitForSeconds(0.01f);
            Player.transform.Rotate(Vector3.right / 180);
            Player.transform.position = InCollider.transform.position;
            yield return new WaitForSeconds(0.01f);
            PlayerController.isDead = false;
        }
    }

    IEnumerator TeleOut()
    {
        if (EnterCheck)
        {
            PlayerController.isDead = true;
            yield return new WaitForSeconds(0.01f);
            Player.transform.Rotate(Vector3.right / -180);
            Player.transform.position = OutCollider.transform.position;
            yield return new WaitForSeconds(0.01f);
            PlayerController.isDead = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player") 
        {
            EnterCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player") 
        {
            EnterCheck = false;
        }
    }
}
