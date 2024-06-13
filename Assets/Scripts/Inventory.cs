using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;

    public static int food;
    public static int constructionMaterials;


    /** The Inventory is a singleton
     *  There is only one Inventory active at any given time
     */
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
