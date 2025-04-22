using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextCoroutine: MonoBehaviour
{
    public static TextCoroutine Instance { get; private set; }

    private GameObject panel;
    private bool showingText = false;
    private bool panelCreated = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void StartAppearingText(TMP_Text textComponent, float letterDelay, Queue<string> textToShow, bool activeBlackPanel = false, AudioSource letterSound = null)
    {
        StartCoroutine(AppearText(textComponent, letterDelay, textToShow, activeBlackPanel, letterSound));
    }

    private IEnumerator AppearText(TMP_Text textComponent, float letterAppearDelay, Queue<string> textToShow,
        bool activeBlackPanel = false, AudioSource letterSound = null)
    {
        while (textToShow.Count > 0)
        {
            string originalText = textToShow.Dequeue();
            if (!showingText)
            {
                showingText = true;

                if (!panelCreated && activeBlackPanel)
                {
                    panel = CreateBlackPanel(textComponent);
                    panelCreated = true;
                }

                textComponent.maxVisibleCharacters = 0;
                string parsedText = ParseText(textComponent, originalText);
                AdjustTextSize(textComponent, originalText);

                for (int i = 0; i < parsedText.Length; i++)
                {
                    if (letterSound != null) letterSound.Play();
                    textComponent.maxVisibleCharacters++;
                    if (!this.isActiveAndEnabled)
                    {
                        Debug.LogWarning("Coroutine is running on a disabled MonoBehaviour!");
                        yield break;
                    }
                    yield return new WaitForSeconds(letterAppearDelay);
                }

                yield return new WaitForSeconds(2f);
                showingText = false;
            }
        }

        for (float i = 1; i >= 0; i -= 0.01f)
        {
            textComponent.color = new Color(0.85f, 0.77f, 0.71f, i);

            if (activeBlackPanel && panel != null)
            {
                panel.GetComponent<Image>().color = new Color(0, 0, 0, i);
                if (panel.GetComponent<Image>().color.a <= 0) Destroy(panel);
            }

            CheckForSetActiveSkipButton();

            if (CheckForSkipButton())
            {
                GameObject skipText = GameObject.Find("SkipButtonText");
                if (skipText != null)
                    skipText.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, i);
                if (skipText.GetComponent<TextMeshProUGUI>().color.a <= 0)
                    Destroy(GameObject.Find("SkipButton"));
            }

            yield return new WaitForSeconds(0.01f);
        }
    }

    private void CheckForSetActiveSkipButton()
    {
        GameObject button = GameObject.Find("SetActiveSkipButton");
        if (button != null) button.SetActive(false);
    }

    private bool CheckForSkipButton() => GameObject.Find("SkipButton") != null;

    private GameObject CreateBlackPanel(TMP_Text textComponent)
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

    private void AdjustTextSize(TMP_Text textComponent, string originalText)
    {
        textComponent.enableAutoSizing = true;
        textComponent.fontSizeMin = 5f;
        textComponent.fontSizeMax = 40f;
        textComponent.text = originalText;
        textComponent.ForceMeshUpdate();

        float adjustedFontSize = textComponent.fontSize;
        textComponent.enableAutoSizing = false;
        textComponent.fontSize = adjustedFontSize;
    }

    private string ParseText(TMP_Text textComponent, string originalText)
    {
        textComponent.text = originalText;
        textComponent.ForceMeshUpdate();
        return textComponent.GetParsedText();
    }
}
