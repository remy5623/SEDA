using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gied : MonoBehaviour
{
    public bool isSetB1;
    public bool isSetB2;
    public bool isSetB3;
    public GameObject[] girdArray = new GameObject[4];
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void SelectBuildingOne()
    {

        if (!isSetB1) 
        {
            isSetB1 = true;
            isSetB2 = false;
            isSetB3 = false;
            BuildingCanPlace(1, girdArray);
        }
        else if(isSetB1 )
        {
            isSetB1 = false;
            BuildingCantPlace(1, girdArray);
        }
    }

    public void SelectBuildingTwo()
    {
        if (!isSetB2)
        {
            isSetB2 = true;
            isSetB1 = false;
            isSetB3 = false;
            BuildingCanPlace(2, girdArray);
        }
        else if (isSetB2)
        {
            isSetB2 = false;
            BuildingCantPlace(2, girdArray);
        }
    }

    public void SelectBuildingThree()
    {
        if (!isSetB2)
        {
            isSetB3 = true;
            isSetB1 = false;
            isSetB2 = false;
            BuildingCanPlace(3, girdArray);
        }
        else if (isSetB2)
        {
            isSetB3 = false;
            BuildingCantPlace(3, girdArray);
        }
    }

    void BuildingCanPlace(int buildingType, GameObject[] girdArray)
    {
        for (int i = 0; i < girdArray.Length; i++)
        {
            girdArray[i].GetComponent<GirdStatus>().canBuildStatus  = true;
        }
    }
    void BuildingCantPlace(int buildingType, GameObject[] girdArray)
    {
        for (int i = 0; i < girdArray.Length; i++)
        {
            girdArray[i].GetComponent<GirdStatus>().canBuildStatus = false;
        }
    }

}
