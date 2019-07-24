using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarcodeBackup : MonoBehaviour
{

    public Text resultWord;

    private WebCamTexture webcamTex;
    private QRCodeManager qrManager2;

    public int fPS = 30;

    public int height1 = 540;

    public int width1 = 900;



    // Start is called before the first frame update
    void Start()
    {
        
        WebCamDevice[] devices = WebCamTexture.devices;

        webcamTex = new WebCamTexture(devices[0].name, width1, height1, fPS);
        
        webcamTex.Play();

        this.qrManager2 = new QRCodeManager();
    }

    // Update is called once per frame
    void Update()
    {
        //resultWord.text = this.qrManager2.Read(webcamTex);
    }
}
