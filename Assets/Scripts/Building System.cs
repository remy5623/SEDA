using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem instance;

    public GridLayout GridLayout;
    private Grid Grid;
    [SerializeField] private Tilemap MainTileMap;
    [SerializeField] public TileBase TileBase;

    public GameObject TileBasePrefab;
    public GameObject TileMapPrefab;

    private PlaceableObject objectToPlace;

    #region Unity methods

    private void Awake()
    {
        instance = this;
        Grid = GridLayout.gameObject.GetComponent<Grid>();
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
}
