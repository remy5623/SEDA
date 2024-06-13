using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class GridSystem
{
    public int width;
    private int Length;
    private float cellSize;
    public GridObject[,] gridObjectsArray;
    public GirdStatus[,] gridGameObjectsArray;
    
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
        SetGridObjectArray(gridObjectsArray);
    }

    public void CreateDebugOjbects(GirdStatus debugObject)
    {
        gridGameObjectsArray = new GirdStatus[2 * width + 1, 2 * Length + 1];

        for(int x = -width;x <=width;x++)
        {
            for(int z = -Length ; z<=Length; z++)
            {
                int arrayX = x + width;
                int arrayY = z + Length;

                GridPosition gridPosition = new GridPosition(x,z);

                //gridGameObjectsArray[arrayX, arrayY] = GameObject.Instantiate(debugObject,GetWorldPosition(gridPosition) + Vector3.up, quaternion.identity);
                Vector3 initRotation = new Vector3(90f, 0f, 0f);
                gridGameObjectsArray[arrayX, arrayY] = GameObject.Instantiate(debugObject,GetWorldPosition(gridPosition) + Vector3.up * 0.5f, Quaternion.Euler(initRotation));

                GridDebugObject gridDebugObject = gridGameObjectsArray[arrayX, arrayY].GetComponent<GridDebugObject>();

                gridDebugObject.SetGridObject(GetGridObject(gridPosition));

            }
        }
        SetGridGameObjectsArray(gridGameObjectsArray);
    }

    public void SetGridObjectArray(GridObject[,] gridObjects)
    {
        gridObjectsArray = gridObjects;
    }

    public GridObject[,] GetGridObjectArray()
    {
        return gridObjectsArray;
    }

    public void SetGridGameObjectsArray(GirdStatus[,] gridGameObjects)
    {
        gridGameObjectsArray = gridGameObjects;
    }

    public GirdStatus[,] GetGridGameObjectsArray()
    {
        return gridGameObjectsArray;
    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        //Debug.Log("X: " + (gridPosition.x + width) + ", Y: " + (gridPosition.z + Length));
        return gridObjectsArray[gridPosition.x+width,gridPosition.z + Length];
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x,0.25f,gridPosition.z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x/cellSize),
            Mathf.RoundToInt(worldPosition.z/cellSize)
        );        
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetLength()
    {
        return Length;
    }

}
