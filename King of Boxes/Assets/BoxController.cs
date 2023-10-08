using UnityEngine;

public class BoxController : MonoBehaviour
{
    private bool isOnTarget = false;
    private bool hasChangedColor = false;
    private Color originalColor;
    private Rigidbody rb;

    void Start()
    {
        // Store the original color of the box
        originalColor = GetComponent<Renderer>().material.color;

        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the box collided with the target and if its color has not been changed yet
        if (collision.gameObject.CompareTag("target") && !hasChangedColor)
        {
            isOnTarget = true;

            // Change the box's color to green
            GetComponent<Renderer>().material.color = Color.green;

            // Set the flag to true to indicate that the color has been changed
            hasChangedColor = true;

            // Disable the Rigidbody to prevent further movement
            rb.isKinematic = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if the box is moving out of the target
        if (collision.gameObject.CompareTag("target"))
        {
            // Reset the color to its original color only if it has been changed
            if (hasChangedColor && isOnTarget == false)
            {
                GetComponent<Renderer>().material.color = originalColor;
                hasChangedColor = false; // Reset the flag
            }
            isOnTarget = false;


            // Enable the Rigidbody to allow movement again
           if(!PlayerInteract.isCarrying)
                rb.isKinematic = false;
        }
    }

    void Update()
    {
        // If the box is on the target, prevent any further movement
        if (isOnTarget)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
