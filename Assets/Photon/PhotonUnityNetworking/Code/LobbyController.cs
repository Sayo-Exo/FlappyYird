using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Text buttonText;
    [SerializeField]
    private Text statusText;
    [SerializeField]
    private int roomSize;
    private bool connected;
    private bool starting;

    private bool startyes;
    [SerializeField]
    private SpriteRenderer fadeyes;

    void Start()
    {
        fadeyes.gameObject.SetActive(true);
        status("loading");
        StartCoroutine(fadeOut(fadeyes, 0.2f));
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        connected = true;
        buttonText.text = "Begin Game";
        status("loaded");
    }

    void menu() {
        PhotonNetwork.Disconnect();
        StartCoroutine(fadeIn(fadeyes));
    }

    public void GameButton()
    {
        if (connected)
        {
            if (!starting)
            {
                starting = true;
                buttonText.text = "Starting Game...";
                PhotonNetwork.JoinRandomRoom(); // attempt joining a room
            }
            else
            {
                starting = false;
                buttonText.text = "Begin Game";
                PhotonNetwork.LeaveRoom(); // cancel the request
            }
        }
        else
        {
            status("Not connected to server!");
        }
    }

    
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        status("Failed to join a room... creating room");
        CreateRoom();
    }


    void CreateRoom()
    {
        status("Creating room now");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
        GameSetupController.multiplayer = true;
        string room = "Room" + randomRoomNumber;
        PhotonNetwork.CreateRoom(room, roomOps); 
        status("joining room " + room + " with id " + randomRoomNumber);
        StartCoroutine(fadeIn(fadeyes));
    }

    public override void OnCreateRoomFailed(short returnCode, string message) 
    {
        status("Failed to create room... trying again"); 
        CreateRoom();
    }

    private void status(string status) {
        statusText.text = status;
    }

    IEnumerator fadeIn(SpriteRenderer img, float waitTime = 0) {
        yield return new WaitForSeconds(waitTime);
        if (startyes)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }

    IEnumerator fadeOut(SpriteRenderer img, float waitTime = 0) {
        yield return new WaitForSeconds(waitTime);
        if (!startyes)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }

    public void goback()
    {
        StartCoroutine(dothegoback());
    }

    public IEnumerator dothegoback()
    {
        PhotonNetwork.Disconnect();
        StartCoroutine(fadeIn(fadeyes));
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }

}