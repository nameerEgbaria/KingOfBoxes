using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private GameObject carriedBox; // Reference to the box the player is carrying
    private bool isCarrying; // Flag to check if the player is carrying a box

    private void Update()
    {
        // Check for user input to interact with boxes
        if (Input.GetKeyDown(KeyCode.T))
        {
            // If the player is carrying a box, drop it
            if (isCarrying)
            {
                DropBox();
            }
            else
            {
                // If the player is not carrying a box, try to pick one up
                TryPickUpBox();
            }
        }

        // Check for move forward input and whether the player is carrying a box
        if (isCarrying && Input.GetKey(KeyCode.W))
        {
            EnableBoxPhysics();
        }
    }

    private void TryPickUpBox()
    {
        // Raycast forward from the player to check for boxes
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            if (hit.collider.CompareTag("Box"))
            {
                // Pick up the box
                CarryBox(hit.collider.gameObject);
            }
        }
    }

    private void CarryBox(GameObject box)
    {
        carriedBox = box;
        isCarrying = true;
        // Make the box a child of the player to carry it
        box.transform.parent = transform;
        box.GetComponent<Rigidbody>().isKinematic = true; // Disable box physics
    }

    private void DropBox()
    {
        // Remove the box from the player's child hierarchy
        carriedBox.transform.parent = null;
        carriedBox.GetComponent<Rigidbody>().isKinematic = false; // Enable box physics
        carriedBox = null;
        isCarrying = false;
    }

    private void EnableBoxPhysics()
    {
        if (carriedBox != null)
        {
            carriedBox.GetComponent<Rigidbody>().isKinematic = false; // Enable box physics
            DropBox(); // Drop the box when moving forward while carrying it
        }
    }
}
