using UnityEngine;

public class Building : MonoBehaviour
{
    public TileBase resourceData;

    float buff;

    private void Start()
    {
        PayConstructionCosts();
        //Impact();

        if ( !resourceData.isResourceTapped )
        {
            TimeSystem.AddMonthlyEvent(UpdateResources);
        }

        TimeSystem.AddMonthlyEvent(PayUpkeep);
    }

    public void PayConstructionCosts()
    {
        Inventory.SpendFood(resourceData.buildingCostFood);
        Inventory.SpendMaterials(resourceData.buildingCostConstruction);
    }

    /** Generate resources according to the following equation: Base Output * Building Level * Building Stage */
    public void UpdateResources()
    {
        Inventory.food += Mathf.FloorToInt(resourceData.baseOutputFood * resourceData.buildingLevelMulti * resourceData.buildingOutputStage * (1+buff));
        Inventory.constructionMaterials += Mathf.FloorToInt(resourceData.baseOutputConstruction * resourceData.buildingLevelMulti * resourceData.buildingOutputStage * (1+buff));
    }
    
    public void PayUpkeep()
    {
        Inventory.SpendFood(resourceData.upKeepCostFood);
        Inventory.SpendMaterials(resourceData.upKeepCostConstruction);
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
                        objectInRadius.TransferFood(resourceData.transferFood);
                        objectInRadius.TransferMaterials(resourceData.transferConstruction);
                        SetBuffs(objectInRadius);
                    }
                }
            }
        }
    }

    public void TransferFood(int food)
    {
        Inventory.food += resourceData.transferFood;
    }

    public void TransferMaterials(int materials)
    {
        Inventory.constructionMaterials += resourceData.transferConstruction;
    }

    public void SetBuffs(Building resource)
    {
        resource.buff += resourceData.buffAmount;
        resource.buff -= resourceData.nerfAmount;
    }
}
