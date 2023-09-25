using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraSwitcher : MonoBehaviour
{
    public Camera MainCamera;    // Reference to the main camera.
    public Camera Camera2D;  // Reference to the second camera.
    void Start()
    {
        MainCamera.enabled = true;
        Camera2D.enabled = false;

    }
    void Update()
    {
        // Check if the "U" key is pressed.
        if (Input.GetKeyDown(KeyCode.U))
        {
            // Toggle the active state of the cameras.
            MainCamera.enabled = !MainCamera.enabled;
            Camera2D.enabled = !Camera2D.enabled;
        }
    }
}
