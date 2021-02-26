using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{


    public void Jouer()
    {
        SceneManager.LoadScene("Leveltuto");
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
