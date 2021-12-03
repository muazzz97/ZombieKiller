using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CameraRotation : MonoBehaviour
{

    private Vector3 firstpoint;
    private Vector3 secondpoint;
    float xAngle ;
    float yAngle;
    float xAngTemp;
    float yAngTemp;

  void Start()
    {
        xAngle = 0;
        yAngle = 0;
        //Initialization our angles of camera

      //  this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
    }
    void Update()
    {
        //Check count touches
        if (Input.touchCount > 0)
        {
            //Touch began, save position
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstpoint = Input.GetTouch(0).position;
                xAngTemp = xAngle;
                yAngTemp = yAngle;
            }
            //Move finger by screen
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                secondpoint = Input.GetTouch(0).position;
                //Mainly, about rotate camera. For example, for Screen.width rotate on 180 degree
                xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 180/ Screen.width;
                yAngle = yAngTemp - (secondpoint.y - firstpoint.y) * 90 / Screen.height;
                //Rotate camera
                this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
            }
        }
    }

}












