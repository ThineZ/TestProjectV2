using UnityEngine;

public class Lvl3ToLvl4 : MonoBehaviour
{
    [Header("PrismTriggerSnapSC")]
    [Space]
    public PrismTriggerSnap PTSSC;

    [Header("Projection")]
    [Space]
    public GameObject Projection;

    private void Update()
    {
        CheckKeyInsert();
    }

    public void CheckKeyInsert()
    {
        if (PTSSC.ObjectTrigger == true)
        {
            Projection.SetActive(true);
        }
    }
}