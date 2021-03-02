using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class launcher : MonoBehaviourPunCallbacks
{
   
    [SerializeField] private GameObject ConnectPannel; // un menu qui Servira à choisir de créer ou rejoindre une partie
    [SerializeField] private GameObject quickmatchbutton; // une fonctionnalité qui sera implémenté plus tard

    [SerializeField] private InputField JoinGameInput;
    [SerializeField] private InputField CreateGameInput;
    string Version = "0.1";
    void Awake()
    {
        PhotonNetwork.GameVersion = Version;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("successfully connected");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server : " + cause);
    }
   
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreateGameInput.text, new RoomOptions { MaxPlayers = 2 }, null);
    }
    public void JoinRoom()
    {
        RoomOptions Roptions = new RoomOptions();
        Roptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, Roptions, TypedLobby.Default);
    }
}
