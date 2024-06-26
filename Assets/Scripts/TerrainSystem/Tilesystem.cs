using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TerrainTypes
{
    None,
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

public enum CreatureTypes
{
    None,
    Giant,
    Kelpie,
    Cailleach
}

public class Terrainsystem : MonoBehaviour
{
    public SoilType soilType;
    public enum SoilType
    {
        A = 100,
        B = 80,
        C = 60,
        D = 40,
        E = 20
    }

    public List<SoilType> allowedSoilGrade;

    

    public bool ResourceAffect;

    [SerializeField] public TerrainTypes terraintype;
    [SerializeField] public CreatureTypes creaturetype;


    //if the tile has energy
    public bool energy = false;

    public GridObject owningGridObject;

    //the radius in which it gives off energy
    public int radius;

    //the total health of the soil (A to E grade)
    int health;

    //Creatures
    /*public GameObject GiantMonsterr;
    public GameObject KelpieMonsterr;
    public GameObject CailleachMonsterr;*/

    public int GiantbribeCostFood = 15;
    public int GiantbribeCostConstruction = 5;

    public int KelpiebribeCostFood = 20;
    public int KelpiebribeCostConstruction = 0;

    public int CailleachbribeCostFood = 0;
    public int CailleachbribeCostConstruction = 20;

    private void Start()
    {

        if (ResourceAffect)
        {
            TimeSystem.AddMonthlyEvent(HealthBar);
            //TimeSystem.AddMonthlyEvent(ChangeinGrade);

        }

        InitialTerrainList();
        health = (int)soilType;
        SetTerrainMaterialProperties();

        StartCoroutine(Stupidity());
       // ChangeinGrade();
    }

    private void TriggerEnergy()
    {
        //if the terrain has energy being emitted, then set all the terraintiles' energy bool true.
        if (energy)
        {
            GridPosition pos = owningGridObject.GetGridPosition();

            for (int x = pos.x - radius; x <= pos.x + radius; x++)
            {
                for (int z = pos.z - radius; z <= pos.z + radius; z++)
                {
                    GridObject Energyobj = owningGridObject.GetOwningGridSystem().GetGridObject(x, z);
                    if (Energyobj != null)
                    {
                        Energyobj.SetTerrainEnergy(true);
                    }
                }
            }
        }
    }

    IEnumerator Stupidity()
    {
        yield return new WaitForSeconds(10);
        TriggerEnergy();
        //ChangeinGrade();
        //HealthBar();
    }

    void HealthBar()
    {
        Inventory.count++;
        Inventory.totalhealth += (int)soilType;
        Inventory.HealthBarChange();
    }

    void InitialTerrainList()
    {
        switch (terraintype)
        {
            case TerrainTypes.Grassland:
                {
                    allowedSoilGrade.Add(SoilType.A);
                    allowedSoilGrade.Add(SoilType.B);
                    allowedSoilGrade.Add(SoilType.C);
                    break;
                }
            case TerrainTypes.Highland:
                {
                    allowedSoilGrade.Add(SoilType.A);
                    allowedSoilGrade.Add(SoilType.B);
                    allowedSoilGrade.Add(SoilType.C);
                    break;
                }
            case TerrainTypes.Wetland:
                {
                    allowedSoilGrade.Add(SoilType.D);
                    allowedSoilGrade.Add(SoilType.E);
                    break;
                }
            case TerrainTypes.River:
                {
                    allowedSoilGrade.Add(SoilType.B);
                    allowedSoilGrade.Add(SoilType.C);
                    allowedSoilGrade.Add(SoilType.D);
                    break;
                }
            case TerrainTypes.Barren:
                {
                    allowedSoilGrade.Add(SoilType.E);
                    break;
                }
            case TerrainTypes.Mountain:
                {
                    allowedSoilGrade.Add(SoilType.C);
                    allowedSoilGrade.Add(SoilType.D);
                    break;
                }
        }
    }

    public void ChangeinGrade(float buffamount, float nerfamount, bool impact)
    {
        float totalChangeInGrade = buffamount - nerfamount;
        if (impact)
    {
            health = (int)soilType + (int)totalChangeInGrade;
            SetTerrainMaterialProperties();

            //reference to Building, to reduce it by (health)
           switch (health)
            {
                case int n when (n >= 81 && n <= 100):
                    if (IsSoilGradeAllowed(soilType))
                        break;
                    break;

                case int n when (n >= 61 && n <= 80):
                    if (IsSoilGradeAllowed(soilType))
                        break;
                    break;

                case int n when (n >= 41 && n <= 60):
                    if (IsSoilGradeAllowed(soilType))
                        break;
                    break;

                case int n when (n >= 20 && n <= 40):
                    if (IsSoilGradeAllowed(soilType))
                        break;
                    break;
                    

                case int n when (n >= 0 && n <= 20):
                     if (IsSoilGradeAllowed(soilType))
                        break;
                    break;

                
            }
        }

    }

    void SetTerrainMaterialProperties()
    {
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();

        if (renderer == null)
            return;

        Material[] materialsArray = GetComponent<MeshRenderer>().materials;

        float quality = health / 100f;

        foreach (Material mat in materialsArray)
        {
            mat.SetFloat("_SoilQuality", quality);
        }
    }

   bool IsSoilGradeAllowed(SoilType soilTypepassed)
    {
        int i=0;
        foreach (SoilType soil in allowedSoilGrade)
        {
            if(soilType == allowedSoilGrade[i])
            {
                return true;
            }
        }
        return false;
    }

    public void Creaturegone(TileBase creatureDef)
    {
        foreach (Terrainsystem giantTile in FindObjectsByType<Terrainsystem>(FindObjectsSortMode.None))
        {
            if (giantTile.creaturetype.ToString() == creatureDef.structureType.ToString())
            {
                GridPosition pos = giantTile.owningGridObject.GetGridPosition();
                GridObject CreatureObj = giantTile.owningGridObject.GetOwningGridSystem().GetGridObject(pos.x, pos.z);
                if (Inventory.food >= GiantbribeCostFood && Inventory.constructionMaterials >= GiantbribeCostConstruction)
                {
                    CreatureObj.SetCreatureGone();

                    //Cue VFX effect..
                }
            }
        }
    }

    /*public void Impact()
    {
        GridPosition pos = GetOwningGridObject().GetGridPosition();
        int radius = resourceData.impactRadiusTiles;

        for (int x = pos.x - radius; x < pos.x + radius; x++)
        {
            for (int z = pos.z - radius; z < pos.z + radius; z++)
            {
                if (x >= 0 && z >= 0 && x < GetOwningGridObject().GetOwningGridSystem().GetGridLength() && z < GetOwningGridObject().GetOwningGridSystem().GetGridWidth())
                {
                    // TODO: Filter by structure type
                    Building objectInRadius;
                    if ((objectInRadius = GetOwningGridObject().GetOwningGridSystem().GetGridObject(x, z).GetBuilding()) && (new GridPosition(x, z) != pos))
                    {
                        SetBuffs(objectInRadius);
                    }
                }

            }*/
}

/*void TileHealth()
{
    health = (int)soilType;

    //reference to Building, to reduce it by (health)
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

}*/

/*public override void SetGridObject(GridObject gridObject)
{
    base.SetGridObject(gridObject);
    TerrainTile.tileUnder = gridObject;
    gridObject.objectOnTile = this;
    Debug.LogWarning(TerrainTile.tileUnder);
}*/

/*private void TerrainTileObject()
{
    //Terain_gridObject.
}*/

