using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

[RequireComponent(typeof(InputField))]
public class PlayerNameInput : MonoBehaviour
{
   
    const string playerNamePrefKey = "NomJoueur";
    void Start()
    {
        InputField usernameInput = this.GetComponent<InputField>();
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
