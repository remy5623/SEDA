// Remy Pijuan 2024

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    // Level Settings is a singleton
    private static LevelManager instance;

    [SerializeField] InputActionAsset inputs;

    InputAction tapAction;
    InputAction tapLocation;

    // This function reference is necessary for callback registering/deregistering to work properly
    Action<InputAction.CallbackContext> possessCamera;

    // time in months
    public int levelTimeStore;

    [SerializeField] int successFoodAmount;
    [SerializeField] int successConstructionMaterialsAmount;
    [SerializeField] int successSoilHealth;

    // radius highlight prefabs
    [SerializeField] GameObject waterOutline;
    [SerializeField] GameObject energyOutline;
    [SerializeField] GameObject extraOutline;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Inventory.levelTime = levelTimeStore;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        tapAction = inputs.FindAction("PossessCamera");
        possessCamera = ctx => SelectTile();
        tapAction.performed += possessCamera;

        tapLocation = inputs.FindAction("PanCamera");
    }

    void SelectTile()
    {
        float radius = 0;
        GameObject outline;

        Ray ray = Camera.main.ScreenPointToRay(tapLocation.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Building building;
            Terrainsystem terrainTile;

            if (building = hit.transform.gameObject.GetComponent<Building>())
            {
                radius = building.resourceData.impactRadiusTiles;
                outline = Instantiate(extraOutline, building.transform.position, Quaternion.identity);

                if (radius > 0)
                    outline.transform.localScale *= radius + 3;
            }
            else if(terrainTile = hit.transform.gameObject.GetComponent<Terrainsystem>())
            {
                radius = terrainTile.radius;
                outline = Instantiate(extraOutline, terrainTile.transform.position, Quaternion.identity);

                if (radius > 0)
                    outline.transform.localScale *= radius + 3;
            }
        }
    }

    public static bool AreSuccessConditionsMet()
    {
        bool success = true;

        if (Inventory.food < instance.successFoodAmount)
        {
            success = false;
        }

        if (Inventory.constructionMaterials < instance.successConstructionMaterialsAmount)
        {
            success = false;
        }

        if (Inventory.healthBar < instance.successSoilHealth)
        {
            success = false;
        }    

        return success;
    }

    private void OnDestroy()
    {
        tapAction.performed -= possessCamera;
    }
}
