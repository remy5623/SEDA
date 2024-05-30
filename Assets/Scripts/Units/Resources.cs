using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    //Base
    [Tooltip("checks if the resource will be added to the monthly output (some structures need to be tapped to receive the base output")]
    public bool isResourceTapped;                   
    //Output
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

    //Cost
    [Tooltip("Monthly upkeep cost of sustaining building-Energy?")]
    public int upKeepCostEnergy;                      
    [Tooltip("Monthly upkeep cost of sustaining building-Food")]
    public int upKeepCostFood;                       
    [Tooltip("Monthly upkeep cost of sustaining building-Construction")]
    public int upKeepCostConstruction;                

    //Impact
    [Tooltip("Number of tiles in each direction that this building can Impact. (all 8 directions from centre).")]
    public int impactRadiusTiles;                
    [Tooltip("Transfers the output Resource and applies it to the output of the ?")]
    public int transferResources;                    
    [Tooltip("the object will be impacted.")]
    public GameObject effectiveGameObjects;        
}
