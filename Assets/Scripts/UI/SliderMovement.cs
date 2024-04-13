using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderMovement : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private Camera camera;
    private Vector3 screenPosition;
    private float angleOffset;
    [SerializeField] private GameObject slider;
    [SerializeField] private GameObject player;
    const int y_rotation = 0;
    void Start()
    {
        camera = Camera.main;
        
    }
    private Vector3 lastPos;
    private Vector3 currentPos;
    private void FixedUpdate()
    {
        lastPos=currentPos;
        currentPos=player.transform.position;
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (lastPos==currentPos) { 
            screenPosition = camera.WorldToScreenPoint(transform.position); //transforma la posición del objeto de la posición en el mundo virtual a una posición en la pantalla
            Vector3 vec3 = Input.mousePosition - screenPosition;
            angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;//calcula el ángulo entre el objeto y el ratón
        }
    }
    void IDragHandler.OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (lastPos == currentPos)
        {
            Vector3 vec3 = Input.mousePosition - screenPosition;
            float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle + angleOffset);
        }
    }
}