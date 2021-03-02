using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class launcher : MonoBehaviourPunCallbacks
{
    string Version = "0.1";

    [SerializeField] private GameObject usernameMenu;
    [SerializeField] private GameObject ConnectPannel; // Sert à choisir de créer ou rejoindre une partie
    [SerializeField] private GameObject quickmatchbutton;

    [SerializeField] private InputField JoinGameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField usernameInput;

    void Awake()
    {
        PhotonNetwork.GameVersion = Version;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    void Start()
    {
        usernameMenu.SetActive(true);
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
    public void SetUserName()
    {
        usernameMenu.SetActive(false);
        if (usernameInput.text.Length > 0)
            PhotonNetwork.NickName = (usernameInput.text);
        else
        {
            PhotonNetwork.NickName = "Anonyme";
        }
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
