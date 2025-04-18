using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class SliderWalk : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private Camera camera;
    private Vector3 screenPosition;
    private float angleOffset;
    
    private Vector3 mousePositionInCameraCoords;
    
    [SerializeField] private GameObject slider;
    [SerializeField] private GameObject player;
    [SerializeField] Texture2D cursorClosedTexture;
    [SerializeField] Texture2D cursorOpenedTexture;
    
    
    public AudioSource tik;
    public AudioSource ding;
    public AudioSource mmmmmh;
    public AudioSource steps;
    public float fadeinTime = 1f;

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
    
    public static bool canDrag = false;
    public static bool paused= false;
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
        if(paused){eventData.pointerDrag = null;StartCoroutine(RotateToZero());}
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
                
                //rotate slowly to 0 deegres
                StartCoroutine(RotateToZero());
            }
        }
        canDrag = false;

        if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 25)
        {
            SteamAchievementsManager.UnlockAchievement(SteamAchievementsManager.archWalk);
        }
    }
    private IEnumerator RotateToZero()
    {
        if (!tikPlaying)
        {
            tik.pitch = 1;
            tik.volume = 0f;
            tik.Play();

            mmmmmh.volume = 0f;
            mmmmmh.Play();

            steps.volume = 0f;
            steps.Play();

            StartCoroutine(FadeIn(tik, fadeinTime, 1));
            StartCoroutine(FadeIn(mmmmmh, fadeinTime, 0.3f));
            StartCoroutine(FadeIn(steps, fadeinTime, 1));

            tikPlaying = true;

        }
        
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
    private IEnumerator FadeIn(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0f;
        audioSource.volume = 0f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0f, targetVolume, currentTime / duration);
            yield return null;
        }

        audioSource.volume = targetVolume;
    }

}
