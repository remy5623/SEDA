using UnityEngine;

public class Resource : PlaceableObject
{
    [SerializeField]
    TileBase resourceData;

    private void Start()
    {
        TimeSystem.AddMonthlyEvent(PayUpkeep);

        if ( !resourceData.isResourceTapped )
        {
            TimeSystem.AddMonthlyEvent(UpdateResources);
        }
    }

    public void UpdateResources()
    {
        Inventory.food += Mathf.FloorToInt(resourceData.baseOutputFood * resourceData.buildingLevelMulti);
        Inventory.constructionMaterials += Mathf.FloorToInt(resourceData.baseOutputConstruction * resourceData.buildingLevelMulti);
    }
    
    public void PayUpkeep()
    {
        Inventory.food -= resourceData.upKeepCostFood;
        Inventory.constructionMaterials -= resourceData.baseOutputConstruction;
    }

    public override void SetGridObject(GridObject gridObject)
    {
        base.SetGridObject(gridObject);
        resourceData.tileUnder = gridObject;
    }

    public void SetImpact()
    {
        //GridPosition pos = owningGridObject.GetPo
        //for ()
    }
}
