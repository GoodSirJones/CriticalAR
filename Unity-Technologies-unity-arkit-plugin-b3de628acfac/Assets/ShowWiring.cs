using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class ShowWiring : MonoBehaviour
{
    public GameObject holdText;

    public GameObject holdWires;

    public bool wiresSeen;

    // Start is called before the first frame update
    void Start()
    {
        holdWires.SetActive(false);
        wiresSeen = false;
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            if (wiresSeen == false)
            {
                wiresSeen = true;
                holdText.SetActive(false);
                holdWires.SetActive(true);
            }
            else
            {
                wiresSeen = false;
                holdText.SetActive(true);
                holdWires.SetActive(false);
            }
        }
#else
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (wiresSeen == false)
                {
                    wiresSeen = true;
                    holdText.SetActive(false);
                    holdWires.SetActive(true);
                }
                else
                {
                    wiresSeen = false;
                    holdText.SetActive(true);
                    holdWires.SetActive(false);
                }

            }
        }
#endif
    }

    public void ShowWires()
    {
        //holdWires.SetActive(true);
    }

    public void HideWires()
    {
        
        //holdWires.SetActive(false);
    }
}
