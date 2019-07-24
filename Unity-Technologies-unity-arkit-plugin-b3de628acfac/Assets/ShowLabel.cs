using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class ShowLabel : MonoBehaviour
{
    public GameObject boardComponent;

    public GameObject componentLabel;

    public float maxRayDistance = 30.0f;

   

    public bool labelShown;


    // Start is called before the first frame update
    void Start()
    {
        componentLabel.SetActive(false);

        labelShown = false;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast (ray, out hit, 200))
            {
                if (hit.transform.position == boardComponent.transform.position)
                {
                    Debug.Log("Component clicked: ");

                    if (labelShown == false)
                    {
                        labelShown = true;
                        componentLabel.SetActive(true);
                    }
                    else
                    {
                        labelShown = false;
                        componentLabel.SetActive(false);
                    }
                }
            }
        }
#else
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit2;

                Ray ray1 = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast (ray1, out hit2, 200))
                {
                    if (hit2.transform.position == boardComponent.transform.position)
                    {
                        Debug.Log("Component clicked");

                        if (labelShown == false)
                        {
                            labelShown = true;
                            componentLabel.SetActive(true);
                        }
                        else
                        {
                            labelShown = false;
                            componentLabel.SetActive(false);
                        }
                    }
                }
            }
        }
#endif
    }
}
