using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;           // The player's Transform that the camera will follow
    public float smoothSpeed = 0.125f; // The smoothing speed of the camera movement
    public Vector3 offset = new Vector3(0, 2, -5); // The offset from the player's position
    public float lookaheadDistance = 2.0f; // How much the camera looks ahead of the player

    private void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate the desired position for the camera based on the player's position and offset
        Vector3 desiredPosition = target.position + offset;

        // Calculate a lookahead position based on the player's movement
        Vector3 lookaheadPosition = target.position + target.forward * lookaheadDistance;

        // Interpolate between the desired position and lookahead position to follow the player
        Vector3 smoothedPosition = Vector3.Lerp(desiredPosition, lookaheadPosition, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;

        // Make the camera look at the player
        transform.LookAt(target);
    }
}
