using UnityEngine;

public class Chetos : MonoBehaviour
{
    public Transform destino;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (destino != null)
            {
                transform.position = destino.position;
                transform.rotation = destino.rotation;
            }
        }
    }
}