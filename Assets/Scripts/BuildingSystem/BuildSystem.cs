using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildSystem : MonoBehaviour
{
    public GameObject BuildingType1;
    public GameObject BuildingType2;
    public GameObject BuildingType3;

    [SerializeField]
    InputActionAsset actionAsset;

    InputAction placeAction;
    InputAction tapLocation;

    public GridSystemTest grid;

    private void Start()
    {
        placeAction = actionAsset.FindAction("PossessCamera");
        placeAction.performed += ctx => PlaceBuilding();

        tapLocation = actionAsset.FindAction("PanCamera");
    }


    void PlaceBuilding()
    {
        Ray ray = Camera.main.ScreenPointToRay(tapLocation.ReadValue<UnityEngine.Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Grid" && GameObject.Find("Canvas").GetComponent<BuildingTypeSelect>().isSetB1)
        {

            //Debug.Log(Inventory.food);
            if (hit.collider.gameObject.GetComponent<GirdStatus>().canBuild && Inventory.food >= BuildingCost.build1CostFood && Inventory.constructionMaterials >= BuildingCost.build1CostMaterials)
            {
                GameObject building1 = Instantiate(BuildingType1, hit.collider.gameObject.transform);
                building1.transform.localPosition = new UnityEngine.Vector3(0, 0, 0);
                AssignGridObject(building1.GetComponent<PlaceableObject>());
                Inventory.food -= BuildingCost.build1CostFood;
                Inventory.constructionMaterials -= BuildingCost.build1CostMaterials;
                hit.collider.gameObject.GetComponent<GirdStatus>().canBuild = false;
            }
        }

        else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Grid" && GameObject.Find("Canvas").GetComponent<BuildingTypeSelect>().isSetB2)
        {
            if (hit.collider.gameObject.GetComponent<GirdStatus>().canBuild && Inventory.food >= BuildingCost.build2CostFood && Inventory.constructionMaterials >= BuildingCost.build2CostMaterials)
            {
                GameObject building2 = Instantiate(BuildingType2, hit.collider.gameObject.transform);
                building2.transform.localPosition = new UnityEngine.Vector3(0, 0, 0);
                AssignGridObject(building2.GetComponent<PlaceableObject>());
                Inventory.food -= BuildingCost.build2CostFood;
                Inventory.constructionMaterials -= BuildingCost.build2CostMaterials;
                hit.collider.gameObject.GetComponent<GirdStatus>().canBuild = false;
            }
        }

        else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Grid" && GameObject.Find("Canvas").GetComponent<BuildingTypeSelect>().isSetB3)
        {
            if (hit.collider.gameObject.GetComponent<GirdStatus>().canBuild && Inventory.food >= BuildingCost.build3CostFood && Inventory.constructionMaterials >= BuildingCost.build3CostMaterials)
            {
                GameObject building3 = Instantiate(BuildingType3, hit.collider.gameObject.transform);
                building3.transform.localPosition = new UnityEngine.Vector3(0, 0, 0);
                AssignGridObject(building3.GetComponent<PlaceableObject>());
                Inventory.food -= BuildingCost.build3CostFood;
                Inventory.constructionMaterials -= BuildingCost.build3CostMaterials;
                hit.collider.gameObject.GetComponent<GirdStatus>().canBuild = false;
            }
        }
    }

    void AssignGridObject(PlaceableObject builtObject)
    {
        if (builtObject)
        {
            builtObject.SetGridObject(grid.GetGridSystem().GetGridObject(grid.GetGridSystem().GetGridPosition(builtObject.transform.position)));
        }
    }

}
