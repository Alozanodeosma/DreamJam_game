using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text introTextComponent;
    [SerializeField] private float introTextSpeed;
    private Queue<string> introText = new Queue<string>() ;
    public static bool cancelDragWhenOutOfTheDial = false;
    public static bool activateCursorChange = false;
    [SerializeField] AudioSource letterSound;
    
    [SerializeField] private GameObject SkipButton;
    [SerializeField] private GameObject ShowSkipButton;
    [SerializeField] private AudioSource audioCinematic;

    private TextCoroutine text;

    void Start()
    {
        Time.timeScale = 1;
        InitializeIntroText();
        StartCoroutine(StartTextSafely());
    }

    private IEnumerator StartTextSafely()
    {
        while (TextCoroutine.Instance == null)
            yield return null; // Wait until instance is ready

        TextCoroutine.Instance.StartAppearingText(introTextComponent, introTextSpeed, introText, true, letterSound);
    }


    private void InitializeIntroText()
    {
        introText.Enqueue($"Lately, I've been waking up in the dead of night, haunted by the same <color=red>recurring dream...</color>");
        introText.Enqueue("Im so... <color=red>Hungry...</color>");
        introText.Enqueue("I'll heat something up in the <color=red>microwave.</color>");
    }

    public void SetActiveSkipButton()
    {
        SkipButton.SetActive(true);
        ShowSkipButton.SetActive(false);
    }
    public void SkipCinematic()
    {
        introTextComponent.text = "";
        GameObject.Find("Panel").SetActive(false);
        gameObject.GetComponent<AudioSource>().volume = 0;
        SkipButton.SetActive(false);
        TextCoroutine.Instance.StopAllCoroutines();
        audioCinematic.volume = 0; //quitar sonido cinematica, ns si el volume = 0 de dos lineas mas servia para esto
    }

}
