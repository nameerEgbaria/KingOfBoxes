using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    public Camera MainCamera;    // Reference to the main camera.
    public Camera Camera2D;  // Reference to the second camera.
    public PhotonView view2;
    
    void Start()
    {
        view2 = GetComponent<PhotonView>();
        if (view2.IsMine)
        {
            MainCamera.enabled = true;
            Camera2D.enabled = false;
            
        }
        else
        {
            MainCamera.enabled = false;
            Camera2D.enabled = true;
            
        }


    }
    void Update()
    {
        // Check if the "U" key is pressed.
       // if (Input.GetKeyDown(KeyCode.U))
       // {
            // Toggle the active state of the cameras.
       //     MainCamera.enabled = !MainCamera.enabled;
        //    Camera2D.enabled = !Camera2D.enabled;
       // }
    }
}
