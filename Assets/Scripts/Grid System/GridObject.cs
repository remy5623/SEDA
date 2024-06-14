using UnityEngine;

public class GridObject : MonoBehaviour
{
    GridSystem owningGridSystem;

    Terrainsystem terrain;
    TerrainTypes terrainType;
    Building buildingInstance;

    private void Start()
    {
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

    public void ToggleBuildModePerTile(Building buildingType)
    {
        Color transparentWhite = new Color(1, 1, 1, 0f);
        Color transparentGreen = new Color(0, 1, 0, 0.3f);
        Color transparentRed = new Color(1, 0, 0, 0.3f);

        if (!BuildSystem.isInBuildMode)
        {
            gameObject.GetComponentInChildren<MeshRenderer>().material.color = transparentWhite;
        }
        else if (CanBuildOnTile(buildingType))
        {
            gameObject.GetComponentInChildren<MeshRenderer>().material.color = transparentGreen;
        }
        else
        {
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
    public bool TryBuild(Building building)
    {
        if (CanBuildOnTile(building))
        {
            buildingInstance = Instantiate(building.gameObject, transform).GetComponent<Building>();
            buildingInstance.transform.localPosition = Vector3.zero;
            buildingInstance.SetGridObject(this);
            ToggleBuildModePerTile(building);
            return true;
        }
        return false;
    }

    // Returns whether an object can be built on this GridObject
    public bool CanBuildOnTile(Building building)
    {
        bool canBuild = true;

        if (buildingInstance != null)
        {
            canBuild = false;
        }

        if (Inventory.food < building.resourceData.buildingCostFood)
        {
            canBuild = false;
        }

        if (Inventory.constructionMaterials < building.resourceData.buildingCostConstruction)
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
        return new GridPosition(transform.position.x, transform.position.z);
    }

    public Building GetBuilding()
    { return buildingInstance; }

    public void SetTerrainEnergy(bool hasEnergy)
    {
        if (terrain != null)
            terrain.energy = hasEnergy;
    }
}
