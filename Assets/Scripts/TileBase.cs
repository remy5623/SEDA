using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TileBase",menuName ="TileBase")]
public class TileBase : ScriptableObject
{
    //GeneralBase
    [Header("General")]
    [Tooltip("(currently unused) Will be used if we swap to a database structure rather than manual creation.")]
    public int iD;                                          
    [Tooltip("Name of the object that will be displayed in-game e.g. on hover over via UI.")]
    public string tileName;                                       
    [Tooltip("Image (drag and drop to here) (Resolution of Images in UI Spec Sheet")]
    public Sprite icon;                                       
    [Tooltip("GameObject with 3D static Mesh (Drag and Drop) (Scale See Metrics & Scale (See Grid scale)")]
    public GameObject mesh;    
    [Tooltip("Number of Tiles on grid Width")]                              
    public int sizeWidth;     
    [Tooltip("Number of Tiles on grid Length")]
    public int sizeLength;                                
    [Tooltip("Structure Types")]
    public StructureTypes structureType;                                 
    public enum StructureTypes
    {
        LoggingCamp,
        Forest,
        Mine,
        Rock
    }
    [Tooltip("Grab reference and information of the tile under the structure/ the tile this structure is placed on top of.")]
    public GridObject tileUnder; 
    [Tooltip("List of biomesTypes(levels) this structure can be build within.")]                                 
    public List<BiomeType> biomesTypes;
    public enum BiomeType
    {
        Marsh,
        Forest,
        Island,
        Highland
    }

    [Tooltip("List of tileTerrainTypes this structure can be placed on.")]
    public List<TileTerrainTypes> tileTerrainTypes;
    public enum TileTerrainTypes
    {
        Grassland,
        Wetland,
        Highland,
        River,
        Barrens,
        Mountain,
        Water
    }

    
    //BuildBase
    [Header("BuildBase")]
    [Tooltip("Checks if a tile is buildable, if not it hides the Building section inengine and in the hierarchy.")]
    public bool canBuild;
    [Tooltip("Number of Days this structure takes to build (See time(1day=1sec)")]                                
    public int buildTime;  

    [Header("BuildCost")]
    [Tooltip("Building cost of constructing the building.-Energy")]
    public int buildingCostEnergy;  
    [Tooltip("Building cost of constructing the building.-Food")]
    public int buildingCostFood; 
    [Tooltip("Building cost of constructing the building.-Construction")]
    public int buildingCostConstruction;

    [Tooltip("Building Upgrade cost-Energy")]
    public int buildingUpgradeCostEnergy; 
    [Tooltip("Building Upgrade cost-Food")]
    public int buildingUpgradeCostFood;  
    [Tooltip("Building Upgrade cost-Construction")]
    public int buildingUpgradeCostConstruction;
    [Tooltip("Increases the upgrade cost per level ")]
    public float buildingUpgradeCostMulti; 
    [Header("BuildLevel")]
    [Tooltip("Building upgrade icon per level(could be static and hidden or a fixed.")]
    public List<Sprite> buildingLevelIcon;
    [Tooltip("current level of the building")]
    public int buildingCurrentlevel; 
    [Tooltip("Maximum number of upgrades for building")]
    public int buildingLevelMax;



    [Header("ResourceBase")]
    [Tooltip("checks if hasResourceOutput, else it hides in edit/inspector.")]
    public bool hasResourceOutput;
    //ResourceBase
    [Tooltip("checks if the resource will be added to the monthly output (some structures need to be tapped to receive the base output")]
    public bool isResourceTapped;                   
    //ResourceOutput
    [Tooltip("BaseOutput-Energy")]
    public bool baseOutputEnergy;                     
    [Tooltip("BaseOutput-Food")]
    public int baseOutputFood;                        
    [Tooltip("BaseOutput-Construction")]
    public int baseOutputConstruction;                
    [Tooltip("Multiplier of resources when receiving transferred resources (%)")]
    public float buildingOutputMulti;            
    [Tooltip("Multiplier to output resource per level (%)")]
    public float buildingLevelMulti;
    [Tooltip("What stage of production is this structure (1- earliest to 3 latest) Cannot transfer to lower stages.")]
    public int buildingOutputStage;              
    //[Tooltip("Full output of resources after the full calculation is done.")]
    //public int buildingCalcOutput;

    [Header("ResourceCost")]
    [Tooltip("Monthly upkeep cost of sustaining building-Energy?")]
    public bool upKeepCostEnergy;                      
    [Tooltip("Monthly upkeep cost of sustaining building-Food")]
    public int upKeepCostFood;                       
    [Tooltip("Monthly upkeep cost of sustaining building-Construction")]
    public int upKeepCostConstruction;                

    [Header("ResourceImpact")]
     [Tooltip("Check if it is a Resource")]
    public bool hasTileImpact;
    [Tooltip("Number of tiles in each direction that this building can Impact. (all 8 directions from centre).")]
    public int impactRadiusTiles;                
    [Tooltip("Transfers the output food and applies it to the output of the structures in radius.")]
    public int transferFood;
    [Tooltip("Transfers the output Construction Materials and applies them to the output of structures in radius.")]
    public int transferConstruction;
    [Tooltip("the object will be impacted.")]
    public GameObject structureOfTypeInRadius;
    [Tooltip("Is this a source of Buffs or nerfs for other structures?")]
    public bool impactSource;
    [Tooltip("multiplier to output from the buff Source")]                                                                                                                                       
    public float buffAmount;                                            
    [Tooltip("multiplier to output from the nerf Source")]                                               
    public float nerfAmount;                                          
    [Tooltip("list of objects this applies the buff to if insideImpactRadius")]
    public List<TileBase> tileImpactBuff;                            
    [Tooltip("list of objects this applies the nerf to if insideImpactRadius")]
    public List<TileBase> tileImpactNerf;
}
