using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderMovement : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler, IPointerExitHandler
{
    private Camera camera;
    private Vector3 screenPosition;
    private float angleOffset;
    [SerializeField] private GameObject slider;
    [SerializeField] private GameObject sliderWalk;
    [SerializeField] private GameObject player;
    [SerializeField] private Texture2D cursorClosedTexture;
    [SerializeField] private Texture2D cursorOpenedTexture;
    void Start()
    {
        camera = Camera.main;
    }
    private Vector3 currentPos;
    public AudioSource tik;
    bool tikPlaying = false;
    private void FixedUpdate()
    {
        currentPos=player.transform.position;
        //calculate the angular speed of the object in z axis
    }

    public float angleMouseDown = 0;
    public float angleMouseUp = 0;
    float posIni = 0;
    
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        //if slider rotation on z axis is not 0
        if (SliderWalk.canDrag) {
            screenPosition = camera.WorldToScreenPoint(transform.position); 
            Vector3 vec3 = Input.mousePosition - screenPosition;
            angleMouseDown = (Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg - 90;
            if (angleMouseDown > 0)
            {
                angleMouseDown =  angleMouseDown-360;
            }
            angleOffset = angleMouseDown - posIni;
        }
        else
        {
            eventData.pointerDrag = null;
        }
    }
    public float angle=0;
    private bool cursorChanged = false;
    private int previousAngle = 0;
    private int currentAngle = 0;
    void IDragHandler.OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (SliderWalk.canDrag)
        {
            if (PlayerManager.activateCursorChange && !cursorChanged)
            {
                Cursor.SetCursor(cursorClosedTexture, Vector2.zero, CursorMode.Auto);
                cursorChanged = true;
            } 
            
            // if (!tikPlaying)
            // {
            //     tik.Play();
            //     tikPlaying = true;
            // }
            Vector3 vec3 = Input.mousePosition - screenPosition;
            angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg - 90;
            if (angle > 0)
            {
                angle = angle - 360;
            }
            
            currentAngle = (int)(angle/15);
            if (currentAngle != previousAngle && !tik.isPlaying)
            {
               previousAngle = currentAngle;
               tik.Play();
            }
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, (angle -angleOffset  ));
        }
        else
        {
                eventData.pointerDrag = null;
        }
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    { 
        if(PlayerManager.activateCursorChange){
            Cursor.SetCursor(cursorOpenedTexture, Vector2.zero, CursorMode.Auto);
            cursorChanged = false;
        }
        angleMouseUp = angle;
        posIni = posIni+ (Mathf.Abs(angleMouseDown) - Mathf.Abs(angleMouseUp));
    }
    
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (PlayerManager.cancelDragWhenOutOfTheDial)
        {
            eventData.pointerDrag = null;

            angleMouseUp = angle;
            posIni = posIni+ (Mathf.Abs(angleMouseDown) - Mathf.Abs(angleMouseUp));
        }
        
        if(PlayerManager.activateCursorChange){
            Cursor.SetCursor(cursorOpenedTexture, Vector2.zero, CursorMode.Auto);
            cursorChanged = false;
        }
    }
    }