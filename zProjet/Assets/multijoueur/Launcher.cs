using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject controlPanel;
    [SerializeField]
    private GameObject progressPanel;
    private byte maxPlayersPerRoom = 2;
    string GameVersion = "0.1";
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        progressPanel.SetActive(false);
        controlPanel.SetActive(true);
    }

    public void Connect()
    {
        progressPanel.SetActive(true);
        controlPanel.SetActive(false);
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = GameVersion;
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("successfully connected to Master");
        PhotonNetwork.JoinRandomRoom();
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        progressPanel.SetActive(false);
        controlPanel.SetActive(true);
        Debug.LogWarningFormat("Disconnected for the following reason : {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("couldn't join a random room");
        //   RoomOptions Roptions = new RoomOptions();
        // Roptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        //PhotonNetwork.CreateRoom(null, Roptions);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Successfully joined a room");
            PhotonNetwork.LoadLevel("Room for 2");
        
       
    }
}
