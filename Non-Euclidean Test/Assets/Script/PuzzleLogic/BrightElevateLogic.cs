using UnityEngine;

public class BrightElevateLogic : MonoBehaviour
{
    [Header("Bridge Animation")]
    public Animator Anim;
    [Space]
    [Header("Match CS")]
    public MatchPuuzleLogic[] MPL;

    private void Update()
    {
        MatchDetect();
    }

    private void MatchDetect()
    {
        if (MPL[0].gameObject.GetComponent<MeshRenderer>().material.color != MPL[0].Mat.color && 
            MPL[1].gameObject.GetComponent<MeshRenderer>().material.color != MPL[1].Mat.color &&
            MPL[2].gameObject.GetComponent<MeshRenderer>().material.color != MPL[2].Mat.color)
        {
            Anim.SetBool("AllMatch", true);
        }
    }
}
