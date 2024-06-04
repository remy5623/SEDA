using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    private GridPosition gridPosition;
    private GridSystem gridSystem;
    private List<TileBase> structureList;

    public GridObject(GridPosition gridPosition,GridSystem gridSystem)
    {
        this.gridPosition = gridPosition;
        this.gridSystem = gridSystem;
        structureList = new List<TileBase>();
    }
}
