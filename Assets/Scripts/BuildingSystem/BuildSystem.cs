using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildSystem : MonoBehaviour
{
    public Resource BuildingType1;
    public Resource BuildingType2;
    public Resource BuildingType3;

    [SerializeField]
    InputActionAsset actionAsset;

    InputAction placeAction;
    InputAction tapLocation;

    public static bool isInBuildMode = false;

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

            GridObject hitGridObject;
            if (hitGridObject = hit.collider.gameObject.GetComponent<GridObject>())
            {
                hitGridObject.TryBuild(BuildingType1);
            }
        }

        else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Grid" && GameObject.Find("Canvas").GetComponent<BuildingTypeSelect>().isSetB2)
        {
            GridObject hitGridObject;
            if (hitGridObject = hit.collider.gameObject.GetComponent<GridObject>())
            {
                hitGridObject.TryBuild(BuildingType2);
            }
        }

        else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Grid" && GameObject.Find("Canvas").GetComponent<BuildingTypeSelect>().isSetB3)
        {
            GridObject hitGridObject;
            if (hitGridObject = hit.collider.gameObject.GetComponent<GridObject>())
            {
                hitGridObject.TryBuild(BuildingType3);
            }
        }
    }


}
