using System.Collections;
using UnityEngine;

public class AssetLogoFadeLogic : MonoBehaviour
{
    [Header("Animator Parameter")]
    public Animator Logo;
    public Animator FadingTitle;

    IEnumerator AnimFSM()
    {
        Logo.SetBool("IfLogoFade", true);
        yield return new WaitForSeconds(0.5f);
        FadingTitle.SetBool("Play", true);
    }

    private void Awake()
    {
        StartCoroutine(AnimFSM());
    }
}
