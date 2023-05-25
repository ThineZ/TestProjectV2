using UnityEngine;
using System.Collections;

public class PlaceObject : MonoBehaviour
{
    [Header("Object To Place")]
    public GameObject ObjectToPlace;

    [SerializeField] private PickObject PickObject;

    private bool b1 = false;
    private bool b2 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            if (PickObject.CurrentObject == null 
                || b1)
                return;
            ObjectToPlace.transform.position = transform.position;
            ObjectToPlace.transform.rotation = transform.rotation;

            PickObject.CurrentObject.isKinematic = true;
            ////PickObject.CurrentObject = null;
            PickObject.DetectPlaced();

            b1 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            if (PickObject.CurrentObject == null || b2)
                return;
            Debug.Log("exit");
            b2 = true;
            StartCoroutine(Exit());
        }
    }


    private IEnumerator Exit()
    {
        yield return new WaitForSeconds(0.03f);
        b1 = false;
        b2 = false;
    }

    private void OnEnable()
    {
        SnapKey();
    }

    private void OnDisable()
    {
        SnapKey();
    }

    public void SnapKey()
    {
        if (PickObject.CurrentObject == null)
        {
            return;
        }

        ObjectToPlace.transform.position = transform.position;
        ObjectToPlace.transform.rotation = transform.rotation;

        PickObject.CurrentObject.isKinematic = true;
        PickObject.DetectPlaced();
    }
}
