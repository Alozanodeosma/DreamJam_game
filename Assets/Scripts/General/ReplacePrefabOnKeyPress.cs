using UnityEngine;

public class ReplacePrefabOnKeyPress : MonoBehaviour
{
    public GameObject newPrefab; // Drag the new prefab here in the Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReplaceWithNewPrefab();
        }
    }

    void ReplaceWithNewPrefab()
    {
        if (newPrefab == null)
        {
            Debug.LogWarning("New prefab not assigned!");
            return;
        }

        // Instantiate new prefab at the current position & rotation
        GameObject newObject = Instantiate(newPrefab, transform.position, transform.rotation);

        // Optionally, keep the same parent (if it's part of a hierarchy)
        newObject.transform.parent = transform.parent;

        // Destroy the current object
        Destroy(gameObject);
    }
}
