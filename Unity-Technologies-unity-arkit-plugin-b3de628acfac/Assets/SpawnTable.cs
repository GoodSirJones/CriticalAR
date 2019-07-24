using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.UI;

public class SpawnTable : MonoBehaviour
{
    public GameObject tablePrefab;

    public Transform tableParent;

    private GameObject tableClone;

    public bool tableShow;

    // Start is called before the first frame update
    void Start()
    {
        tableShow = false;
        tableClone = null;
    }

  

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            if (tableShow == false)
                {
                    tableShow = true;
                    tableClone = Instantiate(tablePrefab);
                    tableClone.transform.SetParent(tableParent);
                    
                    //tableClone.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                }
                else if (tableShow == true)
                {
                    tableShow = false;
                    Destroy(tableClone);
                    tableClone = null;
                }
        }
        #else
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {

                if (tableShow == false)
                {
                    tableShow = true;
                    tableClone = Instantiate(tablePrefab);
                    tableClone.transform.SetParent(tableParent);
                    //tableClone.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                }
                else if (tableShow == true)
                {
                    tableShow = false;
                    Destroy(tableClone);
                    tableClone = null;
                }
            }
        }
        #endif
    }
}


