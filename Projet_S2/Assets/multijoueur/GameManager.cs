using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject plstruct;
    public GameObject gamecanvas;
    public GameObject gamecamera;

    private void Awake()
    {
        gamecanvas.SetActive(true);
    }
    public void SpawnPlayer()
    {
        float move = Random.Range(-1f, 1f);
        PhotonNetwork.Instantiate(plstruct.name, new Vector2(this.transform.position.x * move, this.transform.position.y+4), Quaternion.identity);
        gamecanvas.SetActive(false);
        gamecamera.SetActive(false);
    }
    /*public GameObject playerstructure;

    void Start()
    {
        
        if(playerstructure!=null)
        {
            // PhotonNetwork.Instantiate(this.playerstructure.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
            if (joueur_multi.LocalPlayerInstance == null)
            {
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                PhotonNetwork.Instantiate(this.playerstructure.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
            }
        }
        else
        {
            Debug.Log("erreur");
        }
    }
    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting


        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


            LoadArena();
        }
    }

    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects


        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


            LoadArena();
        }
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0); // charge la scène de choix du nom pour rejoindre un match
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("leaving");
    }
    
    void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }
        PhotonNetwork.LoadLevel("Room for "+ PhotonNetwork.CurrentRoom.PlayerCount);
    }*/
}
