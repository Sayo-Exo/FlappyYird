using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameSetupController : MonoBehaviour
{
    public static bool multiplayer;
    public GameObject birdboi;
    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Debug.Log("Creating Player, multiplayer " + multiplayer);
        if (multiplayer)
            PhotonNetwork.Instantiate(Path.Combine("Photon", "BIRD"), Vector3.zero, Quaternion.identity);
        else
            Instantiate(birdboi);
    }
}