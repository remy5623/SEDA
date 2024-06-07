using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridObject : UnityEngine.Object
{
    public GridPosition GridPosition { get; private set; }
    public GridSystem GridSystem { get; private set; }
    public PlaceableObject objectOnTile;

    public GridObject(GridPosition gridPosition,GridSystem gridSystem)
    {
        GridPosition = gridPosition;
        GridSystem = gridSystem;
    }

    public override string ToString()
    {
        return GridPosition.ToString();
    }
}
