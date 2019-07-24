using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceScreen : MonoBehaviour
{
    public Camera cameraToLookAt;

    public GameObject objectRotate;

    public float previousRotationY;

    // Start is called before the first frame update
    void Start()
    {
        cameraToLookAt = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        previousRotationY = objectRotate.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {

        
        objectRotate.transform.LookAt(cameraToLookAt.transform.position);

        

        //transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.position);

        /*
        if ((cameraToLookAt.transform.rotation.y < 0.65) && (cameraToLookAt.transform.rotation.y > 0))
        {
            if (previousRotationY == 0)
            {
                objectRotate.transform.Rotate(0,90,0);
               
            }
            else
            {
                if (previousRotationY == 180)
                {
                    objectRotate.transform.Rotate(0, -90, 0);

                }
                else
                {
                    if (previousRotationY == -90)
                    {
                        objectRotate.transform.Rotate(0, 180, 0);

                    }
                }
            }

            RotateObject();
        }
        else
        {
            if ((cameraToLookAt.transform.rotation.y < -0.5) && (cameraToLookAt.transform.rotation.y > -1))
            {
                if (previousRotationY == 0)
                {
                    objectRotate.transform.Rotate(0, -90, 0);
                    
                }
                else
                {
                    if (previousRotationY == 180)
                    {
                        objectRotate.transform.Rotate(0, 90, 0);

                    }
                    else
                    {
                        if (previousRotationY == 90)
                        {
                            objectRotate.transform.Rotate(0, 180, 0);

                        }
                    }
                }

                RotateObject();

            }
            else
            {
                if ((cameraToLookAt.transform.rotation.y > -0.5) && (cameraToLookAt.transform.rotation.y < 0))
                {
                    
                    if(previousRotationY == 0)
                    {
                        objectRotate.transform.Rotate(0, 180, 0);
                       
                    }
                    else
                    {
                        if (previousRotationY == 90)
                        {
                            objectRotate.transform.Rotate(0, 90, 0);

                        }
                        else
                        {
                            if (previousRotationY == -90)
                            {
                                objectRotate.transform.Rotate(0, -90, 0);

                            }
                        }
                    }

                     RotateObject();
                }
                else
                {
                    if ((cameraToLookAt.transform.rotation.y > 0.65) && (cameraToLookAt.transform.rotation.y < 1))
                    {

                        if (previousRotationY == 180)
                        {
                            objectRotate.transform.Rotate(0, -180, 0);
                           
                        }
                        else
                        {
                            if (previousRotationY == 90)
                            {
                                objectRotate.transform.Rotate(0, -90, 0);

                            }
                            else
                            {
                                if (previousRotationY == -90)
                                {
                                    objectRotate.transform.Rotate(0, 90, 0);

                                }
                            }
                        }

                        RotateObject();
                    }
                }
            }
        }*/

       

    }

    public void RotateObject()
    {
        previousRotationY = objectRotate.transform.rotation.y;
    }
}
