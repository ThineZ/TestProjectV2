
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine;


public class PickObject : MonoBehaviour
{
    [SerializeField] private LayerMask PickUpMask;
    [SerializeField] private Camera MainCam;
    [SerializeField] private Transform PickObjTransform;
    [Space]
    [SerializeField] private float PickUpRange;
    public Rigidbody CurrentObject;

    [Space]
    [Header("Dot")]
    public Image Dot;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject.freezeRotation = false;

                CurrentObject.isKinematic = false;
                CurrentObject = null;

                Dot.color = Color.red;

                CurrentObject = null;

                return;
            }

            Ray CameraRay = MainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickUpRange, PickUpMask))
            {

                Debug.Log(HitInfo.collider.gameObject.name);
                Debug.Log(HitInfo.rigidbody.gameObject.name);
                Debug.Log(HitInfo.rigidbody);
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
                CurrentObject.freezeRotation = true;
                CurrentObject.isKinematic = false;
                Dot.color = Color.yellow;

                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
                CurrentObject.freezeRotation = true;
            }

            if (CurrentObject.isKinematic == true)
            {
                CurrentObject = null;

            }
        }
    }

    private void FixedUpdate()
    {
        if (CurrentObject)
        {
            Vector3 DirectionToPoint = PickObjTransform.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
         }
    }


    public void DetectPlaced()
    {
        Debug.Log("detect placed");
        StartCoroutine(Placed());
    }

    private IEnumerator Placed()
    {

        Debug.Log("detect placed1");
        yield return null;

        Debug.Log(CurrentObject);
        if (CurrentObject != null)
        {

            Debug.Log("detect place2");
            CurrentObject = null;
            Dot.color = Color.red;
        }
    }


}