using UnityEngine;

public class MatchKeys : MonoBehaviour
{
    [Header("Keys Items")]
    public GameObject[] KeysItems;

    [Space]
    [Header("List Index")]
    public int Index;

    [Space]
    [Header("Bool Check")]
    public bool Correct = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == KeysItems[Index])
        {
            Correct = true;
            Debug.Log("KEY YEAH");
        }
        else
        {
            Debug.Log("WRONG!");
            Correct = false;
        }
    }
}
