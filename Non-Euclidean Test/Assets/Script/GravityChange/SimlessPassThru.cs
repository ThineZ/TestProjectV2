using System.Collections;
using UnityEngine;

public class SimlessPassThru : MonoBehaviour
{
    [SerializeField] bool isTrigger = false;
    [SerializeField] int TriggerCount;

    [Header("ToMask Layer Objects")]
    public GameObject[] ToMaskObjects;

    [Header("Default Layer Object")]
    public GameObject[] DefaultObjects;

    [Header("View Object")]
    public GameObject ViewOneClip;
    public GameObject ViewTwoClip;

    private void Update()
    {
        //SwitchLayer();

        StartCoroutine(SwitchLayerDelay());

        if (TriggerCount >= 2)
        {
            TriggerCount = 0;
        }

        isTrigger = false;
    }

    IEnumerator SwitchLayerDelay()
    {
        if (isTrigger)
        {
            TriggerCount++;

            // To Switch the ToMaskObject to Default Layer and Set ViewOne (SetActive = false)
            if (TriggerCount == 1)
            {
                ViewOneClip.SetActive(false);
                ViewTwoClip.SetActive(true);

                foreach (GameObject i in ToMaskObjects)
                {
                    i.layer = 0;
                }

                foreach (GameObject j in DefaultObjects)
                {
                    j.layer = 7;
                }
            }


            // To Switch the ToMaskObject to ToMask Layer and Set ViewTwo (SetActive = false)
            if (TriggerCount == 2)
            {
                ViewOneClip.SetActive(true);
                ViewTwoClip.SetActive(false);

                foreach (GameObject i in ToMaskObjects)
                {
                    i.layer = 7;
                }

                foreach (GameObject j in DefaultObjects)
                {
                    j.layer = 0;
                }
            }
        }
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isTrigger = false;
        }
    }
}