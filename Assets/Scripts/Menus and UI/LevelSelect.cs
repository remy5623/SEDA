using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    private LevelSelect instance;

    /** The level select menu is a singleton
     *  There is only one level selection menu active at any given time
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

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    /** When the active instance of the level select menu is closed, game time will resume */
    private void OnDestroy()
    {
        if (instance == this)
        {
            Time.timeScale = 1f;    // Unpause when the level selection menu is closed
        }
    }
}
