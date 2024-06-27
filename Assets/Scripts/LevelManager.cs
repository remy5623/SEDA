// Remy Pijuan 2024

using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Level Settings is a singleton
    private static LevelManager instance;
    
    // time in months
    public int levelTimeStore;

    [SerializeField] int successFoodAmount;
    [SerializeField] int successConstructionMaterialsAmount;
    [SerializeField] int successSoilHealth;


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

    public static bool AreSuccessConditionsMet()
    {
        bool success = true;

        if (Inventory.food < instance.successFoodAmount)
        {
            success = false;
        }

        if (Inventory.constructionMaterials < instance.successConstructionMaterialsAmount)
        {
            success = false;
        }

        if (Inventory.healthBar < instance.successSoilHealth)
        {
            success = false;
        }    

        return success;
    }
}
