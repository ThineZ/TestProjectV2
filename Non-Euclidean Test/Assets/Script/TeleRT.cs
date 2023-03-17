using UnityEngine;

public class TeleRT : MonoBehaviour
{
    public Camera CamToOne;
    public Material matOne;

    private void Start()
    {
        if (CamToOne.targetTexture != null)
        {
            CamToOne.targetTexture.Release();
        }
        CamToOne.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        matOne.mainTexture = CamToOne.targetTexture;
    }
}