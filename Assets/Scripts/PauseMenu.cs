// Remy Pijuan

using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // The active instance of the pause menu
    private static PauseMenu instance;

    /** The static property GameIsPaused can be accessed by any class to determine whether the game is paused. */
    private static bool gameIsPaused = false;
    public static bool GameIsPaused { get { return gameIsPaused; } }

    /** The pause menu is a singleton
     *  There is only one pause menu active at any given time
     */
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;    // Pause the game when the pause menu is opened
    }

    /** Destroy the pause menu object */
    public void ClosePauseMenu()
    {
        Destroy(gameObject);
    }

    /** Quit the game */
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    /** When the active instance of the pause menu is closed, the game will unpause */
    private void OnDestroy()
    {
        if (instance == this)
        {
            gameIsPaused = false;
            Time.timeScale = 1f;    // Unpause when the pause menu is closed
        }
    }
}
