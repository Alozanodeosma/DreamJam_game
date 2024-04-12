using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player;
    [SerializeField] private Slider slider;
    private Rigidbody rb;


    public float speed = 5f; // Velocidad del jugador
    private Vector3 moveDirection; // Direcci�n del movimiento
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
        // Definir la direcci�n hacia el eje -Z (local)
        //get the current direction of the player
        moveDirection = transform.forward;


        // Actualizar la posici�n del jugador
        transform.position += moveDirection * speed * Time.deltaTime;

        //rota al juagdor
        if((int)slider.value != transform.rotation.eulerAngles.y && transform.rotation.eulerAngles.y!=0)
        {
            Rotate((int)slider.value);
        }
    }

    public void Rotate(int y)
    {
        Vector3 rotation = new Vector3(0.0f, y, 0.0f);

        transform.rotation = Quaternion.Euler(rotation);

    }

}
