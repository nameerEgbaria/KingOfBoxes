using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    PhotonView view;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(view.IsMine)
        {
            rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        }

        // if (Input.GetKeyDown("space"))
        // {
        //     GetComponent<Rigidbody>().velocity = new Vector3(0, 6f, 0);
        // }
        //if (Input.GetKey("up"))
        //{
        //  GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 6f);
        //  }
        //if (Input.GetKeyDown("right"))
        //{
        //   GetComponent<Rigidbody>().velocity = new Vector3(6f, 0, 0);
        // }
        // if (Input.GetKeyDown("left"))
        //{
        //  GetComponent<Rigidbody>().velocity = new Vector3(-6f, 0, 0);
        //}
        //  if (Input.GetKey("down"))
        // {
        //   GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -6f);
        //}

    }
}