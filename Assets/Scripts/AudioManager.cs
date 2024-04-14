using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource tik;
    public AudioSource ding;
    public GameObject sliderWalk;
    bool dingPlayed = false;
    bool tikPlaying= false;
    // Update is called once per frame
    void Update()
    {
        
        if (sliderWalk.transform.eulerAngles.z <= 0.1f && sliderWalk.transform.eulerAngles.z >= -0.1f && !dingPlayed)
        {
            ding.Play();
            dingPlayed = true;
            tikPlaying = false;
        }
        else if (sliderWalk.transform.eulerAngles.z <= 0.1f && sliderWalk.transform.eulerAngles.z >= -0.1f && !dingPlayed)
        {

        }else
        {
            if(!tikPlaying)
            {
                tik.Play();
                tikPlaying = true;
            }
            dingPlayed = false;
        }

    }
}
