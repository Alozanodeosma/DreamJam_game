using UnityEngine;

[RequireComponent(typeof(Camera))]
public class AspectRatioEnforcer : MonoBehaviour
{
    public Vector2 targetAspectRatio = new Vector2(16, 9);

    private int lastScreenWidth;
    private int lastScreenHeight;
    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        lastScreenWidth = Screen.width;
        lastScreenHeight = Screen.height;

        UpdateCameraViewport();
    }

    void Update()
    {
        if (Screen.width != lastScreenWidth || Screen.height != lastScreenHeight)
        {
            lastScreenWidth = Screen.width;
            lastScreenHeight = Screen.height;

            UpdateCameraViewport();
        }
    }

    void UpdateCameraViewport()
    {
        float targetAspect = targetAspectRatio.x / targetAspectRatio.y;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            Rect rect = cam.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            cam.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = cam.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            cam.rect = rect;
        }
    }
}
