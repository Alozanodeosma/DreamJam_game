using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con imágenes en UI

public class FadeOut : MonoBehaviour
{
    public float fadeDuration = 2f; // Duración del desvanecimiento en segundos
    private Image imageComponent;  // Componente de imagen asociado al objeto

    void Start()
    {
        // Obtener el componente de imagen
        imageComponent = GetComponent<Image>();

        if (imageComponent != null)
        {
            // Iniciar la corrutina para desvanecer
            StartCoroutine(FadeOutAndDestroy());
        }
        else
        {
            Debug.LogError("No se encontró un componente Image en el objeto.");
        }
    }

    IEnumerator FadeOutAndDestroy()
    {
        // Tiempo inicial del desvanecimiento
        float elapsedTime = 0f;
        Color originalColor = imageComponent.color;
        
        yield return new WaitForSeconds(1.5f);    

        while (elapsedTime < fadeDuration)
        {
            // Calcular el progreso del desvanecimiento
            float alpha = Mathf.Lerp(originalColor.a, 0, elapsedTime / fadeDuration);
            imageComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que el alpha sea exactamente 0
        imageComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);

        // Eliminar el objeto
        Destroy(gameObject);
    }

}
