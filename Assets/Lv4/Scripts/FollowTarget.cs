using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;  // The target object to follow
    public Vector3 offset;    // Optional offset to adjust the volume's position

    void Update()
    {
        // Update the position of the volume to follow the target
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
