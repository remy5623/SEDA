using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giant : MonoBehaviour
{
    public TileBase Creature;
    public Grid grid;

    //public ResurceSystem;
    //public TileSystem;

    public int Giant_width;
    public int Giant_length;

    //REFERENCE FOR RIVERBED

    private void Start()
    {
        Giant_width = Creature.sizeWidth;
        Giant_length = Creature.sizeLength;

       
    }

    void GiantCreature()
    {
        /*for (int i = 0; i < grid.width; i++)
        {
            for (int y = 0; y < grid.length; y++)
            {
                if (Creature.tileName = "Giant")
                {
                    grid.boolean = false;
                }
            }
        }*/
    }

    void GoawayGiant()
    {

    }
}
