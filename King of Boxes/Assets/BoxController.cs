using UnityEngine;

public class BoxController : MonoBehaviour
{
    private bool isOnTarget = false;
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
        // Check if the box collided with the target
        if (collision.gameObject.CompareTag("target"))
        {
            isOnTarget = true;

            // Change the box's color to green
            GetComponent<Renderer>().material.color = Color.green;

            // Disable the Rigidbody to prevent further movement
            rb.isKinematic = true;
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
