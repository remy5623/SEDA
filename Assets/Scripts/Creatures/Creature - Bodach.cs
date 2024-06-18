using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodach : MonoBehaviour
{
    //REFERENCE OF GRID
    //REFERENCE OF WEATHERSYSTEM
      
    public int Bodach_width;
    public int Bodach_length;

    public GameObject CailleachMonsterr;

    public int bribeCostFood = 0;
    public int bribeCostConstruction = 20;

    private void Start()
    {
        CailleachMonsterr.SetActive(false);

        //Bodach_width = Creature.sizeWidth;
        //Bodach_length = Creature.sizeLength;

    }

    void BodachCreature()
    {
        //CUE VFX FOR CAILLEACH-ACTIVE

        CailleachMonsterr.SetActive(true);

        //WEATHER CHANGE...
    }

    void GoawayBodach()
    {
        if (Inventory.food >= bribeCostFood && Inventory.constructionMaterials >= bribeCostConstruction)
        {
            Destroy(CailleachMonsterr);
            Debug.Log("Weather change and things happen..");
            //CUE VFX EFFECT....AND VFX ENDS...
            //WEATHER CHANGE...

            
        }
    }
}
