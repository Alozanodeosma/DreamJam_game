using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingAdelanto : MonoBehaviour
{
    private Light myLight;
    private float baseIntensity;

    private Renderer objectRenderer;
    private Material objectMaterial;
    private Color baseEmissionColor;

    public GameObject[] wiwis;
    
    public bool wiwiTrigger = false;

    [Header("Blink Settings")]
    public float minBlinkInterval = 0.05f;
    public float maxBlinkInterval = 0.2f;
    public float minFlickerIntensity = 0f;
    public float maxFlickerIntensity = 0f;
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
                
                if (wiwiTrigger == true)
                {
                    

                        wiwis[Random.Range(0, wiwis.Length)].SetActive(true);
                    
                    
                }
              
                // Flicker light intensity
                myLight.intensity = Random.Range(minFlickerIntensity, maxFlickerIntensity);

                // Turn OFF emissive during flicker
                SetEmission(Color.black);
            }
            else
            {
                for (int i = 0; i < wiwis.Length; i++)
                {
                    wiwis[i].SetActive(false);
                }
                
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
