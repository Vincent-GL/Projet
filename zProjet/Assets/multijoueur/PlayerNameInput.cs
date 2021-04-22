using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private InputField usernameInput;
    const string playerNamePrefKey = "NomJoueur";
    void Start()
    {
        string name = "Anonyme";
        if(usernameInput!=null)
        {
            if(PlayerPrefs.HasKey(playerNamePrefKey))
            {
                name = PlayerPrefs.GetString(playerNamePrefKey);
                usernameInput.text = name;
            }
        }
        PhotonNetwork.NickName = name;
    }

    public void SetUserName(string nom)
    {
        if (nom.Length==0)
        {
            PhotonNetwork.NickName = "Anonyme";
        }
        else
        {
              PhotonNetwork.NickName = (nom);
            PlayerPrefs.SetString(playerNamePrefKey, nom);
        }
       
    }
}
