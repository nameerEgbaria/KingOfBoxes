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

        // If all boxes are green, load the finish scene
        if (allBoxesTurnedGreen)
        {
            SceneManager.LoadScene("Finish Screen"); // Replace "FinishScene" with the actual name of your finish scene
        }
    }
}
