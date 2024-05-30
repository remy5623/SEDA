using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSection : MonoBehaviour
{
    //Build
    [Tooltip("Checks if a tile is buildable, if not it hides the Building section inengine and in the hierarchy.")]
    public bool canBuild;                   
    [Tooltip("Number of Days this structure takes to build (See time(1day=1sec)")]                                
    public int buildTime;                  

    //BuildCost
    [Tooltip("Building cost of constructing the building.-Energy")]
    public int costEnergy;                  
    [Tooltip("Building cost of constructing the building.-Food")]
    public int costFood;                   
    [Tooltip("Building cost of constructing the building.-Construction")]
    public int costConstruction;            

    //UpgradeCost
    [Tooltip("Building Upgrade cost-Energy")]
    public int buildUpgradeCostEnergy;      
    [Tooltip("Building Upgrade cost-Food")]
    public int buildUpgradeCostFood;       
    [Tooltip("Building Upgrade cost-Construction")]
    public int buildUpgradeCostConstruction;
    [Tooltip("Increases the upgrade cost per level ")]
    public float buildUpgradeCostMult; 

    //BuildingsLevel
    [Tooltip("Building upgrade icon per level(could be static and hidden or a fixed.")]
    public List<Sprite> buildingLevelIcon;
    [Tooltip("current level of the building")]
    public int currentLevel;              
    [Tooltip("Maximum number of upgrades for building")]
    public int MAX_LEVEL;                  
}
