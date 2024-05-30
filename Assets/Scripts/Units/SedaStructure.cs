using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="General",menuName ="SEDA_Asset/General")]
public class GeneralStructure : ScriptableObject
{
    [Header("General")]
    //GeneralBase
    [Tooltip("(currently unused) Will be used if we swap to a database structure rather than manual creation.")]
    public int unitsID;                                          
    [Tooltip("Name of the object that will be displayed in-game e.g. on hover over via UI.")]
    public string unitsName;                                       
    [Tooltip("Image (drag and drop to here) (Resolution of Images in UI Spec Sheet")]
    public Sprite unitsIcon;                                       
    [Tooltip("GameObject with 3D static Mesh (Drag and Drop) (Scale See Metrics & Scale(See Grid scale)")]
    public GameObject unitsMesh;                                  
    public Vector3 buildSize;                                     
    [Tooltip("Structure Types")]
    public UnitsTypes unitsTypes;                                 

    public enum UnitsTypes
    {
        Creature,
        Building,
        Resource,
        Farm,
        Restoration
    }

    //GeneralTile
    [Tooltip("Grab reference and information of the tile under the structure/ the tile this structure is placed on top of.")]
    public GameObject tileUnder;                                  
    public List<GameObject> biomesTypes;                          
    [Tooltip(" List of tileTerrainTypes this structure can be placed on.")]
    public List<GameObject> tileTerrainTypes;   
    [Header("Build")]
    //BuildBase
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

    //BuildingUpgradeCost
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
    [Header("Resource")]
    //ResourceBase
    [Tooltip("checks if the resource will be added to the monthly output (some structures need to be tapped to receive the base output")]
    public bool isResourceTapped;                   
    //ResourceOutput
    [Tooltip("BaseOutput-Energy")]
    public int baseOutputEnergy;                     
    [Tooltip("BaseOutput-Food")]
    public int baseOutputFood;                        
    [Tooltip("BaseOutput-Construction")]
    public int baseOutputConstruction;                
    [Tooltip("Multiplier of resources when receiving transfererResources (%)")]
    public float buildingOutputMulti;            
    [Tooltip("Multiplier to output resource per level (%)")]
    public float buildingLevelMulti;
    [Tooltip("What stage of production is this structure (1- earliest to 3 latest) Cannot transfer to lower stages.")]
    public int buildingOutputStage;              
    [Tooltip("Full output of resources after the full calculation is done.")]
    public int buildingCalcOutput;                  

    //ResourceCost
    [Tooltip("Monthly upkeep cost of sustaining building-Energy?")]
    public int upKeepCostEnergy;                      
    [Tooltip("Monthly upkeep cost of sustaining building-Food")]
    public int upKeepCostFood;                       
    [Tooltip("Monthly upkeep cost of sustaining building-Construction")]
    public int upKeepCostConstruction;                

    //ResourceImpact
    [Tooltip("Number of tiles in each direction that this building can Impact. (all 8 directions from centre).")]
    public int impactRadiusTiles;                
    [Tooltip("Transfers the output Resource and applies it to the output of the ?")]
    public int transferResources;                    
    [Tooltip("the object will be impacted.")]
    public GameObject effectiveGameObjects;
    [Header("Impact")]
    //Impact
    [Tooltip("Is this a source of Buffs or nerfs for other structures?")]
    public bool impactSource;
    [Tooltip("multiplier to output from the buff Source")]                                                                                                                                       
    public float buffAmount;                                            
    [Tooltip("multiplier to output from the nerf Source")]                                               
    public float nerfAmount;                                          
    [Tooltip("list of objects this applies the buff to if insideImpactRadius")]
    public List<GameObject> tileImpactBuff;                            
    [Tooltip("list of objects this applies the nerf to if insideImpactRadius")]
    public List<GameObject> tileImapctNerf;    
}
