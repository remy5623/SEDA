// Remy Pijuan 2024

using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;

    public static int overworldTime;
    public static int levelTime;
    public static int food = 100;
    public static int constructionMaterials = 500;
    public static int healthBar = 0;
    public static int totalhealth = 0;
    public static int count = 0;


    [SerializeField]
    int initialOverworldTime;
    [SerializeField]
    int initialFood;
    [SerializeField]
    int initialConstructionMaterials;

    [SerializeField] TextMeshProUGUI foodDisplay;
    [SerializeField] TextMeshProUGUI constructionMaterialDisplay;
    [SerializeField] TextMeshProUGUI healthBarDisplay;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            overworldTime = initialOverworldTime;
            food = initialFood;
            constructionMaterials = initialConstructionMaterials;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void SpendFood(int foodSpent)
    {
        food -= foodSpent;
        
        if (food < 0)
        {
            food = 0;
        }
    }

    public static void SpendMaterials(int materialSpent)
    {
        constructionMaterials -= materialSpent;

        if (constructionMaterials < 0)
        {
            constructionMaterials = 0;
        }
    }

    public static void ClearResources()
    {
        food = 0;
        constructionMaterials = 0;
    }

    public static void HealthBarChange()
    {
        healthBar =  totalhealth  / count;
        Debug.Log("TotalHealth : " + totalhealth);
        Debug.Log("Count : " + count);
        Debug.Log("Healthbar : " + healthBar);
    }
}
