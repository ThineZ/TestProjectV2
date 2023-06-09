using UnityEngine;

public class TriggerStencil : MonoBehaviour
{
    public GameObject[] LayerObject;

    public int TriggerCounter;

    public int[] LayerInt;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TargetedSpaces")
        {
            TriggerCounter++;

            Debug.Log("Trigger Count" + TriggerCounter);

            foreach (GameObject i in LayerObject)
            {
                if (TriggerCounter == 1) 
                {
                    i.layer = LayerInt[0];
                    i.GetComponent<BoxCollider>().isTrigger = false;
                }

                if (TriggerCounter == 2)
                {
                    i.layer = LayerInt[1];
                    i.GetComponent<BoxCollider>().isTrigger = true;
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
