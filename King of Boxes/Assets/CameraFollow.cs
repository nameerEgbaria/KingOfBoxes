using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;           // The player's Transform that the camera will follow
    public float smoothSpeed = 0.125f; // The smoothing speed of the camera movement

    private void LateUpdate()
    {
        if (target == null)
            return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the desired rotation for the camera based on player input
        Quaternion desiredRotation;

        if (verticalInput < 0)
        {
            desiredRotation = Quaternion.Euler(0, target.eulerAngles.y + 180, 0);
        }
        else
        {
            float rotationAmount = horizontalInput * 90.0f;
            desiredRotation = Quaternion.Euler(0, target.eulerAngles.y + rotationAmount, 0);
        }

        // Update the camera's rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);

        // Set the camera's position relative to the player
        Vector3 offset = transform.rotation * new Vector3(0, 2, -5);
        transform.position = target.position + offset;
    }
}
