using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WiwiMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player;
    private Rigidbody r;
    Vector3 pos;
    public float speed = 15.0f;
    void Start()
    {
        r = player.GetComponent<Rigidbody>();
        Vector3 pos = this.transform.position;

    }

    // Update is called once per frame

    void Update()
    {
        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, player.transform.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            player.transform.position *= -1.0f;
        }
        transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x+90, transform.rotation.eulerAngles.y+90, transform.rotation.eulerAngles.z+90);
    }
}
