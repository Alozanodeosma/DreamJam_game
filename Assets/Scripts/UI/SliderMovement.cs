using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderMovement : MonoBehaviour//, IPointerDownHandler, IDragHandler
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
    private float lastPosSlider=0;
    private float currentPosSlider=0;
    public bool left=false;


    
    
    public bool right=false;
    private void Update()
    {
        lastPosSlider = currentPosSlider;
        currentPosSlider = this.transform.rotation.z;

    }
    private void FixedUpdate()
    {

    }
    //void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    //{
    //    angleOffset = 0;
    //    screenPosition = camera.WorldToScreenPoint(transform.position); //transforma la posición del objeto de la posición en el mundo virtual a una posición en la pantalla
    //    Vector3 vec3 = Input.mousePosition - screenPosition;
    //    angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;//calcula el ángulo entre el objeto y el ratón

    //}
    //void IDragHandler.OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    //{

    //    Vector3 vec3 = Input.mousePosition - screenPosition;
    //    float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
    //    //rotate the slider
    //    //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle + angleOffset);
    //    Quaternion targetRotation = Quaternion.LookRotation(transform.forward, Vector3.up) * Quaternion.Euler(0, 0, angle + angleOffset);
    //    transform.rotation = targetRotation;
    //}
}