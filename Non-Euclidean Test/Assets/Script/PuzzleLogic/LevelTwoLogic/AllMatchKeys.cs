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

    [Space]
    [Header("MP Items")]
    public Animator MP_Ball;
    public GameObject Projector;

    [Space]
    [Header("Lvl 3")]
    public GameObject Lvl3;

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

        if (AllCorrect)
        {
            MP_Ball.SetBool("Play", true);
            Projector.SetActive(true);
            Lvl3.SetActive(true);
        }
    }
}