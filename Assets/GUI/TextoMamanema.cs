using System.Collections;
using TMPro;
using UnityEngine;

public class TextoMamanema : MonoBehaviour
{
    public float letterAppearDelay = 0.2f; // Delay between each letter appearing
    private TMP_Text textComponent;
    private string originalText;
    [SerializeField] private GameObject babayaga;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        originalText = textComponent.text;
        textComponent.text = ""; // Clear text initially
        StartCoroutine(AppearText());
    }

    IEnumerator AppearText()
    {
        for (int i = 0; i < originalText.Length; i++)
        {
            textComponent.text += originalText[i]; // Append one letter at a time
            yield return new WaitForSeconds(letterAppearDelay);
        }
        yield return new WaitForSeconds(2f);
        babayaga.SetActive(true);
        //make the text fade out

        for (float i = 1; i >= 0; i -= 0.01f)
        {
            textComponent.color = new Color(0.8490566f, 0.7675287f, 0.7080812f, i);
            yield return new WaitForSeconds(0.01f);
        }

        
        gameObject.SetActive(false); // Hide the text after all letters have appeared
    }
}