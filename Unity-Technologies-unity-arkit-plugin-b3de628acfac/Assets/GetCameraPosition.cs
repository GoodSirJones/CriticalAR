using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCameraPosition : MonoBehaviour
{
    public Camera ARCamera;

    public Text posTextX;

    public Text posTextY;

    public Text posTextZ;


    // Start is called before the first frame update
    void Start()
    {
        ARCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        
        posTextX.GetComponent<Text>().text = "Rotation X: " + ARCamera.transform.rotation.x.ToString();

        posTextY.GetComponent<Text>().text = "Rotation Y: " + ARCamera.transform.rotation.y.ToString();

        posTextZ.GetComponent<Text>().text = "Rotation Z: " + ARCamera.transform.rotation.z.ToString();


    }
}
