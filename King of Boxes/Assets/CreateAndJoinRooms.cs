using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{

    public InputField createInput;
    public InputField joinInput;

    public void CreateRoom()
    {
        Debug.Log("im heeeeeereeeee1");
        PhotonNetwork.CreateRoom(createInput.text);
        Debug.Log("im heeeeeereeeee2");
    }

    public void JoinRoom()
    {
        Debug.Log("im heeeeeereeeee5");
        PhotonNetwork.JoinRoom(joinInput.text);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("im heeeeeereeeee3");
        PhotonNetwork.LoadLevel("level01");
        Debug.Log("im heeeeeereeeee4");
    }
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
