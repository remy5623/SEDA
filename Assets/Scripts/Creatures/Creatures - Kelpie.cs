using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kelpie : MonoBehaviour
{
    //Reference to Grid
    public GameObject KelpieMonsterr;

    public int Kelpie_width;
    public int Kelpie_length;

    public int bribeCostFood = 20;
    public int bribeCostConstruction = 0;

    Terrainsystem terrainsystem;


    private void Start()
    {
        //Kelpie_width = Creature.sizeWidth;
        //Kelpie_length = Creature.sizeLength;

        KelpieMonsterr.SetActive(false);

        /*if(gameObject.tag == "Kelpie")
        {
            GridObject.canBuild = false;
        }*/

        
    }

    public void KelpieCreature()
    {
        //CUE VFX FOR KELPIE-ACTIVE

        KelpieMonsterr.SetActive(true);

        /*foreach (TerrainTypes.River in TerrrainTypes)
        {
            terrainsystem.energy = false;
        }*/
    }

    public void GoawayKelpie()
    {
        if (Inventory.food >= bribeCostFood && Inventory.constructionMaterials >= bribeCostConstruction)
        {
            Destroy(KelpieMonsterr);
            //GridObject.canBuild = true;

            //CUE VFX EFFECT....AND VFX ENDS...

            /*foreach (TerrainTypes.River in TerrrainTypes)
            {
                terrainsystem.energy = true;
            }*/
        }

    }
}
