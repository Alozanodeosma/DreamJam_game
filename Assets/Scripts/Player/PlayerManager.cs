using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text introTextComponent;
    [SerializeField] private float introTextSpeed;
    private Queue<string> introText = new Queue<string>() ;
    public static bool cancelDragWhenOutOfTheDial = false;
    public static bool activateCursorChange = false;
    [SerializeField] private Texture2D cursorTexture;
    void Start()
    {
       InitializeIntroText();
       if(activateCursorChange) { Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto); }
       //StartCoroutine(TextCoroutine.AppearText(introTextComponent, introTextSpeed, introText, true));
    }

    private void InitializeIntroText()
    {
        introText.Enqueue($"Lately I've been waking up in the middle of the night with a <color=red>recurring dream...</color>");
        introText.Enqueue("Im so... <color=red>Hungry...</color>");
        introText.Enqueue("I'll go to heat something up in the <color=red>microwave</color>");
    }
    
}
