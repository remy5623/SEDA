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

    private void Update()
    {
        print("Food: " + food);
        print("Mats: " + constructionMaterials);
    }

    public static void SpendFood(int foodSpent)
    {
        food -= foodSpent;
        
        if (food < 0)
        {
            food = 0;
        }
    }

    public static void SpendMaterials(int materialSpent)
    {
        constructionMaterials -= materialSpent;

        if (constructionMaterials < 0)
        {
            constructionMaterials = 0;
        }
    }
}
