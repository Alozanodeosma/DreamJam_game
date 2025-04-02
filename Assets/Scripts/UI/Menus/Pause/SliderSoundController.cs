using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderSoundController : MonoBehaviour {
    [SerializeField] Transform handle;
    [SerializeField] Image fill;
    [SerializeField] AudioMixer mixer;
    Vector3 mousePos;
    private int previousAngle = 0;
    public float volume;
    float fillValue = 0.8f;
    public int dialSensitivity = 5;
    [SerializeField]
    private AudioSource tik;

    private void Start()
    {
        tik.ignoreListenerPause = true;
    }

    public void onHandleDrag() {
        mousePos = Input.mousePosition;
        Vector2 dir = mousePos - handle.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = (angle <= 0) ? (360 + angle) : angle;
        Quaternion r = Quaternion.AngleAxis(angle + 135f, Vector3.forward);
        handle.rotation = r;


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

            if(!tik.isPlaying) tik.Play();
            fillValue = Mathf.Clamp01(fillValue);
            previousAngle = (int)angle/dialSensitivity;
        }
        
        
        
        fill.fillAmount = fillValue;
        
        // Evitar logaritmo de cero o valores negativos
        float logValue = Mathf.Log10(fillValue);
        
        
        mixer.SetFloat("MasterParam", logValue * volume);
    }
}