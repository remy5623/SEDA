using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodach : MonoBehaviour
{
    public TileBase Creature;
    public Grid grid;
    
    //public ResurceSystem;
    //public TileSystem;

    public int Bodach_width;
    public int Bodach_length;

    private void Start()
    {
        Bodach_width = Creature.sizeWidth;
        Bodach_length = Creature.sizeLength;
    }

    void BodachCreature()
    {
       /*for (int i = 0; i< TileSystem.width; i++)
        {
            for(int j = 0; j < TileSystem.length; j++)
            {
                ResourceSystem.construction -= ResourceSystem.construction * 0.7;
                ResourceSystem.energy -= ResourceSystem.energy * 0.7;
                ResourceSystem.harvesting -= ResourceSystem.harvesting * 0.7;

            }
        }*/    
    }

    void GoawayBodach()
    {
       /* 
        if(ResourceSystem.energy > 60 && ResourceSystem.food > 70 && ResourceSystem.constructionMat > 100)
        {
            ResourceSystem.energy -= 60;
            ResourceSystem.energy -= 70;
            ResourceSystem.constructionMat -= 100;
        }*/
    }
}
