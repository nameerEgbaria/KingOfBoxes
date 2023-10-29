using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public GameObject[] boxes; // Array to store all the boxes in the scene

    void Update()
    {
        bool allBoxesTurnedGreen = true;

        // Check if all boxes are green
        foreach (GameObject box in boxes)
        {
            Renderer renderer = box.GetComponent<Renderer>();
            if (renderer.material.color != Color.green)
            {
                allBoxesTurnedGreen = false;
                break;
            }
        }

        // If all boxes are green, determine the next scene based on the current scene
        if (allBoxesTurnedGreen)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;

            // Load the appropriate next scene based on the current scene
            if (currentSceneName == "level01")
            {
                SceneManager.LoadScene("level02");
            }
            else if (currentSceneName == "level02")
            {
                SceneManager.LoadScene("finish screen");
            }
            // Add more conditions if you have additional levels

            // Note: Make sure your scene names match the actual scene names in your project.
        }
    }
}
