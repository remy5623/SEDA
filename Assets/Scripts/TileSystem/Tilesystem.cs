using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public enum TerrainTypes
{
    Grassland,
    Wetland,
    Highland,
    River,
    Barren,
    Mountain,
    Glen,
    Loch,
    Shore
}

public class Terrainsystem : MonoBehaviour
{
    

    [SerializeField] public TerrainTypes TerrainTypes;
    //if the tile has energy
    public bool energy = false;

    public GridObject Terain_gridObject;
    public GridSystemTest gridSystem;

    //the radius in which it gives off energy
    public int radius;

    //the total health of the soil (A to E grade)
    int health;

    //boolean to determine if the building can be build on that terrain
    bool build;

    //reference to Gridsystem GRID

    public SoilType soilType;
    public enum SoilType
    {
        A = 110,
        B = 105,
        C = 100,
        D = 95,
        E = 90
    }

    /*public WaterType waterType;
    public enum WaterType
    {
        A = 110,
        B = 105,
        C = 100,
        D = 95,
        E = 90
    }*/

    enum Grade
    {
        A = 110,
        B = 105,
        C = 100,
        D = 95,
        E = 90
    }


    private void Start()
    {
        //energy = TerrainTile.baseOutputEnergy;
        //radius = TerrainTile.impactRadiusTiles;
        //idPosition gridPosition = new GridPosition
        GridPosition position = gridSystem.GetGridSystem().GetGridPosition(transform.position);

        Terain_gridObject = gridSystem.GetGridSystem().GetGridObject(position);
    }

    private void TriggerEnergy()
    {
        //if the terrain has energy being emitted, then set all the terraintiles' energy bool true.
        if (energy)
        {
            for (int x = -(radius); x != radius; x++)
            {
                for (int y = -radius; y != radius; y++)
                {
                    Debug.Log(radius);
                    //Tile[x,y].energy = true;
                }
            }

        }
    }

    void TileHealth()
    {
        health = (int)soilType;

        //reference to Resource, to reduce it by (health)
        switch (health)
        {
            case int n when (n >= 105 && n <= 110):
                Debug.Log("A grade soil");

                break;
            case int n when (n >= 100 && n <= 105):
                Debug.Log("B grade soil");
                break;
            case int n when (n >= 95 && n <= 100):
                Debug.Log("C grade soil");
                break;
            case int n when (n >= 90 && n <= 95):
                Debug.Log("D grade soil");
                break;
            case int n when (n >= 85 && n <= 90):
                Debug.Log("E grade soil");
                break;
        }

    }

    /*public override void SetGridObject(GridObject gridObject)
    {
        base.SetGridObject(gridObject);
        TerrainTile.tileUnder = gridObject;
        gridObject.objectOnTile = this;
        Debug.LogWarning(TerrainTile.tileUnder);
    }*/

    private void TerrainTileObject()
    {
        //Terain_gridObject.
    }
}
