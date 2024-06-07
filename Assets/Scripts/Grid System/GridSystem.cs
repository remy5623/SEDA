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
    public GridObject[,] gridObjectsArray;
    public Transform[,] gridGameObjectsArray;
    
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

    public void CreateDebugOjbects(Transform debugObject)
    {
        gridGameObjectsArray = new Transform[2 * width + 1, 2 * Length + 1];

        for(int x = -width;x <=width;x++)
        {
            for(int z = -Length ; z<=Length; z++)
            {
                int arrayX = x + width;
                int arrayY = z + Length;

                GridPosition gridPosition = new GridPosition(x,z);

                //gridGameObjectsArray[arrayX, arrayY] = GameObject.Instantiate(debugObject,GetWorldPosition(gridPosition) + Vector3.up, quaternion.identity);
                gridGameObjectsArray[arrayX, arrayY] = GameObject.Instantiate(debugObject,GetWorldPosition(gridPosition) + Vector3.up * 0.5f, quaternion.identity);

                GridDebugObject gridDebugObject = gridGameObjectsArray[arrayX, arrayY].GetComponent<GridDebugObject>();

                gridDebugObject.SetGridObject(GetGridObject(gridPosition));

            }
        }
        SetGridGameObjectsArray(gridGameObjectsArray);
    }

    public void SetGridObjectArray(GridObject[,] gridObjects)
    {
        this.gridObjectsArray = gridObjects;
    }
    public GridObject[,] GetGridObjectArray()
    {
        return gridObjectsArray;
    }

    public void SetGridGameObjectsArray(Transform[,] gridGameObjects)
    {
        this.gridGameObjectsArray = gridGameObjects;
    }

    public Transform[,] GetGridGameObjectsArray()
    {
        return gridGameObjectsArray;
    }


    public GridObject GetGridObject(GridPosition gridPosition)
    {
        Debug.Log("X: " + gridPosition.x + width + ", Y: " + gridPosition.z + Length);
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
