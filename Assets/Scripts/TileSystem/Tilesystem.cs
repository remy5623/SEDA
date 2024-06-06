using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Tilesystem : MonoBehaviour
{
    [SerializeField] public TileBase Tileystem;
    public bool energy =false;
    public int radius;
    public enum SoilType
    {
        A,
        B,
        C,
        D,
        E
    }

    public enum WaterType
    {
        A,
        B,
        C,
        D,
        E
    }

    private void Start()
    {
        energy = Tileystem.baseOutputEnergy;
    }

    private void TriggerEnergy()
    {
        if (energy)
        {
            radius = Tileystem.impactRadiusTiles;
            if(radius !=0)
            {
                /*//reference to Grid
                grid[x,y].tile.bool = true;
                grid[x+1, y].tile.bool = true;
                grid[x , y+1].tile.bool = true;
                grid[x - 1, y].tile.bool = true;
                grid[x , y-1].tile.bool = true;
                grid[x + 1, y].tile.bool = true;
                grid[x + 1, y].tile.bool = true;*/
                //grid[-x , -y].tile.bool = true;
            }
        }
    }
}
