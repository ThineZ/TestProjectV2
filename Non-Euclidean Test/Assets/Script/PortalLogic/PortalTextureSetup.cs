using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera cameraTwo;
    public Material cameraTwoMat;

    public Camera cameraOne;
    public Material cameraOneMat;

    void Start () { 

        if (cameraTwo.targetTexture != null)
        {
            cameraTwo.targetTexture.Release();
        }
        cameraTwo.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraTwoMat.mainTexture = cameraTwo.targetTexture;        
        
        if (cameraOne.targetTexture != null)
        {
            cameraOne.targetTexture.Release();
        }
        cameraOne.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraOneMat.mainTexture = cameraOne.targetTexture;
    }
}