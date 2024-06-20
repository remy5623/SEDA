using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildSystem : MonoBehaviour
{
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
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Grid")
        {
            GridObject hitGridObject;
            if (hitGridObject = hit.collider.gameObject.GetComponent<GridObject>())
            {
                hitGridObject.TryBuild(transform.parent.GetComponentInChildren<BuildingTypeSelect>().currentBuildingType);
            }
        }
    }


}
