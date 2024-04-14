using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderMovement : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private Camera camera;
    private Vector3 screenPosition;
    private float angleOffset;
    [SerializeField] private GameObject slider;
    [SerializeField] private GameObject sliderWalk;
    [SerializeField] private GameObject player;
    const int y_rotation = 0;
    void Start()
    {
        camera = Camera.main;
        
    }
    private Vector3 lastPos;
    private Vector3 currentPos;
    public float angularSpeed;
    public AudioSource tik;
    bool tikPlaying = false;
    private void FixedUpdate()
    {
        lastPos=currentPos;
        currentPos=player.transform.position;
        //calculate the angular speed of the object in z axis
    }
    private void Update()
    {
        angularSpeed= Vector3.Angle(currentPos - lastPos, player.transform.forward) / Time.fixedDeltaTime;

    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        //if slider rotation on z axis is not 0
        if (sliderWalk.transform.eulerAngles.z<=0.1f && sliderWalk.transform.eulerAngles.z >= -0.1f) {
            angleOffset = 0;
            screenPosition = camera.WorldToScreenPoint(transform.position); //transforma la posición del objeto de la posición en el mundo virtual a una posición en la pantalla
            Vector3 vec3 = Input.mousePosition - screenPosition;
            angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;//calcula el ángulo entre el objeto y el ratón
        }
    }
    void IDragHandler.OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (sliderWalk.transform.eulerAngles.z <= 0.05f && sliderWalk.transform.eulerAngles.z >= -0.05f)
        {
            if (!tikPlaying)
            {
                tik.Play();
                tikPlaying = true;
            }
            //tik pitch is set to the angular speed of the object

            Vector3 vec3 = Input.mousePosition - screenPosition;
            float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, (angle + angleOffset));
        }
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    { 
        tikPlaying=false;
        tik.Stop();
    }
    }