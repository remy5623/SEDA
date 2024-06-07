using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TerrainBase", menuName = "TerrainBase")]
public class TerrainBase : ScriptableObject
{
    public TerrainTypes terrainTypes;
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




}
