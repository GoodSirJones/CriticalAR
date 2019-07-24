using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCapturer : MonoBehaviour
{
    public bool nextFrameCapture = false;
    public Color32[] lastCapturedColors;

    private Texture2D centerPixTex;

    // Start is called before the first frame update
    void Start()
    {
        centerPixTex = new Texture2D(1, 1, TextureFormat.RGBA32, false);
    }

    private void OnPostRender()
    {
        if (nextFrameCapture)
        {
            Resolution res = Screen.currentResolution;

        }
    }

    Color32[] GetRenderedColors()
    {
        Resolution currentResolution = Screen.currentResolution;
        centerPixTex.ReadPixels(new Rect(0, 0, currentResolution.width, currentResolution.height), 0, 0);
        centerPixTex.Apply();

        return centerPixTex.GetPixels32();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
