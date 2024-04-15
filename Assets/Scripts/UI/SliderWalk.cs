using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SliderWalk : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private Camera camera;
    private Vector3 screenPosition;
    private float angleOffset;
    [SerializeField] private GameObject slider;
    [SerializeField] private GameObject player;
    const int y_rotation = 0;
    public AudioSource tik;
    public AudioSource ding;
    public AudioSource mmmmmh;
    public AudioSource pasos;
    bool tikPlaying = false;
    void Start()
    {
        camera = Camera.main;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {

        angleOffset = 0;
        screenPosition = camera.WorldToScreenPoint(transform.position); //transforma la posición del objeto de la posición en el mundo virtual a una posición en la pantalla
        Vector3 vec3 = Input.mousePosition - screenPosition;
        //angleOffset = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;//calcula el ángulo entre el objeto y el ratón
        //angleOffset = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg - 90;
        //if (angleOffset > 0)
        //{
        //    angleOffset = angleOffset - 360;
        //}
        //float angleOffset = 0

    }
    void IDragHandler.OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {

        Vector3 vec3 = Input.mousePosition - screenPosition;
        float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg-90;
        if (angle > 0)
        {
            angle = angle - 360;
        }
        if (angleOffset == 0)
        {
            angleOffset = angle;
        }
       
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle - angleOffset);


    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        angleOffset = 0;
        if (this.transform.eulerAngles.z != 0)
        {
            if (!tikPlaying)
            {
                tik.pitch = 1;
                tik.Play();
                mmmmmh.Play();
                //make mmmmmh sound start gradually


                pasos.Play();
                tikPlaying = true;
            }
            //rotate slowly to 0 deegres
            StartCoroutine(RotateToZero());
        }

    }
    public float AlwaysNeg(float number)
    {
        return Mathf.Abs(number) * -1f;
    }
    //void IEndDragHandler.OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData)
    //{
    //    if (this.transform.eulerAngles.z!=0)
    //    {
    //        //rotate slowly to 0 deegres
    //        StartCoroutine(RotateToZero());
    //    }
    //}

    private IEnumerator RotateToZero()
    {
        while (this.transform.eulerAngles.z <= -5 || this.transform.eulerAngles.z >= 5)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 4);
            player.GetComponent<PlayerMovement>().moveDirection = player.transform.forward;
            yield return new WaitForSeconds(0.1f);

        }
        player.GetComponent<PlayerMovement>().moveDirection = Vector3.zero;
        tik.Stop();
        mmmmmh.Stop();
        pasos.Stop();
        tikPlaying = false;
        ding.Play();
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }

}
