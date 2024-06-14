using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class BuildingTypeSelect : MonoBehaviour
{
    public GridSystem gridSystem;
    [Header("Three Button")]
    public GameObject building1Button;
    public GameObject building2Button;
    public GameObject building3Button;
    [Header("Select type debug")]
    public bool isSetB1;
    public bool isSetB2;
    public bool isSetB3;
    public GameObject array;
    public Transform[,] gridGameObjectsArray;
    void Update()
    {
        ColorChange(building1Button, building2Button, building3Button);
    }
    public void ColorChange(GameObject button1, GameObject button2,GameObject button3)
    {
        if(isSetB1)
        {
            button1.GetComponent<Image>().color = Color.red;
        }
        else 
        {
            button1.GetComponent<Image>().color = Color.white;
        }
        if(isSetB2)
        {
            button2.GetComponent<Image>().color = Color.red;
        }
        else
        {
            button2.GetComponent<Image>().color = Color.white;
        }
        if (isSetB3)
        {
            button3.GetComponent<Image>().color = Color.red;
        }
        else
        {
            button3.GetComponent<Image>().color = Color.white;
        }
    }

    public void SelectBuildingOne(Building buildingPrefab)
    {
        if (!isSetB1)
        {
            isSetB1 = true;
            isSetB2 = false;
            isSetB3 = false;
            gridSystem.ToggleBuildMode(buildingPrefab, true);
        }
        else if(isSetB1 )
        {
            gridSystem.ToggleBuildMode(buildingPrefab, false);
            isSetB1 = false;
            //BuildingCantPlace(1, gridSystem.GetGridGameObjectsArray());
        }
    }

    public void SelectBuildingTwo(Building buildingPrefab)
    {
        if (!isSetB2 )
        {
            isSetB2 = true;
            isSetB1 = false;
            isSetB3 = false;
            gridSystem.ToggleBuildMode(buildingPrefab, true);
        }
        else if (isSetB2 )
        {
            gridSystem.ToggleBuildMode(buildingPrefab, false);

            isSetB2 = false;
        }
    }

    public void SelectBuildingThree(Building buildingPrefab)
    {
        if (!isSetB3)
        {
            isSetB3 = true;
            isSetB1 = false;
            isSetB2 = false;
            gridSystem.ToggleBuildMode(buildingPrefab, true);
        }
        else if (isSetB3)
        {
            gridSystem.ToggleBuildMode(buildingPrefab, false);

            isSetB3 = false;
            //BuildingCantPlace(3, gridSystem.GetGridGameObjectsArray());
        }
    }

    void BuildingCanPlace(int buildingType, GirdStatus[,] girdArray)
    {
        foreach (GirdStatus element in girdArray )
        {
            element.gameObject.GetComponent<GirdStatus>().Buildmode = true;
        }
    }
    void BuildingCantPlace(int buildingType, GirdStatus[,] girdArray)
    {
        foreach (GirdStatus element in girdArray)
        {
            element.gameObject.GetComponent<GirdStatus>().Buildmode = false;
        }
    }

}
