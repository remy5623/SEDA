using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    /** Destroy the pause menu object */
    public void ClosePauseMenu()
    {
        Destroy(gameObject);
    }

    /** Load the main  menu */
    public void GoToMainMenu()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
