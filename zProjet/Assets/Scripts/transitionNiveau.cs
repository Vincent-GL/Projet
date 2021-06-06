using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionNiveau : MonoBehaviour
{
    
    public int niveau;
    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(niveau);
    }
}
