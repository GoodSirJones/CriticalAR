using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarcodeRead : MonoBehaviour
{
    public Text resultText;

    public Texture2D cameraTexture;

    public Camera appCam;

    private QRCodeManager qrManager;

    // Start is called before the first frame update
    void Start()
    {
        cameraTexture = new Texture2D(appCam.pixelWidth, appCam.pixelHeight);

        

        this.qrManager = new QRCodeManager();


    }

    // Update is called once per frame
    void Update()
    {
        resultText.text = this.qrManager.Read(cameraTexture);
    }
}
