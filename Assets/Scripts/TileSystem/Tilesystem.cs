using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Tilesystem : MonoBehaviour
{
    [SerializeField] public TileBase Tileystem;
    public bool energy =false;
    public int radius;
    float health;
    bool build;

    public SoilType soilType;
    public enum SoilType
    {
        A = 110,
        B = 105,
        C = 100,
        D = 95,
        E = 90
    }

    public WaterType waterType;
    public enum WaterType
    {
        A = 110,
        B = 105,
        C = 100,
        D = 95,
        E = 90
    }

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
        energy = Tileystem.baseOutputEnergy;
        build = Tileystem.canBuild;
        
    }

    private void TriggerEnergy()
    {
        if (energy)
        {
            radius = Tileystem.impactRadiusTiles;
            if(radius !=0)
            {
                /*//reference to Grid USING FOR LOOP.
                grid[x , y+1].tile.bool = true;
                grid[x,y].tile.bool = true;
                grid[x , y-1].tile.bool = true;
                grid[x+1, y-1].tile.bool = true;
                grid[x+1, y].tile.bool = true;
                grid[x+1, y+1].tile.bool = true;
                grid[x-1, y+1].tile.bool = true;
                grid[x-1, y].tile.bool = true;
                grid[x-1, y-1].tile.bool = true;*/

            }
        }
    }

    void TileHealth()
    {
        health = (((int)waterType) + ((int)soilType)) - 100;

        //reference to Resource, to reduce it by (health)


        
    }
}
