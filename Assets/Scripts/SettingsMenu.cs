using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] public Canvas Pause;

    private void Start()
    {
        if(Pause != null)
            Pause.enabled = false;    
    }

    public void MainM()
    {
        SceneManager.LoadScene("UI Screen");
    }

    public void QuitM()
    {
        Application.Quit();
    }

    public void Settings_clickhere()
    {
        Pause.enabled = false;
    }

    public void Settings()
    {
        Pause.enabled = true;
    }
}
