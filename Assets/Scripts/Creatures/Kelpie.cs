using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kelpie : MonoBehaviour
{
    public TileBase Creature;

    public Grid grid;

    //public ResurceSystem;
    //public TileSystem;

    public int Kelpie_width;
    public int Kelpie_length;
    
    //REFERENCE FOR RIVERBED


    private void Start()
    {
        Kelpie_width = Creature.sizeWidth;
        Kelpie_length = Creature.sizeLength;
    }
    void KulpieCreature()
    {
        /*for (int i = 0; i < grid.width; i++)
        {
            for (int y = 0; y < grid.length; y++)
            {
               if(Creature.tileName = "Water")
                {
                    RIVERBED.allTiles.boolean = false;
                }
            }
        }*/
    }

    void GoawayKelpie()
    {
       /* if (ResourceSystem.energy > 60 && ResourceSystem.food > 70 && ResourceSystem.constructionMat > 100)
        {
            ResourceSystem.energy -= 60;
            ResourceSystem.energy -= 70;
            ResourceSystem.constructionMat -= 100;
        }*/
    }
}
