using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class BuildingTypeSelect : MonoBehaviour
{
    BuildSystem buildSystem;
    public GridSystem gridSystem;
    [Header("Three Button")]
    public GameObject building1Button;
    public GameObject building2Button;
    public GameObject building3Button;
    [Header("Select type debug")]
    public bool isSetB1;
    public bool isSetB2;
    public bool isSetB3;

    private void Start()
    {
        buildSystem = transform.parent.transform.parent.gameObject.GetComponentInChildren<BuildSystem>();
    }

    Transform[,] gridGameObjectsArray;
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

    public void SelectBuildingOne()
    {
        if (!isSetB1)
        {
            isSetB1 = true;
            isSetB2 = false;
            isSetB3 = false;

            gridSystem.ToggleBuildMode(buildSystem.BuildingType1, true);

        }
        else if(isSetB1 )
        {
            gridSystem.ToggleBuildMode(buildSystem.BuildingType1, false);
            isSetB1 = false;

        }
    }

    public void SelectBuildingTwo()
    {
        if (!isSetB2 )
        {
            isSetB2 = true;
            isSetB1 = false;
            isSetB3 = false;

            gridSystem.ToggleBuildMode(buildSystem.BuildingType2, true);

        }
        else if (isSetB2 )
        {
            gridSystem.ToggleBuildMode(buildSystem.BuildingType2, false);

            isSetB2 = false;
            
        }
    }

    public void SelectBuildingThree()
    {
        if (!isSetB3)
        {
            isSetB3 = true;
            isSetB1 = false;
            isSetB2 = false;

            gridSystem.ToggleBuildMode(buildSystem.BuildingType3, true);

        }
        else if (isSetB3)
        {
            gridSystem.ToggleBuildMode(buildSystem.BuildingType3, false);

            isSetB3 = false;
            
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
