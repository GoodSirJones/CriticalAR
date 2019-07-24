using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class WebcamHandler : MonoBehaviour
{
    private RenderTexture _vertical;
    private RenderTexture _horizontal;
    private Camera _camera;

    public RenderTexture RenderTexture
    {
        get
        {
            var orientation = Screen.orientation;
            if (orientation == ScreenOrientation.Landscape || orientation == ScreenOrientation.LandscapeLeft || orientation == ScreenOrientation.LandscapeRight)
            {
                return _horizontal;
            }
            else
            {
                return _vertical;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        _horizontal = new RenderTexture(Screen.width, Screen.height, 24);
        _vertical = new RenderTexture(Screen.height, Screen.width, 24);
    }

    // Update is called once per frame
    void Update()
    {
        var orientation = Screen.orientation;
        if (orientation == ScreenOrientation.Landscape || orientation == ScreenOrientation.LandscapeLeft || orientation == ScreenOrientation.LandscapeRight)
        {
            _camera.targetTexture = _horizontal;
        }
        else
        {
            _camera.targetTexture = _vertical;
        }
    }


}
