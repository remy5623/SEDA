using UnityEngine;

public class Resource : MonoBehaviour
{
    public TileBase resourceData;

    float buff;
    float nerf;


    private void Start()
    {
        PayConstructionCosts();
        resourceData.tileUnder.GetOwningGridSystem().ToggleBuildMode(this, true);
        UpdateTotalBuildingCount(true);
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
        Inventory.food += Mathf.FloorToInt(resourceData.baseOutputFood * resourceData.buildingLevelMulti * resourceData.buildingOutputStage * (1+buff+ nerf));
        Inventory.constructionMaterials += Mathf.FloorToInt(resourceData.baseOutputConstruction * resourceData.buildingLevelMulti * resourceData.buildingOutputStage * (1+buff+ nerf));
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
                    Resource objectInRadius;
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

    public void SetBuffs(Resource resource)
    {
        resource.buff += resourceData.buffAmount;
        resource.buff -= resourceData.nerfAmount;
    }

    private void UpdateTotalBuildingCount(bool buildingIsBeingCreated)
    {
        int changeAmount;

        if (buildingIsBeingCreated)
        {
            changeAmount = 1;
        }
        else
        {
            changeAmount = -1;
        }

        switch (resourceData.structureTypes)
        {
            case TileBase.StructureTypes.LoggingCamp:
                Inventory.numOfLoggingCamps += changeAmount;
                break;
            case TileBase.StructureTypes.Forest:
                Inventory.numOfForests += changeAmount;
                break;
            case TileBase.StructureTypes.Rock:
                Inventory.numOfRocks += changeAmount;
                break;
            case TileBase.StructureTypes.Mine:
                Inventory.numOfMines += changeAmount;
                break;
        }
    }

    private void OnDestroy()
    {
        UpdateTotalBuildingCount(false);
    }
}
