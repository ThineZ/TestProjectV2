using System.Collections;
using UnityEngine;

public class ClickTriggerLogic : MonoBehaviour
{
    [Header("Selctions Items")]
    public Animator NewGameAnim;
    public Animator LoadGameAnim;
    public Animator OptionsAnim;
    public Animator ExitAnim;
    public Animator Title;

    [Header("Page Items")]
    public Animator OptionsPageAnim;
    public Animator LoadGamePageAnim;


    public void LoadGameTrigger()
    {
        // Menu Item Slide Out Anim
        OptionsAnim.SetBool("IfOptionTrigger", true);
        NewGameAnim.SetBool("IfNewGameTrigger", true);
        LoadGameAnim.SetBool("IfLoadGameTrigger", true);
        ExitAnim.SetBool("IfExitTrigger", true);

        Title.SetBool("IfTitleTrigger", true);

        // Page Slide In Anim
        LoadGamePageAnim.SetBool("IfLoadClicked", true);
        LoadGamePageAnim.SetBool("IfLoadUnClicked", false);
    }

    public void OptionsTrigger()
    {
        // Menu Item Slide Out Anim
        OptionsAnim.SetBool("IfOptionTrigger", true);
        NewGameAnim.SetBool("IfNewGameTrigger", true);
        LoadGameAnim.SetBool("IfLoadGameTrigger", true);
        ExitAnim.SetBool("IfExitTrigger", true);

        Title.SetBool("IfTitleTrigger", true);

        // Page Slide In Anim
        OptionsPageAnim.SetBool("IfClicked", true);
        OptionsPageAnim.SetBool("IfUnClicked", false);
    }

    public void ExitGameTrigger()
    {
        Application.Quit();
        Debug.Log("Get Out Now!!");
    }

    private void Update()
    {        
        if (Input.GetKey(KeyCode.Escape))
        {
            OptionsAnim.SetBool("IfOptionTrigger", false);
            NewGameAnim.SetBool("IfNewGameTrigger", false);
            LoadGameAnim.SetBool("IfLoadGameTrigger", false);
            ExitAnim.SetBool("IfExitTrigger", false);
            Title.SetBool("IfTitleTrigger", false);

            OptionsPageAnim.SetBool("IfUnClicked", true);
            LoadGamePageAnim.SetBool("IfLoadUnClicked", true);
        }
    }
}
