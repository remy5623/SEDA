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

    // Building Types
    public static int numOfLoggingCamps = 0;
    public static int numOfForests = 0;
    public static int numOfMines = 0;
    public static int numOfRocks = 0;

    // Weather events status
    static bool hasTornadoHappened = false;
    static bool hasFloodHappened = false;

    [SerializeField]
    [InspectorName("Initial Overworld Time (years)")]
    private int initialOverworldTime;

    [SerializeField] TextMeshProUGUI foodDisplay;
    [SerializeField] TextMeshProUGUI constructionMaterialDisplay;
    [SerializeField] TextMeshProUGUI healthBarDisplay;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            overworldTime = initialOverworldTime;
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

    public static void CheckWeather()
    {
        if (!hasTornadoHappened && numOfLoggingCamps > (numOfForests / 2f))
        {
            // TODO: Do Tornado
        }
        // TODO: Else if Cailleach weather
        else if (!hasFloodHappened && numOfMines > (numOfRocks / 2f))
        {
            // TODO: Do Flood
        }
    }
}
