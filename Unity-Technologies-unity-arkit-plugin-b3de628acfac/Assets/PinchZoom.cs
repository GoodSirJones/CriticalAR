using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class PinchZoom : MonoBehaviour
{
    public float perspectiveZoomSpeed = 0.5f;

    public float orthoZoomSpeed = 0.5f;

    public Camera mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            if (mainCamera.orthographic)
            {
                mainCamera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                mainCamera.orthographicSize = Mathf.Max(mainCamera.orthographicSize, 0.1f);
            }
            else
            {
                mainCamera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, 0.1f, 179.9f);
            }
           
        }
    }
}
