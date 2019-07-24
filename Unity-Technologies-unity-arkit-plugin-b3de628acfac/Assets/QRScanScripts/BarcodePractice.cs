using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

using UnityEngine;
using UnityEngine.UI;


using ZXing;
using ZXing.QrCode;
using ZXing.Common;

public class BarcodePractice : MonoBehaviour
{
    public Text OutputText;

    private BarcodeReader codeReader;


    private WebCamTexture handle;

    // Start is called before the first frame update
    void Start()
    {
        codeReader = new BarcodeReader();
    }



    // Update is called once per frame
    void Update()
    {
        
       
    }
}
