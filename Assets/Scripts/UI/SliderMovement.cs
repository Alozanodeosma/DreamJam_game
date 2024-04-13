using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SliderMovement : MonoBehaviour
{
    private Camera camera;
    private Vector3 screenPosition;
    private float angleOffset;
    private Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        camera= Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);//transforma la posición del raton de la posicion de pantalla a una posición en el mundo virtual
        //show on console the mouse position


        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is over the GameObject.");

            if (collider == Physics2D.OverlapPoint(mousePosition)) //check if a collider overlaps a point in space
            {
                Debug.Log("Mouse is over the GameObject.");
                screenPosition = camera.WorldToScreenPoint(transform.position); //transforma la posición del objeto de la posición en el mundo virtual a una posición en la pantalla
                angleOffset = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg - transform.eulerAngles.z; //calcula el ángulo entre el objeto y el ratón
                Debug.Log("Angle Offset: " + angleOffset);
            }
        }

            if(Input.GetMouseButton(0))
            {
                if (collider == Physics2D.OverlapPoint(mousePosition))
                {

                    Vector3 vec3 = Input.mousePosition - screenPosition;
                    float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                    transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
                }

            }


    }
}
