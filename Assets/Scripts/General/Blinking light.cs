using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinkinglight : MonoBehaviour
{
    private Light myLight;
    private float baseIntensity;

    private Renderer objectRenderer;
    private Material objectMaterial;
    private Color baseEmissionColor;

    [Header("Blink Settings")]
    public float minBlinkInterval = 0.05f;
    public float maxBlinkInterval = 0.2f;
    public float minFlickerIntensity = 0.3f;
    public float maxFlickerIntensity = 0.5f;
    [Range(0f, 1f)]
    public float flickerChance = 0.2f;

    private void Start()
    {
        myLight = GetComponentInChildren<Light>();
        baseIntensity = myLight.intensity;

        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            objectMaterial = objectRenderer.material;
            baseEmissionColor = objectMaterial.GetColor("_EmissionColor");
        }
        else
        {
            Debug.LogWarning("No Renderer found on this object to control emissive flicker.");
        }

        StartCoroutine(BlinkRoutine());
    }

    private System.Collections.IEnumerator BlinkRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minBlinkInterval, maxBlinkInterval);
            yield return new WaitForSeconds(waitTime);

            if (Random.value < flickerChance)
            {
                // Flicker light intensity
                myLight.intensity = Random.Range(minFlickerIntensity, maxFlickerIntensity);

                // Turn OFF emissive during flicker
                SetEmission(Color.black);
            }
            else
            {
                // Restore light intensity
                myLight.intensity = baseIntensity;

                // Restore emissive color
                SetEmission(baseEmissionColor);
            }
        }
    }

    private void SetEmission(Color color)
    {
        if (objectMaterial != null)
        {
            objectMaterial.SetColor("_EmissionColor", color);
            DynamicGI.SetEmissive(objectRenderer, color); // Update global illumination (optional)
        }
    }
}
