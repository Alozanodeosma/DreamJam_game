using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class SliderWalk : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private Camera camera;
    private Vector3 screenPosition;
    private float angleOffset;
    
    private Vector3 mousePositionInCameraCoords;
    
    [SerializeField] private GameObject slider;
    [SerializeField] private GameObject player;

    public AudioSource tik;
    public AudioSource ding;
    public AudioSource mmmmmh;
    public AudioSource steps;
   
    bool tikPlaying = false;
    void Start()
    {
        camera = Camera.main;
        mousePositionInCameraCoords = Vector3.zero;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        angleOffset = 0;
        screenPosition = camera.WorldToScreenPoint(transform.position); 
        mousePositionInCameraCoords  = Input.mousePosition - screenPosition;
    }
    
    bool canDrag = false;
    void IDragHandler.OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if(canDrag)
        {
        
        mousePositionInCameraCoords = Input.mousePosition - screenPosition;
        float angle = Mathf.Atan2(mousePositionInCameraCoords.y, mousePositionInCameraCoords.x) * Mathf.Rad2Deg-90;
        if (angle > 0)
        {
            angle -= 360;
        }
        if (angleOffset == 0)
        {
            angleOffset = angle;
        }
       
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle - angleOffset);
        }

    }
    private void Update()
    {
        if (transform.eulerAngles.z <= 0.05f && transform.eulerAngles.z >= -0.05f)
        {
            canDrag = true;
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        angleOffset = 0;
        if (canDrag)
        {
            if (this.transform.eulerAngles.z != 0)
            {
                if (!tikPlaying)
                {
                    tik.pitch = 1;
                    tik.Play();
                    mmmmmh.Play();
                    steps.Play();
                    tikPlaying = true;
                }
                //rotate slowly to 0 deegres
                StartCoroutine(RotateToZero());
            }
        }
        canDrag = false;
    }
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
        steps.Stop();
        tikPlaying = false;
        ding.Play();
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }

}
