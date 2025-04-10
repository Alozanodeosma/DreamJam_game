using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class TextCoroutine
{
    private static GameObject panel;
    private static bool showingText = false;
    private static bool panelCreated = false;
    public static IEnumerator AppearText(TMP_Text textComponent, float letterAppearDelay, Queue<string> textToShow,
        bool activeBlackPannel = false, AudioSource letterSound = null)
    {
        float originalLetterAppearDelay = letterAppearDelay;
        while (textToShow.Count > 0)
        {

            string originalText = textToShow.Dequeue().ToString();
            if (!showingText)
            {
                showingText = true;

                if (!panelCreated && activeBlackPannel)
                {
                    panel = CreateBlackPannel(textComponent);
                    panelCreated = true;
                }

                textComponent.maxVisibleCharacters = 0;
                string parsedText = ParseText(textComponent, originalText);
                AdjustTextSize(textComponent, originalText);
                
                for (int i = 0; i < parsedText.Length; i++)
                {
                    if (letterSound != null)
                    {
                        letterSound.Play();
                    }
                    textComponent.maxVisibleCharacters++;
                    yield return new WaitForSeconds(letterAppearDelay);
                }

                yield return new WaitForSeconds(2f);
                showingText = false;
            }
        }

        for (float i = 1; i >= 0; i -= 0.01f)
        {
            textComponent.color = new Color(0.8490566f, 0.7675287f, 0.7080812f, i);
            if(activeBlackPannel){
                if (panel != null) panel.GetComponent<Image>().color = new Color(0, 0, 0, i);
                if (panel.GetComponent<Image>().color == new Color(0, 0, 0, 0)) GameObject.Destroy(panel);
            }

            CheckForSetActiveSkipButton();
            if (CheckForSkipButton())
            {
                GameObject skipButton = GameObject.Find("SkipButtonText");
                if (skipButton != null) skipButton.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, i);
                if (skipButton.GetComponent<TextMeshProUGUI>().color == new Color(0, 0, 0, 0)) GameObject.Destroy(GameObject.Find("SkipButton"));
            }
            yield return new WaitForSeconds(0.01f);
        }


    }

    private static void CheckForSetActiveSkipButton()
    {
        if(GameObject.Find("SetActiveSkipButton")!=null) GameObject.Find("SetActiveSkipButton").SetActive(false);
    }
    private static bool CheckForSkipButton()
    {
        return GameObject.Find("SkipButton") != null;
    }
    private static GameObject CreateBlackPannel(TMP_Text textComponent)
    {
        GameObject panel = new GameObject("Panel");
        panel.AddComponent<CanvasRenderer>();
        Image imageComponent = panel.AddComponent<Image>();
        imageComponent.color = Color.black;
        panel.transform.SetParent(textComponent.transform.parent);
        panel.transform.SetPositionAndRotation(textComponent.transform.position, textComponent.transform.rotation);
        panel.transform.SetSiblingIndex(6);
        return panel;
    }

    private static void AdjustTextSize(TMP_Text textComponent, string originalText)
    {
        textComponent.enableAutoSizing = true;
        textComponent.fontSizeMin = 5f;
        textComponent.fontSizeMax = 40f;
        textComponent.text = originalText;
        textComponent.ForceMeshUpdate();
        
        float adjustedFontSize = textComponent.fontSize;
        textComponent.enableAutoSizing = false;
        textComponent.fontSize = adjustedFontSize;

        //textComponent.text = "";
    }

    private static string ParseText(TMP_Text textComponent, string originalText)
    {
        textComponent.text = originalText;
        textComponent.ForceMeshUpdate();
        string parsedText = textComponent.GetParsedText();
        textComponent.ForceMeshUpdate();
        return parsedText;
    }
}