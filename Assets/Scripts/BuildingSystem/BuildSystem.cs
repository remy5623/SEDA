using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildSystem : MonoBehaviour
{
    public GameObject ab;
    public GameObject aa;
    public GameObject bb;

    public GridSystemTest grid;

    private void Start()
    {
      
    }
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {      
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)&&hit.collider.gameObject.tag == "Gird"&& GameObject.Find("Canvas").GetComponent<BuildingTypeSelect>().isSetB1)
            {
                //Debug.Log(Inventory.food);
                if (hit.collider.gameObject.GetComponent<GirdStatus>().canBuild&& Inventory.food >= BuildingCost.build1CostFood && Inventory.constructionMaterials >= BuildingCost.build1CostMaterials)
                {
                    Debug.Log(11);
                    GameObject build1 = Instantiate(ab, hit.collider.gameObject.transform);
                    build1.transform.localPosition = new UnityEngine.Vector3(0, 0, 0);
                    AssignGridObject(build1.GetComponent<PlaceableObject>());
                    Inventory.food -= BuildingCost.build1CostFood;
                    Inventory.constructionMaterials -= BuildingCost.build1CostMaterials;
                    hit.collider.gameObject.GetComponent<GirdStatus>().canBuild = false;
                }
            }
           else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Gird" && GameObject.Find("Canvas").GetComponent<BuildingTypeSelect>().isSetB2)
            {
                if (hit.collider.gameObject.GetComponent<GirdStatus>().canBuild&& Inventory.food >= BuildingCost.build2CostFood && Inventory.constructionMaterials >= BuildingCost.build2CostMaterials)
                {
                    Debug.Log(21);
                    GameObject build2 = Instantiate(aa, hit.collider.gameObject.transform);
                    build2.transform.localPosition = new UnityEngine.Vector3(0, 0, 0);
                    AssignGridObject(build2.GetComponent<PlaceableObject>());
                    Inventory.food -= BuildingCost.build2CostFood;
                    Inventory.constructionMaterials -= BuildingCost.build2CostMaterials;
                    hit.collider.gameObject.GetComponent<GirdStatus>().canBuild = false;
                }
            }
           else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Gird" && GameObject.Find("Canvas").GetComponent<BuildingTypeSelect>().isSetB3)
            {
                if (hit.collider.gameObject.GetComponent<GirdStatus>().canBuild&& Inventory.food >= BuildingCost.build3CostFood && Inventory.constructionMaterials >= BuildingCost.build3CostMaterials)
                {
                    Debug.Log(31);
                    GameObject build3 = Instantiate(bb, hit.collider.gameObject.transform);
                    build3.transform.localPosition = new UnityEngine.Vector3(0, 0, 0);
                    AssignGridObject(build3.GetComponent<PlaceableObject>());
                    Inventory.food -= BuildingCost.build3CostFood;
                    Inventory.constructionMaterials -= BuildingCost.build3CostMaterials;
                    hit.collider.gameObject.GetComponent<GirdStatus>().canBuild = false;
                }
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
