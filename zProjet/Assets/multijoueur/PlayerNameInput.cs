using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private GameObject usernameMenu;
    [SerializeField] private InputField usernameInput;

    void Start()
    {
        usernameMenu.SetActive(true);
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
}
