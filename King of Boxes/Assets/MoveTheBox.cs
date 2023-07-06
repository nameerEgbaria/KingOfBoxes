using UnityEngine;

public class MoveTheBox: MonoBehaviour
{
    public float pushForce = 10f; // The force applied to the box when pushing

    private Rigidbody playerRigidbody; // Reference to the player's Rigidbody component

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        playerRigidbody.velocity = movement;

        // Check if the player is pushing a box
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
        {
            if (hit.collider.CompareTag("Box"))
            {
                Rigidbody boxRigidbody = hit.collider.GetComponent<Rigidbody>();
                if (boxRigidbody != null)
                {
                    // Apply a force to push the box
                    boxRigidbody.velocity = playerRigidbody.velocity * pushForce;
                }
            }
        }
    }
}
