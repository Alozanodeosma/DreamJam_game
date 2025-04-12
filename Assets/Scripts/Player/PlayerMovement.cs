using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject sliderRotation;

    public float speed = 5f;
    public Vector3 moveDirection;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
        //transform.position += moveDirection * (speed * Time.deltaTime);
        if(sliderRotation.GetComponent<RectTransform>().eulerAngles.z != transform.rotation.eulerAngles.y)
        {
            Rotate(sliderRotation.GetComponent<Transform>().eulerAngles.z);
        }
    }
    public void Rotate(float y)
    {
        Vector3 rotation = new Vector3(0.0f, -y, 0.0f);
        transform.rotation = Quaternion.Euler(rotation);
    }
}
