using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
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

        gridObjectsArray = new GridObject[2 * width +1,2 *Length + 1];

        for(int x = -width;x <=width;x++)
        {
            for(int z = -Length ; z<=Length; z++)
            {
                int arrayX = x + width;
                int arrayY = z + Length;

                GridPosition gridPosition = new GridPosition(x,z);

                gridObjectsArray[arrayX,arrayY] = new GridObject(gridPosition,this);

                //Debug.Log(gridPosition.ToString());
                //Debug.DrawLine(GetWorldPosition(gridPosition),GetWorldPosition(gridPosition)+Vector3.forward * cellSize, Color.white,1000);
                //Debug.DrawLine(GetWorldPosition(gridPosition),GetWorldPosition(gridPosition)+Vector3.right * cellSize, Color.white,1000);
            }
        }
    }

    public void CreateDebugOjbects(Transform debugObject)
    {
        for(int x = -width;x <=width;x++)
        {
            for(int z = -Length ; z<=Length; z++)
            {
                int arrayX = x + width;
                int arrayY = z + Length;

                GridPosition gridPosition = new GridPosition(x,z);
                //create transform
                Transform debugTransform = GameObject.Instantiate(debugObject,GetWorldPosition(gridPosition) + Vector3.up *.5f,quaternion.identity);
                GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                //put transform into the position
                gridDebugObject.SetGridObject(GetGridObject(gridPosition));
            }
        }
    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjectsArray[gridPosition.x+width,gridPosition.z + Length];
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
