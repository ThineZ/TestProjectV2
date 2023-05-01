using UnityEngine;

public class PickObject : MonoBehaviour
{
    [SerializeField] private LayerMask PickUpMask;
    [SerializeField] private Camera MainCam;
    [SerializeField] private Transform PickObjTransform;
    [Space]
    [SerializeField] private float PickUpRange;
    public Rigidbody CurrentObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject.freezeRotation = false;
                CurrentObject = null;
                return;
            }

            Ray CameraRay = MainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickUpRange, PickUpMask))
            {
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
}