using UnityEngine;

public class FadeInSectionLogic : MonoBehaviour
{
    //[SerializeField] KeyCode AllKey;
    [Space]
    [Header("FadeIn Parameter")]
    public GameObject CanvasFadeIn;
    public Animator FadeInSection;
    [Space]
    [Header("Text Fade Parameter")]
    public Animator[] FadeInText;
    [Space]
    [Header("Border Art Fade In")]
    public Animator[] BorderArt;

    //private void OnGUI()
    //{
    //    Event e = Event.current;
    //    if (e.isKey)
    //    {
    //        AllKey = e.keyCode;
    //        Debug.Log(AllKey);
    //        StartCoroutine(Fade());
    //    }
    //}
    private void Update()
    {
        Fade();
    }
    public void Fade()
    {
        if (Input.anyKeyDown)
        {
            FadeInSection.SetBool("IfAnyKeyPressed", true);
            //yield return new WaitForSeconds(1f);
            FadeInText[0].SetBool("FadeInText", true);
            FadeInText[1].SetBool("FadeInText", true);
            FadeInText[2].SetBool("FadeInText", true);
            //Fade In Border Art
            BorderArt[0].SetBool("FadeIn", true);
            BorderArt[1].SetBool("FadeIn", true);
            BorderArt[2].SetBool("FadeIn", true);
            BorderArt[3].SetBool("FadeIn", true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FadeInSection.SetBool("IfAnyKeyPressed", false);
        }
    }
}
