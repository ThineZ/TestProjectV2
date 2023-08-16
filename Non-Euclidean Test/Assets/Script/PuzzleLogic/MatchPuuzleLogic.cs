using UnityEngine;

public class MatchPuuzleLogic : MonoBehaviour
{
    [Header("Item Name")]
    [Space]
    public string PuzzleID;
    [Header("Original Material")]
    [Space]
    public Material Mat;
    [Header("Bool")]
    [Space]
    public bool ifColl = false;

    private void Update()
    {
        DetectKey();
    }

    public void DetectKey()
    {
        if (ifColl)
        {
            gameObject.name = PuzzleID;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == PuzzleID)
        {
            ifColl = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == PuzzleID)
        {
            ifColl = false;
        }
    }
}
