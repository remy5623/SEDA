using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridSystemTest : MonoBehaviour
{
    public static GridSystemTest Instance {get; private set;}
    private GridSystem gridSystem;
    public Transform debugObject;
    public int GridLength;
    public int GridWidth;
    public void Start()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        gridSystem = new GridSystem(GridLength, GridWidth, 2);
        
        gridSystem.CreateDebugOjbects(debugObject);

    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return gridSystem.GetGridPosition(worldPosition);
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return gridSystem.GetWorldPosition(gridPosition);
    }

    public Transform[,] GetGridGameOjbectsArray()
    {
        return gridSystem.GetGridGameObjectsArray();
    }

    public GridSystem GetGridSystem()
    {
        return this.gridSystem;
    }
}
