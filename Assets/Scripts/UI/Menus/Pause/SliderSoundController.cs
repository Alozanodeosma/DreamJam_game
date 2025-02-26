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
    public float volume;
    public void onHandleDrag() {
        mousePos = Input.mousePosition;
        Vector2 dir = mousePos - handle.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = (angle <= 0) ? (360 + angle) : angle;

        Quaternion r = Quaternion.AngleAxis(angle + 135f, Vector3.forward);
        handle.rotation = r;
        
        float fillValue = Mathf.Abs(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) / 180;
        fill.fillAmount = fillValue;
        
        // Evitar logaritmo de cero o valores negativos
        float logValue = Mathf.Log10(fillValue);
        
        
        mixer.SetFloat("Master", logValue * volume);
    }
}