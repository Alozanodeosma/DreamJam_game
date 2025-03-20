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
    [SerializeField] private Texture2D cursorTexture;
    
    
    [SerializeField] private GameObject SkipButton;
    [SerializeField] private GameObject ShowSkipButton;
    
    void Start()
    {
       InitializeIntroText();
       if(activateCursorChange) { Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto); }
       StartCoroutine(TextCoroutine.AppearText(introTextComponent, introTextSpeed, introText, true));
       
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
        introTextComponent.transform.position = new Vector3(10000, 10000, 10000); //chapuzada historica, hace que no se vea la corrutina cuando se skipea
        GameObject.Find("Panel").SetActive(false);
        SkipButton.SetActive(false);
    }
    
}
