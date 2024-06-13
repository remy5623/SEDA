using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField]
    TileBase resourceData;

    private void Start()
    {
        TimeSystem.AddMonthlyEvent(UpdateResources);
    }

    public void UpdateResources()
    {
        Inventory.food += resourceData.baseOutputFood;
        Inventory.constructionMaterials += resourceData.baseOutputConstruction;
        print(Inventory.constructionMaterials);
    }

    // TODO: Get reference to underlying tile (when Grid System is implemented)
    // TODO: Transfer resources in Impact Radius (when Grid System is implemented)
}
