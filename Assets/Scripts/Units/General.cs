using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class General : MonoBehaviour
{
    //Base
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

    //Tile
    [Tooltip("Grab reference and information of the tile under the structure/ the tile this structure is placed on top of.")]
    public GameObject tileUnder;                                  
    public List<GameObject> biomesTypes;                          
    [Tooltip(" List of tileTerrainTypes this structure can be placed on.")]
    public List<GameObject> tileTerrainTypes;                      







}
