using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartCinematic : MonoBehaviour
{
    public VideoPlayer cinematicVideoPlayer;
    public float fadeDuration = 1.0f;
    public Image fadeImage;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object is the player
        if (other.CompareTag("Player"))
        {
            // Start fade out
            if (fadeImage != null)
            {
                StartCoroutine(FadeOut());
            }

            // Play the cinematic video
            if (cinematicVideoPlayer != null)
            {
                StartCoroutine(PlayCinematic());
            }
            else
            {
                Debug.LogError("Cinematic Video Player is not assigned!");
            }
        }
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0.0f;
        Color initialColor = fadeImage.color;
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1.0f);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeImage.color = Color.Lerp(initialColor, targetColor, elapsedTime / fadeDuration);
            yield return null;
        }
    }

    IEnumerator PlayCinematic()
    {
        yield return new WaitForSeconds(fadeDuration);

        // Play the cinematic video
        cinematicVideoPlayer.Play();
    }
}
