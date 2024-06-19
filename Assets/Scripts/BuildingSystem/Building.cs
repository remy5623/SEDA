using System.Collections.Generic;
using UnityEngine;


public class Building : MonoBehaviour
{
    public TileBase resourceData;

    float buff;
    float nerf;
    
    public Terrainsystem instance;
    TerrainTypes terrainType;
    

    private void Start()
    {
        terrainType = instance.terraintype;

        PayConstructionCosts();
        resourceData.tileUnder.GetOwningGridSystem().ToggleBuildMode(this, true);
        //Impact();

        resourceData.tileUnder.CanBuildOnTile(this);

        if ( !resourceData.isResourceTapped )
        {
            TimeSystem.AddMonthlyEvent(UpdateResources);
        }

        TimeSystem.AddMonthlyEvent(PayUpkeep);
    }

    public void PayConstructionCosts()
    {
        Inventory.SpendFood(resourceData.buildingCostFood);
        Inventory.SpendMaterials(resourceData.buildingCostMaterial);
    }

    /** Generate resources according to the following equation: Base Output * Building Level * Building Stage */
    public void UpdateResources()
    {
        Inventory.food += Mathf.FloorToInt(resourceData.baseOutputFood * (1+buff+ nerf));
        Inventory.constructionMaterials += Mathf.FloorToInt(resourceData.baseOutputMaterial * (1+buff+ nerf));
    }
    
    public void PayUpkeep()
    {
        Inventory.SpendFood(resourceData.upKeepCostFood);
        Inventory.SpendMaterials(resourceData.upKeepCostMaterial);
    }

    public GridObject GetOwningGridObject()
    {
        return resourceData.tileUnder;
    }    

    public void SetGridObject(GridObject gridObject)
    {
        resourceData.tileUnder = gridObject;
    }

    public void Impact()
    {
        GridPosition pos = GetOwningGridObject().GetGridPosition();
        int radius = resourceData.impactRadiusTiles;

        for (int x = pos.x - radius; x < pos.x + radius; x++)
        {
            for (int z = pos.z - radius; z < pos.z + radius; z++)
            {
                if (x >= 0 && z >= 0 && x < GetOwningGridObject().GetOwningGridSystem().GetGridLength() && z < GetOwningGridObject().GetOwningGridSystem().GetGridWidth())
                {
                    // TODO: Filter by structure type
                    Building objectInRadius;
                    if ((objectInRadius = GetOwningGridObject().GetOwningGridSystem().GetGridObject(x, z).GetBuilding()) && (new GridPosition(x, z) != pos))
                    {
                        SetBuffs(objectInRadius);
                    }
                }
            }
        }
    }

    public void SetBuffs(Building resource)
    {
        resource.buff += resourceData.buffAmount;
        resource.buff -= resourceData.nerfAmount;
    }

   
}
