using JetBrains.Annotations;
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
    InputAction C;
    InputAction D;
    InputAction mousePosAction;


    public GridLayout GridLayout;
    private Grid Grid;
    [SerializeField] private Tilemap MainTileMap;
    [SerializeField] public TileBase WhiteTile;

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
            // interactActions.FindActionMap("Camera").Disable();
            A = interactActions.FindAction("A");
            B = interactActions.FindAction("B"); 
            C = interactActions.FindAction("C");
            D = interactActions.FindAction("D");
            mousePosAction = interactActions.FindAction("mouseActionPo");
        }
        if (A != null)
        {
            A.performed += ctx => Ainput();
        }
        if (B != null)
        {
            B.performed += ctx => Binput();
        }
        if (C != null)
        {
            C.performed += ctx => Cinput();
        }
        if (D != null)
        {
            D.performed += ctx => Dinput();
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
    private void Cinput()
    {
        if (CanBePlaced(objectToPlace))
        {
            objectToPlace.Place();
            Vector3Int start = GridLayout.WorldToCell(objectToPlace.GetStartPosition());
            TakeArea(start, objectToPlace.Size);

        }
        else
            Destroy(objectToPlace.gameObject);
    }

    private void Dinput()
    {
        Destroy(objectToPlace.gameObject);
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
        //position = Grid.GetCellCenterWorld(cellPos);
        return position;
    }

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }

        return array;
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

    private bool CanBePlaced(PlaceableObject placeableObject)
    {
        
            BoundsInt area = new BoundsInt();
            area.position = GridLayout.WorldToCell(objectToPlace.GetStartPosition());
            area.size = placeableObject.Size;

            TileBase[] baseArray = GetTilesBlock(area, MainTileMap);

            foreach(var b in baseArray)
            {
                if(b == WhiteTile)
                {
                    return false;
                }

            }
            return true;
        
    }
    
    public void TakeArea(Vector3Int start, Vector3Int size)
    {
        MainTileMap.BoxFill(start, WhiteTile, start.x, start.y, start.x + size.x, start.y + size.y);

    }
    #endregion
}
