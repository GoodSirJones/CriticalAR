using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugBoxScript : MonoBehaviour
{

    public Text textDebug;

    public string newMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void LogTest(string message)
    {
        textDebug.text = message;
    }

}
