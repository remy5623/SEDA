using UnityEngine;

public class GridObject : MonoBehaviour
{
    GridSystem owningGridSystem;

    Terrainsystem terrain;
    TerrainTypes terrainType;
    Resource buildingInstance;

    private void Start()
    {
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        // Check for the terrain type under this GridObject, and set references to it
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Terrain")))
        {
            if (terrain = hit.transform.gameObject.GetComponent<Terrainsystem>())
            {
                terrain.owningGridObject = this;
                terrainType = terrain.terraintype;
            }
        }
        else
        {
            terrainType = TerrainTypes.None;
        }
    }

    public void ToggleBuildModePerTile(TileBase buildingType)
    {
        Color transparentGreen = new Color(0, 1, 0, 0.5f);
        Color transparentRed = new Color(1, 0, 0, 0.5f);

        if (!BuildSystem.isInBuildMode)
        {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
        else if (CanBuildOnTile(buildingType))
        {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
            gameObject.GetComponentInChildren<MeshRenderer>().material.color = transparentGreen;
        }
        else
        {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
            gameObject.GetComponentInChildren<MeshRenderer>().material.color = transparentRed;
        }
    }

    public GridSystem GetOwningGridSystem()
    {
        return owningGridSystem;
    }

    public void SetOwningGridSystem(GridSystem system)
    {
        owningGridSystem = system;
    }

    // Instantiates a building on top of this tile.
    public bool TryBuild(TileBase building)
    {
        if (CanBuildOnTile(building))
        {
            GameObject newBuilding = Instantiate(building.inGameAsset, transform);
            buildingInstance = newBuilding.AddComponent<Resource>();
            buildingInstance.resourceData = building;
            buildingInstance.transform.localPosition = Vector3.zero;
            buildingInstance.SetGridObject(this);
            return true;
        }
        return false;
    }

    // Returns whether an object can be built on this GridObject
    public bool CanBuildOnTile(TileBase building)
    {
        bool canBuild = false;

        /*switch(terrainType)
        {
            case TerrainTypes.None:
            case TerrainTypes.River:
            case TerrainTypes.Loch:
            case TerrainTypes.Glen:
                canBuild = false;
                break;
        }*/
        if (building == null)
        { return false; }

        for (int i = 0; i < building.tileTerrainTypes.Count; i++)
        {
            if (terrain && terrain.creaturetype == CreatureTypes.None)
            {
                if (terrainType == building.tileTerrainTypes[i])
                    canBuild = true;
            }
        }

       

        if (buildingInstance != null)
        {
            canBuild = false;
        }

        if (Inventory.food < building.buildingCostFood)
        {
            canBuild = false;
        }

        if (Inventory.constructionMaterials < building.buildingCostMaterial)
        {
            canBuild = false;
        }

        switch(terrainType)
        {
            case TerrainTypes.None:
            case TerrainTypes.River:
            case TerrainTypes.Loch:
            case TerrainTypes.Glen:
                canBuild = false;
                break;
        }

        return canBuild;
    }

    public GridPosition GetGridPosition()
    {
        return new GridPosition(transform.localPosition.x / GetOwningGridSystem().GetCellSize(), transform.localPosition.z / GetOwningGridSystem().GetCellSize());
    }

    public Resource GetBuilding()
    { return buildingInstance; }

    public void SetTerrainEnergy(bool hasEnergy)
    {
        if (terrain != null)
            terrain.energy = hasEnergy;
    }
    public void SetCreatureGone()
    {
        terrain.creaturetype = CreatureTypes.None;
    }

}
