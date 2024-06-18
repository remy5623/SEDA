// Remy Pijuan 2024

using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    // Level Settings is a singleton
    private static LevelSettings instance;
    
    // time in months
    public int levelTimeStore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Inventory.levelTime = levelTimeStore;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
