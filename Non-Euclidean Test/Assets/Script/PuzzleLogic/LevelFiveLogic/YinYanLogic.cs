using UnityEngine;

public class YinYanLogic : MonoBehaviour
{
    [Header("Black YinYan")]
    [Space]
    public GameObject[] BlackYY;

    [Header("White YinYan")]
    [Space]
    public GameObject[] WhiteYY;

    [Header("Fire")]
    [Space]
    public GameObject Fire;

    [Header("Bool Checker")]
    [Space]
    public bool isTriggered = false;
    [Space]
    public int ObjectCount = 0;

    private void Update()
    {
        if (ObjectCount >= 5)
        {
            ObjectCount = 4;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "YY_YingCube_Black" || other.gameObject.name == "YY_YangCube_White")
        {
            isTriggered = true;
            ObjectCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "YY_YingCube_Black" || other.gameObject.name == "YY_YangCube_White")
        {
            isTriggered = false;
            ObjectCount--;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "YY_YingCube_Black" || other.gameObject.name == "YY_YangCube_White")
        {
            isTriggered = true;
        }
    }
}
