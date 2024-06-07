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
    private int length;
    private float cellSize;
    public GridObject[,] gridObjectsArray;
    public Transform[,] gridGameObjectsArray;

    //public delegate void OnGridGameObjectsChanged(object sender,EventArgs e);
    public event EventHandler OnGridSystemChanged;
    public GameObject gridFolder;

    public GridSystem(int width, int Length, float cellSize)
    {
        this.width = width;
        this.length = Length;
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
        gridGameObjectsArray = new Transform[2 * width + 1, 2 * length + 1];

        for(int x = -width;x <=width;x++)
        {
            for(int z = -length ; z<=length; z++)
            {
                int arrayX = x + width;
                int arrayY = z + length;

                GridPosition gridPosition = new GridPosition(x,z);

                gridGameObjectsArray[arrayX, arrayY] = GameObject.Instantiate(debugObject,GetWorldPosition(gridPosition) + Vector3.up *.5f,quaternion.identity);

                gridGameObjectsArray[arrayX, arrayY].name = debugObject.name + "_" + "(" + x + "," + z + ")"; 

                GridDebugObject gridDebugObject = gridGameObjectsArray[arrayX, arrayY].GetComponent<GridDebugObject>();

                gridDebugObject.SetGridObject(GetGridObject(gridPosition));

                gridGameObjectsArray[arrayX, arrayY].SetParent(gridFolder.transform);
            }
        }
        SetGridGameObjectsArray(gridGameObjectsArray);
    }


    public void SetGridObjectArray(GridObject[,] gridObjects)
    {
        //change the gridObject array.
        OnGridSystemChanged?.Invoke(this,EventArgs.Empty);
        this.gridObjectsArray = gridObjects;
    }
    public GridObject[,] GetGridObjectArray()
    {
        //get the gridObject array.
        return gridObjectsArray;
    }

    public void SetGridGameObjectsArray(Transform[,] gridGameObjects)
    {
        //change the gridGameObjects array.
        OnGridSystemChanged?.Invoke(this,EventArgs.Empty);
        this.gridGameObjectsArray = gridGameObjects;
    }

    public Transform[,] GetGridGameObjectsArray()
    {
        //get the gridGameObjects array。
        return gridGameObjectsArray;
    }
    public GridObject GetGridObject(GridPosition gridPosition)
    {
        //get the gridObject on given gridPosition.
        return gridObjectsArray[gridPosition.x+width,gridPosition.z + length];
    }
    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        //get the worldPosition on given gridPosition.
        return new Vector3(gridPosition.x,0,gridPosition.z) * cellSize;
    }
    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        // translate the worldposition into gridPosition.
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x/cellSize +width),
            Mathf.RoundToInt(worldPosition.z/cellSize +length)
        );        
    }
}
