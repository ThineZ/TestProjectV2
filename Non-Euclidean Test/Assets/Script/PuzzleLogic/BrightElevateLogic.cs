using Unity.VisualScripting;
using UnityEngine;

public class BrightElevateLogic : MonoBehaviour
{
    [Header("Bridge Animation")]
    [Space]
    public Animator Anim;

    [Header("Match CS")]
    [Space]
    public MatchPuuzleLogic[] MPL;
    

    private void Update()
    {
        MatchDetect();
    }

    private void MatchDetect()
    {
        if (MPL[0].ifColl && MPL[1].ifColl && MPL[2].ifColl)
        {
            Anim.SetBool("AllMatch", true);
        }
    }
}
