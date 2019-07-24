using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using UnityEngine.XR.iOS;
using System.Runtime.InteropServices;
using UnityEngine.Rendering;

public class QRScanCode : MonoBehaviour
{

    private UnityARSessionNativeInterface arSession;
    
    public Text resultsText;

    private Rect screenRect;

    private float restartTime;

    //private IBarcodeReader codeReader;

   
    
    public Camera subCamera;

    public WebcamHandler webcamFetch;

    public string requestWord;


    // Start is called before the first frame update
    void Start()
    {
        webcamFetch = subCamera.GetComponent<WebcamHandler>();

       
    }



    // Update is called once per frame
    void Update()
    {
        
       
        OnQRDetect();
        


        
    }


    private string DecodeQR(Color32[] pixels, int width, int height)
    {
        try
        {
            ZXing.IBarcodeReader codeReader = new BarcodeReader();

            var result = codeReader.Decode(pixels, width, height);

            if (result != null)
            {
                return result.Text;
                
            }
        } catch (System.Exception ex) { Debug.LogError(ex.Message); }
        return null;
    }

    public void OnQRDetect()
    {
        var texture = new Texture2D(webcamFetch.RenderTexture.width, webcamFetch.RenderTexture.height);
        RenderTexture.active = webcamFetch.RenderTexture;
        texture.ReadPixels(new Rect(Vector2.zero, new Vector2(webcamFetch.RenderTexture.width, webcamFetch.RenderTexture.height)), 0, 0);

        var qrText = DecodeQR(texture.GetPixels32(), webcamFetch.RenderTexture.width, webcamFetch.RenderTexture.height);
        if (qrText != null)
        {
            Debug.Log("DECODED TEXT FROM QR: " + qrText);
            resultsText.text = qrText;
        }
    }
}
