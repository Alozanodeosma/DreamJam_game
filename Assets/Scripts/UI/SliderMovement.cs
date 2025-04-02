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
    public static bool paused = false;
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
    private bool getFirstAngleForTurnAchievement = true;

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
            getFirstAngleForTurnAchievement = true;
        }
        else
        {
            eventData.pointerDrag = null;
        }
    }
    public float angle=0;
    private int previousAngle = 0;
    private int currentAngleAudio = 0;
    private float currentAngle = 0;
    private int currentAngleInt = 0;
    private int startingAngle;
    private int turnsCounter = 0;
    private int previousAngleInt = 0;
    
    void IDragHandler.OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (SliderWalk.canDrag)
        {
            Vector3 mousePositionInDial = Input.mousePosition - screenPosition;
            angle = Mathf.Atan2(mousePositionInDial.y, mousePositionInDial.x) * Mathf.Rad2Deg - 90;
            if (angle > 0)
            {
                angle = angle - 360;
            }
            currentAngle = angle-angleOffset;
            currentAngleInt = (int)currentAngle;
            
            if(!achievementTurnCompleted){
            SteamTurnAchievement();
            }
            
            
            //make the tik sound
            currentAngleAudio = (int)(angle/15);
            if (currentAngleAudio != previousAngle && !tik.isPlaying)
            {
               previousAngle = currentAngleAudio;
               tik.Play();
            }
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, (currentAngle));
            if(paused){eventData.pointerDrag = null;}
        }
        else
        {
                eventData.pointerDrag = null;
        }
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    { 
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
    }

    private int firstAngle = 0;
    private bool achievementTurnCompleted = false;
    public void SteamTurnAchievement()
    {
        if (getFirstAngleForTurnAchievement)
        {
            firstAngle = currentAngleInt/10;
            turnsCounter=0;
            getFirstAngleForTurnAchievement = false;
        }
            //steam achievement
            if (currentAngleInt/10 == firstAngle && currentAngleInt/10 != previousAngleInt/10)
            {
                if (previousAngleInt < currentAngleInt) turnsCounter++;
                else turnsCounter--;
                Debug.Log(turnsCounter);
            }
            previousAngleInt = currentAngleInt;
            if (turnsCounter == 3 || turnsCounter == -3)
            {
                SteamAchievementsManager.UnlockAchievement(SteamAchievementsManager.archRotate);
                achievementTurnCompleted = true;
                
            }
    }
  
    
    }