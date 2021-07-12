using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomController : MonoBehaviourPunCallbacks
{
    
    [SerializeField]
    private int multiplayerSceneIndex;
    [SerializeField]
    private Text statusText;


    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom()
    {
        status("Joined Room. Multiplayer game has begun.");
        StartGame();
    }
    private void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            status("Starting Game");
            PhotonNetwork.LoadLevel(multiplayerSceneIndex);
        }
    }

    public void status(string status) {
        statusText.text = status;
    }
}