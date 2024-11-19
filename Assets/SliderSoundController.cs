using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderSoundController : MonoBehaviour {
    [SerializeField] Transform handle;
    [SerializeField] Image fill;
    Vector3 mousePos;
    public void onHandleDrag() {
        
        
        mousePos = Input.mousePosition;
        Vector2 dir = mousePos - handle.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = (angle <= 0) ? (360 + angle) : angle;
        
            Quaternion r = Quaternion.AngleAxis(angle + 135f, Vector3.forward);
            handle.rotation = r;
            Debug.Log(angle);
            fill.fillAmount = Mathf.Abs(Mathf.Atan2(dir.y, dir.x)* Mathf.Rad2Deg)/180;
            Debug.Log(fill.fillAmount);
            AudioListener.volume = Mathf.Round(Mathf.Pow(fill.fillAmount, 3) * 100);
        //Debug.Log(Mathf.Abs(Mathf.Atan2(dir.y, dir.x)* Mathf.Rad2Deg)/180*100);

       


    }
}