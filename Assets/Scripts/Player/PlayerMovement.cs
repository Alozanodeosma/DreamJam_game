using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player;
    [SerializeField] private Slider slider;
    private Rigidbody rb;
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
        Vector3 movement = new Vector3(0.0f, 0.0f, 10.0f);
        rb.AddForce(movement);
        Rotate((int)slider.value);
    }

    public void Rotate(int y)
    {
        Vector3 rotation = new Vector3(0.0f, y, 0.0f);
        rb.AddTorque(rotation);
    }

}
