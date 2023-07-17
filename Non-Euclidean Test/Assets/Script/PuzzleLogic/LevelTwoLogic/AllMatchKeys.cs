using UnityEngine;

public class AllMatchKeys : MonoBehaviour
{
    [Header("List")]
    public GameObject[] list;

    [Space]
    [Header("Bool Check")]
    public bool AllCorrect = false;

    [Space]
    [Header("Match Keys SC")]
    public MatchKeys[] MatchKeysSC;

    private void Update()
    {
        Active();
    }

    public void Active()
    {
        Debug.Log("----------------------------------------------------------------------------------");
        AllCorrect = true;
        foreach (MatchKeys i in MatchKeysSC)
        {
            Debug.Log(i.name + i.Correct);
            if (i.Correct != true)
            {
                AllCorrect = false;
                break;
            }
        }
        Debug.Log("----------------------------------------------------------------------------------");
    }
}