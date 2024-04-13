using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player;
    //[SerializeField] private Slider slider;
    [SerializeField] private GameObject sliderRotation;
    [SerializeField] private GameObject sliderWalk;
    private Rigidbody rb;

    float rotationSpeed = 200f; // Velocidad de rotación en grados por segundo
    public float speed = 5f; // Velocidad del jugador
    public Vector3 moveDirection; // Dirección del movimiento
    bool left = false;
    bool right = false;
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();

    }
    public float sensitivity = 0.5f; // Adjust this to control the sensitivity of rotation
    public float maxRotation = 180f; // Maximum rotation in degrees
    public float rotationSpeedMultiplier = 1f; // Adjust this to control the rotation speed multiplier
    private float draggedRotationTotal;

    private Vector3 lastMousePosition;
    private float accumulatedRotation;
    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Collider>() != null)
        {
            //active gravity
            rb.useGravity = true;
        }
        else
        {
            rb.useGravity = true;          
        }

        if (Input.GetMouseButton(0))
        {
            // Calculate the difference in mouse position since the last frame
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 mouseDelta = currentMousePosition - lastMousePosition;

            // Calculate rotation speed based on mouse movement and sensitivity
            float rotationSpeed = -mouseDelta.x * rotationSpeedMultiplier * Time.deltaTime;

            // Apply rotation to the dragged object
            sliderRotation.transform.Rotate(Vector3.up, rotationSpeed);

            // Update the total rotation of the dragged object
            draggedRotationTotal += rotationSpeed;

            // Calculate the rotation for the stationary object based on the total rotation of the dragged object
            float stationaryRotation = Mathf.Lerp(90f, -90f, Mathf.PingPong(draggedRotationTotal / 360f, 1f));

            // Apply the rotation to the stationary object
            transform.rotation = Quaternion.Euler(0f, stationaryRotation, 0f);
        }

        // Store the current mouse position for the next frame
        lastMousePosition = Input.mousePosition;
    }




    void FixedUpdate()
    {
        // Definir la dirección hacia el eje -Z (local)
        //get the current direction of the player


        // Actualizar la posición del jugador
        if (sliderWalk.GetComponent<SliderWalk>().isRotating)
        {
            Move();
        }

        //rota al juagdor
        if (sliderRotation.GetComponent<RectTransform>().eulerAngles.z != transform.rotation.eulerAngles.y)
        {
            //make the max rotation speed 1.5f
            //rotate left from 0f speed to 1.5f speed while left is true
            if (left)
            {
                transform.Rotate(Vector3.up * 1.5f);
            }
            else if(right)
            {
                transform.Rotate(Vector3.down * 1.5f);
            }
            else
            {
                transform.Rotate(Vector3.zero);
            }
        }
    }
    public void Move()
    {
        //transform.position += moveDirection * speed * Time.deltaTime;
        GetComponent<Rigidbody>().MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
    }
    public void Rotate(int y)
    {/*
        Vector3 rotation = new Vector3(0.0f, y, 0.0f);

        transform.rotation = Quaternion.Euler(rotation);
        */


            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(0, -rotationAmount, 0);
        
    }

}
