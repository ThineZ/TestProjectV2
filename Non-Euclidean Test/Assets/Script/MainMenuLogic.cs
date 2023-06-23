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

    private AudioSource Souce;
    public AudioClip SouceClip;

    private void Start()
    {
        Souce = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Event e = Event.current;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Title.SetBool("IfSpaceHit", true);
            NewGame.SetBool("IfNewGame", true);
            LoadGame.SetBool("IfLoadGame", true);
            Option.SetBool("IfOption", true);
            Exit.SetBool("IfExit", true);
            Space.SetActive(false);
            Souce.PlayOneShot(Souce.clip = SouceClip);
        }
        else if (Space.activeInHierarchy == false)
        {
            SouceClip = null;
            Souce.clip = SouceClip;
        }

        if (e.isKey)
        {
            Debug.Log("Key Press");
        }
    }
}
