using UnityEngine;

public class LevelOneKeyHolder : MonoBehaviour
{
    [Header("Projection Plane")]
    public GameObject ProjectionPlane;

    [Header("Lvl")]
    [Space]
    public GameObject Lvl2;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "pyramid key")
        {
            ProjectionPlane.SetActive(true);
            Lvl2.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "pyramid key")
        {
            ProjectionPlane.SetActive(false);
            Lvl2.SetActive(false);
        }
    }
}
