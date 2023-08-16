using UnityEngine;

public class ProjectionTexture : MonoBehaviour
{
    public Camera ProjectionCamera;
    public Material ProjectionCameraMat;

    void Start()
    {
        if (ProjectionCamera.targetTexture != null)
        {
            ProjectionCamera.targetTexture.Release();
        }
        ProjectionCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        ProjectionCameraMat.mainTexture = ProjectionCamera.targetTexture;
    }
}
