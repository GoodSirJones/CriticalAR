using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using TMPro;

public class SwitchTextShown : MonoBehaviour
{
    public TextMeshPro titleText;

    public GameObject dataTable;

    public bool dataShown;

    public string nameUtility;

    private FillTable tableField;

    
    // Start is called before the first frame update
    void Start()
    {
        dataShown = false;
        dataTable.SetActive(false);

        nameUtility = titleText.GetComponent<TextMeshPro>().text;
        dataTable.GetComponent<FillTable>().GetName(nameUtility);

    }

    // Update is called once per frame
    void Update()
    {
       /* 
        #if UNITY_EDITOR
        
        if (Input.GetMouseButtonDown(0))
        {
            if (dataShown == false)
            {
                dataShown = true;
                dataTable.SetActive(true);
            }
            else
            {
                dataShown = false;
                dataTable.SetActive(false);
            }
        }
        #else
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (dataShown == false)
                {
                    dataShown = true;
                    dataTable.SetActive(true);
                }
                else
                {
                    dataShown = false;
                    dataTable.SetActive(false);
                }
            }
        }
        #end if
        */
    }

   

}
