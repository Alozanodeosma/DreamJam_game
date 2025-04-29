using System;
using System.Drawing;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class SliderSoundController : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] Transform handle;
    [SerializeField] Image fill;
    [SerializeField] AudioMixer mixer;

    [SerializeField] VideoPlayer videoplayer;

    Vector3 mousePos;
    public float volume;
    float fillValue = 0.8f;
    public int dialSensitivity = 5;
    [SerializeField]
    private AudioSource tik;

    private void Start()
    {
        tik.ignoreListenerPause = true;
        //get audiomixer volume

    }

    public Camera camera;
    private Vector3 screenPosition;
    private float angleOffset;
    public float angleMouseDown = 0;
    public float angleMouseUp = 0;
    float posIni = 0;
    private bool getFirstAngleForTurnAchievement = true;
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        //if slider rotation on z axis is not 0

            screenPosition = camera.WorldToScreenPoint(transform.position);
            Vector3 vec3 = Input.mousePosition - screenPosition;
            angleMouseDown = (Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg - 90;
            if (angleMouseDown > 0)
            {
                angleMouseDown = angleMouseDown - 360;
            }
            angleOffset = angleMouseDown - posIni;
            getFirstAngleForTurnAchievement = true;
    }

    public float angle = 0;
    private int previousAngle = 0;
    private int currentAngleAudio = 0;
    private float currentAngle = 0;
    private int currentAngleInt = 0;
    private int startingAngle;
    private int turnsCounter = 0;
    private int previousAngleInt = 0;

    void IDragHandler.OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {

            Vector3 mousePositionInDial = Input.mousePosition - screenPosition;
            angle = Mathf.Atan2(mousePositionInDial.y, mousePositionInDial.x) * Mathf.Rad2Deg - 90;
            if (angle > 0)
            {
                angle = angle - 360;
            }
            currentAngle = angle - angleOffset;
            currentAngleInt = (int)currentAngle;


            if ((int)angle / dialSensitivity != previousAngle)
            {
                if ((int)angle / dialSensitivity < previousAngle)
                {
                    fillValue += 0.005f;
                }
                else
                {
                    fillValue -= 0.005f;
                }

                if (!tik.isPlaying) tik.Play();
                fillValue = Mathf.Clamp01(fillValue);
                previousAngle = (int)angle / dialSensitivity;
            }
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, (currentAngle));



            fill.fillAmount = fillValue;

            // Evitar logaritmo de cero o valores negativos
            float logValue = Mathf.Log10(fillValue);


            if (videoplayer != null)
            {
                videoplayer.SetDirectAudioVolume(0, logValue);
            }

            mixer.SetFloat("MasterParam", logValue * volume);


            if (!gameObject.activeSelf) { eventData.pointerDrag = null; }

    }
}















  