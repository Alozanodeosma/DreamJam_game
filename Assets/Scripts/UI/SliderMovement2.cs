using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement2 : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 difference = new Vector2();
    void OnMouseDown()
    {
        difference=(Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position);
    }
    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)-difference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
