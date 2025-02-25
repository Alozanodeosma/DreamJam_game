using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text introTextComponent;
    [SerializeField] private float introTextSpeed;
    private Queue<string> introText = new Queue<string>() ;
    void Start()
    {
       InitializeIntroText();
       //StartCoroutine(TextCoroutine.AppearText(introTextComponent, introTextSpeed, introText, true));
    }

    private void InitializeIntroText()
    {
        introText.Enqueue("Lately I've been waking up in the middle of the night with a recurring dream...");
        introText.Enqueue("Im so... Hungry...");
        introText.Enqueue("I'll go to heat something up in the microwave");
    }
    
}
