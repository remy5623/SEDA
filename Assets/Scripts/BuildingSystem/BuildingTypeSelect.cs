using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingTypeSelect : MonoBehaviour
{
    private GridSystem gridSystem;
    public bool isSetB1;
    public bool isSetB2;
    public bool isSetB3;
    public GameObject array;
    public void Start()
    {   
        gridSystem = array.GetComponent<GridSystemTest>().GetGridSystem();
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
            BuildingCanPlace(1, gridSystem.GetGrids());
        }
        else if(isSetB1 )
        {
            isSetB1 = false;
            BuildingCantPlace(1, gridSystem.GetGrids());
        }
    }

    public void SelectBuildingTwo()
    {
        if (!isSetB2)
        {
            isSetB2 = true;
            isSetB1 = false;
            isSetB3 = false;
            BuildingCanPlace(2, gridSystem.GetGrids());
        }
        else if (isSetB2)
        {
            isSetB2 = false;
            BuildingCantPlace(2, gridSystem.GetGrids());
        }
    }

    public void SelectBuildingThree()
    {
        if (!isSetB2)
        {
            isSetB3 = true;
            isSetB1 = false;
            isSetB2 = false;
            BuildingCanPlace(3, gridSystem.GetGrids());
        }
        else if (isSetB2)
        {
            isSetB3 = false;
            BuildingCantPlace(3, gridSystem.GetGrids());
        }
    }

    void BuildingCanPlace(int buildingType, GridObject[,] girdArray)
    {
        foreach (GridObject element in girdArray)
        {
            element.gameObject.transform.Find("Quad").gameObject.GetComponent<GirdStatus>().canBuild = true;
        }
    }
    void BuildingCantPlace(int buildingType, GridObject[,] girdArray)
    {
        foreach (GridObject element in girdArray)
        {
            element.gameObject.transform.Find("Quad").gameObject.GetComponent<GirdStatus>().canBuild = false;
        }
    }

}
