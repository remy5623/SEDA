using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.UI;

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

        for(int x = 0;x < width;x++)
        {
            for(int z = 0 ; z < Length; z++)
            {
                GridPosition gridPosition = new GridPosition(x,z);

                gridObjectsArray[x,z] = new GridObject(gridPosition,this);

                Debug.Log(gridPosition.ToString());

                Debug.DrawLine(GetWorldPosition(gridPosition),GetWorldPosition(gridPosition)+Vector3.forward * cellSize, Color.white,1000);
                Debug.DrawLine(GetWorldPosition(gridPosition),GetWorldPosition(gridPosition)+Vector3.right * cellSize, Color.white,1000);
            }
        }
    }

    public void CreateDebugOjbects(Transform debugObject)
    {
        for(int x = 0;x < width;x++)
        {
            for(int z = 0 ; z < Length; z++)
            {
                //get position in Arrays
                GridPosition gridPosition = new GridPosition(x,z);
                //create transform
                Transform debugTransform = GameObject.Instantiate(debugObject,GetWorldPosition(gridPosition),quaternion.identity);
                GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                //put transform into the position
                gridDebugObject.SetGridObject(GetGridObject(gridPosition));
            }
        }
    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjectsArray[gridPosition.x,gridPosition.z];
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
