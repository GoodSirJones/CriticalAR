using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using UnityEngine.XR.iOS;

public class BarcodeScannerScript : MonoBehaviour
{
    public Camera cam;
    private BarcodeReader barCodeReader;

    public FrameCapturer pixelCapture;

    public Text qrText;
    
    // Start is called before the first frame update
    void Start()
    {
        barCodeReader = new BarcodeReader();

        Resolution currentResolution = Screen.currentResolution;
        pixelCapture = cam.GetComponent<FrameCapturer>();
    }

    // Update is called once per frame
    void Update()
    {
        Resolution currentResolution = Screen.currentResolution;

        try
        {
            Color32[] framebuffer = pixelCapture.lastCapturedColors;
            if (framebuffer.Length == 0)
            {
                return;
            }

            var data = barCodeReader.Decode(framebuffer, currentResolution.width, currentResolution.height);

            if (data != null)
            {
                qrText.text = data.Text;
            }
        }
        catch (System.Exception e) { Debug.LogError("Error reading QR"); Debug.LogError(e.Message); }

        pixelCapture.nextFrameCapture = true;
    }
}
