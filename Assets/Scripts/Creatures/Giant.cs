using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giant : MonoBehaviour
{
    public TileBase Creature;
    //REFERENCE FOR GRID
    //REFERENCE FOR RIVERBED

    //public GIANT.WIDTH;
    //public GIANT.LENGTH;

    private void Start()
    {
        //GIANT.WIDTH = Creature.width;
        //GIANT.LENGTH = Creature.length;


        if (Creature.hasTileImpact)
        {
            //GRID.LENGTH += CREATURE.IMPACTRADIUSTILE
            //GRID.WIDTH += CREATURE.IMPACTRADIUSTILE
        }
    }

    void GiantCreature()
    {
        /*for (int i = 0; i < GRID.WIDTH; i++)
        {
            for (int y = 0; y < GRID.LENGTH; y++)
            {
               if(Creature.tileName = "Giant")
                {
                    RADIUS = cREATURE.GRIDIIII[,] = Grid[i, y];
                }
            }
        }

        for (int u = 0; u < Grid.i; u++)
        {
            for (int t = 0; t < Grid.y; t++)
            {
                GRIDIIII.BOOL = false;
            }
        }*/

    }

    void GoawayGiant()
    {

    }
}
