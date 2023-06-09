using UnityEngine.EventSystems;
using UnityEngine;

public class MenuSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Menu Items")]
    public GameObject Blue;
    public GameObject Red;

    [Header("Animator")]
    public Animator BlueAnim;
    public Animator RedAnim;

    [Header("Set Bool Name")]
    public string BlueSetBoolName;
    public string RedSetBoolName;

    [Header("Audio")]
    public AudioSource AudioSource;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Blue.SetActive(true);
        Red.SetActive(true);

        BlueAnim.SetBool(BlueSetBoolName, true);
        RedAnim.SetBool(RedSetBoolName, true);

        AudioSource.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Blue.SetActive(false);
        Red.SetActive(false);

        BlueAnim.SetBool(BlueSetBoolName, false);
        RedAnim.SetBool(RedSetBoolName, false);
    }
}
