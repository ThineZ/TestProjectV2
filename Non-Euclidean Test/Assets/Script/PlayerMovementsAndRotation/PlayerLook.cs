using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Camera Object")]
    public Camera PlayerCam;

    private float xRotation;

    // Sensitivity of Player Rotation
    [Header("X and Y Sensitivity")]
    public float ySensitivity;
    public float xSensitivity;

    private void Awake()
    {
        // To make the cursor unvisable
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // Calculate the camera rotation for rotating UP and DOWN direction
        xRotation -= mouseY * Time.deltaTime * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // Apply this to the main camera/player camera transform
        PlayerCam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // Rotate player to look LEFT and RIGHT
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
