using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFuntions : MonoBehaviour
{
    public Canvas MainMenuCanvas;
    public Canvas LoadMenuCanvas;
    public Canvas PauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuCanvas.enabled = true;
        LoadMenuCanvas.enabled = false;
        PauseMenuCanvas.enabled = false;
    }

    public void NewLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadLevel()
    {
        MainMenuCanvas.enabled = false ;
        LoadMenuCanvas.enabled = true ;
        PauseMenuCanvas.enabled = false ;
    }
    public void Settings()
    {
        PauseMenuCanvas.enabled = true;
        MainMenuCanvas.enabled = false;
        LoadMenuCanvas.enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
