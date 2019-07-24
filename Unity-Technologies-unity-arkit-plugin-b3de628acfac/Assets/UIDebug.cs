using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
public class UIDebug : MonoBehaviour
{
    public string debugName;

    public Text debugText;

    private GameObject imageAnchor;

    private GenerateImageAnchor anchorScript;

    private UpdateNotes dataScript;

    // Start is called before the first frame update
    void Start()
    {
        imageAnchor = GameObject.FindWithTag("ImageGenerator");

        anchorScript = imageAnchor.GetComponent<GenerateImageAnchor>();

        //dataScript = imageAnchor.GetComponent<UpdateNotes>();

       debugName = anchorScript.applianceName;

        
    }

    void OnEnable()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (debugText.text == string.Empty)
        {
            debugText.text = debugName;
        }
        
        //debugText.text = "Is this working?";

        Debug.Log(debugName);

    }
}
