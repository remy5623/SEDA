using TMPro;
using UnityEngine;

public class ResourceUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI foodDisplay;
    [SerializeField] TextMeshProUGUI materialsDisplay;

    private void Update()
    {
        foodDisplay.text = "Food: " + Inventory.food.ToString();
        materialsDisplay.text = "Construction Materials: " + Inventory.constructionMaterials.ToString();
    }
}
