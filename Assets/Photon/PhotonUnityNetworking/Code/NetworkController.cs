using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text statusText;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        status("Connection made to " + PhotonNetwork.CloudRegion + " server");
    }

    void status(string status) {
        statusText.text = status;
    }
}
