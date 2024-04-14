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
        
    }

    void FixedUpdate()
    {
        // Definir la dirección hacia el eje -Z (local)
        //get the current direction of the player
       

        // Actualizar la posición del jugador
        transform.position += moveDirection * speed * Time.deltaTime;

        //rota al juagdor
        if(sliderRotation.GetComponent<RectTransform>().eulerAngles.z != transform.rotation.eulerAngles.y)
        {
            Rotate((int)sliderRotation.GetComponent<Transform>().eulerAngles.z);
        }
    }

    public void Rotate(int y)
    {
        Vector3 rotation = new Vector3(0.0f, -y, 0.0f);

        transform.rotation = Quaternion.Euler(rotation);

    }

}
