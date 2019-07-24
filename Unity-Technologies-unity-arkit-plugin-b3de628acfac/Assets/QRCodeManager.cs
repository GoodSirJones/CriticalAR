using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;

public class QRCodeManager : MonoBehaviour
{
    
    public string Read(Texture2D camText)
    {
        BarcodeReader reader = new BarcodeReader();
        Color32[] color = camText.GetPixels32();
        int width = camText.width;
        int height = camText.height;
        var result = reader.Decode(color, width, height);
        if (result != null)
        {
            return result.Text;
        }
        return "-1";
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
