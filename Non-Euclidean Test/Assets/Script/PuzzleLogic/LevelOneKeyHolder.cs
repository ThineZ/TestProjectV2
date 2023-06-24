using UnityEngine;

public class LevelOneKeyHolder : MonoBehaviour
{
    [Header("Projection Plane")]
    public GameObject ProjectionPlane;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "pyramid key")
        {
            ProjectionPlane.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "pyramid key")
        {
            ProjectionPlane.SetActive(false);
        }
    }
}
