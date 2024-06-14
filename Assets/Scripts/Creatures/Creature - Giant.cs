using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giant : MonoBehaviour
{
    //Grid Reference

    public GameObject GiantMonsterr;

    public int Giant_width;
    public int Giant_length;

    public int bribeCostFood = 15;
    public int bribeCostConstruction = 5;

    private void Start()
    {
        //Giant_width = Creature.sizeWidth;
        //Giant_length = Creature.sizeLength;
        GiantMonsterr.SetActive(true);
    }

    void GiantCreature()
    {
        /*if(gameObject.tag == "Giant")
        {
            GridObject.canBuild = false;
        }*/
    }

    public void GoawayGiant()
    {
        if( Inventory.food >= bribeCostFood && Inventory.constructionMaterials >= bribeCostConstruction)
        {
            Destroy(GiantMonsterr);
            //GridObject.canBuild = true;

            //Cue VFX effect..
        }
    }
}
