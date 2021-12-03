using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour
    {

        public Transform Player;
        public float speed = 5.0f;
        private bool TouchStart = false;
        private Vector3 pointA;
        private Vector3 pointB;

        public Transform circle;
        public Transform outercircle;



           void Update()
        {
  
            if(Input.GetMouseButtonDown(0))
                {
            
                    pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            
                }
            if (Input.GetMouseButton(0))
                {
                    TouchStart = true;
                    pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
                }
                else
                {
                    TouchStart = false;
                }
        }

       private  void FixedUpdate()
        {
            if (TouchStart)
                {
                    Vector3 offset = pointB - pointA;
                    Vector3 direction = Vector3.ClampMagnitude(offset, 1.0f);
                    moveCharacter(offset * -1);

                }         
            

        }

    void moveCharacter(Vector3 direction)
        {
            Player.Translate(direction.x * -speed * Time.deltaTime, 0f, direction.y * speed * Time.deltaTime) ;
       
        }

}
