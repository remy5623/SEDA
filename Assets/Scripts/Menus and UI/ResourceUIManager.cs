using TMPro;
using UnityEngine;

public class ResourceUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI foodDisplay;
    [SerializeField] TextMeshProUGUI materialsDisplay;
    [SerializeField] TextMeshProUGUI healthBarDisplay;

    private void Update()
    {
        foodDisplay.text = "Food: " + Inventory.food.ToString();
        materialsDisplay.text = "Construction Materials: " + Inventory.constructionMaterials.ToString();
        healthBarDisplay.text = "Soil Health: " + Inventory.healthBar.ToString();
    }
}
