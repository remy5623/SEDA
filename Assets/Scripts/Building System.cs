using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem instance;

    // The input action asset containing all actions related to interaction
    [SerializeField] InputActionAsset interactActions;

    //The actions to get the test buildings
    InputAction A;
    InputAction B;


    public GridLayout GridLayout;
    private Grid Grid;
    [SerializeField] private Tilemap MainTileMap;
    [SerializeField] public TileBase TileBase;

    public GameObject Prefab1;
    public GameObject Prefab2;

    private PlaceableObject objectToPlace;

    #region Unity methods

    private void Awake()
    {
        instance = this;
        Grid = GridLayout.gameObject.GetComponent<Grid>();
    }

    private void Start()
    {
        if (interactActions)
        {
            interactActions.FindActionMap("Interaction").Enable();
            interactActions.FindActionMap("Camera").Disable();
            A = interactActions.FindAction("A");
            B = interactActions.FindAction("B");   
        }
        if (A != null)
        {
            A.performed += ctx => Ainput();
        }
        if (B != null)
        {
            B.performed += ctx => Binput();
        }
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            InitializeWithObject(Prefab1);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            InitializeWithObject(Prefab2);
        }
    }*/

    private void Ainput()
    {
        Debug.Log("A");
        InitializeWithObject(Prefab1);
    }
    private void Binput()
    {
        Debug.Log("B");
        InitializeWithObject(Prefab2);
    }

    #endregion

    #region Utils

    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else 
            return Vector3.zero;
    }

    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = GridLayout.WorldToCell(position);
        position = Grid.GetCellCenterWorld(cellPos);
        return position;
    }

    #endregion

    #region Building Placement

    public void InitializeWithObject(GameObject prefab)
    {
        Vector3 position = SnapCoordinateToGrid(Vector3.zero);

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrop>();

    }

    #endregion
}
