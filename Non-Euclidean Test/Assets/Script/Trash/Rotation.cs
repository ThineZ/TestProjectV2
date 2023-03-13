using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class Rotation : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 };
    public RotationAxes axes = RotationAxes.MouseXAndY;

    [Header("Player Camera Controls")]
    public float senX = 15f;
    public float senY = 15f;

    public float minX = -360f;
    public float maxX = 360f;

    public float minY = -60f;
    public float maxY = 60f;

    float rotationY = 0f;

    private void Rotations()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * senX;

            rotationY += Input.GetAxis("Mouse Y") * senY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * senX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") + senY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }

    private void Update()
    {
        Rotations();
    }
}
