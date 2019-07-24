using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtilityDataScript : MonoBehaviour
{
    public GameObject heightText;
    public GameObject widthText;

    public GameObject descriptionText;

    public GameObject manufacturerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(string width, string height, string manufacturer, string description)
    {
        this.widthText.GetComponent<Text>().text = width;
        this.heightText.GetComponent<Text>().text = height;
        this.manufacturerText.GetComponent<Text>().text = manufacturer;
        this.descriptionText.GetComponent<Text>().text = description;
        
    }
}
