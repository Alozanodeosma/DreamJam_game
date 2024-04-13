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


    public float speed = 5f; // Velocidad del jugador
    public Vector3 moveDirection; // Dirección del movimiento
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();

    }

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
            Rotate((int)sliderRotation.GetComponent<Transform>().eulerAngles.z);
        }
    }
    public void Move()
    {
        //transform.position += moveDirection * speed * Time.deltaTime;
        GetComponent<Rigidbody>().MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
    }
    public void Rotate(int y)
    {
        Vector3 rotation = new Vector3(0.0f, y, 0.0f);

        transform.rotation = Quaternion.Euler(rotation);

    }

}
