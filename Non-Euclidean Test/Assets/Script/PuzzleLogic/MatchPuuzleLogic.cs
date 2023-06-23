using UnityEngine;

public class MatchPuuzleLogic : MonoBehaviour
{
    [Header("Item Name")]
    public string PuzzleID;
    [Space]
    [Header("Original Material")]
    public Material Mat;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == PuzzleID)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = collision.gameObject.GetComponent<MeshRenderer>().material.color;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == PuzzleID)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Mat.color;
        }
    }
}
