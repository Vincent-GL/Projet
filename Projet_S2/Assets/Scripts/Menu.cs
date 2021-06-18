using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject SettingsWindow;
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsWindow;
    public void Jouer()
    {
        SceneManager.LoadScene("Leveltuto");
    }

    public void Multi()
    {
        SceneManager.LoadScene("Launcher");
    }
    
    public void Paramètres()
    {
        SceneManager.LoadScene("Paramètres");
    }

    public void Niveau1()
    {
        SceneManager.LoadScene("Niveau1");
    }

    public void CloseSettings()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public void Quitter()
    {
        Application.Quit();
    }
    
    /*-----------------------------------------------------------------------------------------------------------------------------------------------*/
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }
    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    
    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }

    public void LoadSettings()
    {
        Resume();
        SceneManager.LoadScene("Paramètres");
    }
}
