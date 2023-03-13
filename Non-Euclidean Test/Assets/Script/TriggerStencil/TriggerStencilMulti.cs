using UnityEngine;

public class TriggerStencilMulti : MonoBehaviour
{
    [Header("1st Object Layer")]
    public GameObject[] ObjectListOne;

    [Header("2nd Object Layer")]
    public GameObject[] ObjectListTwo;

    [Header("Trigger Check Counter")]
    public int TriggerCounter;

    [Header("Layer Integer")]
    public int[] LayerInt;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TargetedSpaces")
        {
            TriggerCounter++;

            foreach (GameObject i in ObjectListOne)
            {
                if (TriggerCounter == 1)
                {
                    i.layer = LayerInt[0];
                }

                if (TriggerCounter == 2)
                {
                    i.layer = LayerInt[1];
                }
            }

            foreach (GameObject j in ObjectListTwo)
            {
                if (TriggerCounter == 1)
                {
                    j .layer = LayerInt[2];
                }

                if (TriggerCounter == 2)
                {
                    j .layer = LayerInt[3];
                }
            }
        }
    }

    private void Update()
    {
        if (TriggerCounter >= 2)
        {
            TriggerCounter = 0;
        }
    }
}
