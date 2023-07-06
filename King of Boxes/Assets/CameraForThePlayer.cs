using UnityEngine;

public class CameraForThePlayer : MonoBehaviour
{
    public Transform target; // Reference to the player object
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Distance and position offset from the player

    void Update()
    {
        if (target != null)
        {
            // Calculate the desired position by adding the player's position and the offset
            Vector3 desiredPosition = target.position + offset;
            // Set the camera's position to the desired position
            transform.position = desiredPosition;
        }
    }
}
