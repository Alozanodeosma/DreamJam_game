using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public float movementSpeed = 15.0f;
    private float step;
    // Update is called once per frame
    void Update()
    {
        //set wiwi y level to y level of the player
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

        // Move our position a step closer to the target.
        step = movementSpeed * Time.deltaTime; // calculate distance to move
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
