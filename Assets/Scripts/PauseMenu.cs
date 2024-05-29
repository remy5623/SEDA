// Remy Pijuan

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // The active instance of the pause menu
    private static PauseMenu instance;

    /** The static property GameIsPaused can be accessed by any class to determine whether the game is paused. */
    private static bool gameIsPaused = false;
    public static bool GameIsPaused { get { return gameIsPaused; } }

    [SerializeField]
    [Tooltip("The name of the Main Menu scene.")]
    public string mainMenuSceneName = "UI Screen";

    //[SerializeField]
    //PlayerInput PlayerInput;

    InputAction PossessCameraAction;
    InputAction RotateCameraAction;
    InputAction UnpossessCameraAction;
    InputAction ZoomAction;
    
    public InputActionAsset action;

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

        PossessCameraAction = action.FindAction("PossessCamera");
        RotateCameraAction = action.FindAction("RotateCamera");
        UnpossessCameraAction = action.FindAction("UnpossessCamera");
        ZoomAction = action.FindAction("MouseWheelZoom");

        if(PossessCameraAction != null)
            PossessCameraAction.Disable();
        if(RotateCameraAction != null)
            RotateCameraAction.Disable();
        if(UnpossessCameraAction != null)
            UnpossessCameraAction.Disable();
        if(ZoomAction != null)
            ZoomAction.Disable();

        //PlayerInput.SwitchCurrentActionMap("Pause Menu");
    }

    /** Destroy the pause menu object */
    public void ClosePauseMenu()
    {
        Destroy(gameObject);
    }

    /** Exit the current scene and load the the Main Menu
     *  If the pause menu has been opened inside the Main Menu, simply close the pause menu
     */
    public void ReturnToMainMenu()
    {
        if (SceneManager.GetActiveScene().name == mainMenuSceneName)
        {
            ClosePauseMenu();
        }
        else
        {
            SceneManager.LoadSceneAsync(mainMenuSceneName);
        }
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

            PossessCameraAction.Enable();
            RotateCameraAction.Enable();
            UnpossessCameraAction.Enable();
            ZoomAction.Enable();
            //PlayerInput.SwitchCurrentActionMap("Camera");
        }
    }
}
