using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int Length;
    private float cellSize;
    private GridObject[,] gridObjectsArray;

    public GridSystem(int width, int Length, float cellSize)
    {
        this.width = width;
        this.Length = Length;
        this.cellSize = cellSize;

        gridObjectsArray = new GridObject[width,Length];

        for(int x = 0;x< width;x++)
        {
            for(int z = 0; z< Length; z++)
            {
                GridPosition gridPosition = new GridPosition(x,z);

                gridObjectsArray[x,z] = new GridObject(gridPosition,this);

                Debug.DrawLine(GetWorldPosition(gridPosition),GetWorldPosition(gridPosition)+Vector3.right * .2f, Color.white,1000);
            }
        }
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x,0,gridPosition.z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x/cellSize),
            Mathf.RoundToInt(worldPosition.z/cellSize)
        );        
    }
}
