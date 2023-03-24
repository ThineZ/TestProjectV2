using UnityEngine;

public class MainMenuLogic : MonoBehaviour
{
    [Header("Animitor")]
    public Animator Title;
    public Animator NewGame;
    public Animator LoadGame;
    public Animator Option;
    public Animator Exit;

    [Header("Objects")]
    public GameObject Space;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Title.SetBool("IfSpaceHit", true);
            NewGame.SetBool("IfNewGame", true);
            LoadGame.SetBool("IfLoadGame", true);
            Option.SetBool("IfOption", true);
            Exit.SetBool("IfExit", true);
            Space.SetActive(false);
        }
    }
}
