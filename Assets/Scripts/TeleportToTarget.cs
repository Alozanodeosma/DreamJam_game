using UnityEngine;

/// <summary>
/// Simple helper component that lets you teleport this GameObject to another GameObject's transform.
/// Attach this to the player (or any object you want to move), then call TeleportTo(target) at runtime.
/// </summary>
public class TeleportToTarget : MonoBehaviour
{
    /// <summary>
    /// Teleport this object to the target's transform.
    /// </summary>
    /// <param name="target">The object to teleport to. Can be null (no-op).</param>
    public void TeleportTo(GameObject target)
    {
        if (target == null)
            return;

        TeleportTo(target.transform);
    }

    /// <summary>
    /// Teleport this object to the target transform.
    /// </summary>
    /// <param name="targetTransform">The transform to teleport to. Can be null (no-op).</param>
    public void TeleportTo(Transform targetTransform)
    {
        if (targetTransform == null)
            return;

        transform.position = targetTransform.position;
        transform.rotation = targetTransform.rotation;
    }
}
