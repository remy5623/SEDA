using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GridXZ<TGridObject>
{
    public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;
    public class OnGridObjectChangedEventArgs : EventArgs
    {
        public int x;
        public int z;
    }

    private int width;
    private int height;
    private float cellSize;
    private Vector3 orginPosition;
    private TGridObject[,] gridArray;

   /* public GridXZ(int width, int height, float cellSize, Vector3 orginPosition, Func<GridXZ<TGridObject>, int, int, TGridObject[,] gridArray)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.orginPosition = orginPosition;
        gridArray = new TGridObject[width, height];

        for(int x=0;x<gridArray.GetLength(0);x++)
        {
            for(int z=0;z<gridArray.GetLength(1);z++)
            {
                gridArray[x, z] = createGridObject(this, x, z);
            }
        }

        bool showDebug = false;
        if(showDebug)
        {
            TextMesh[,] debugTextArray = new TextMesh[width,height];

            for(int x=0;x<gridArray.GetLength(0);x++)
            {
                for(int z=0; z< gridArray.GetLength(1); z++)
                {
                    debugTextArray[x, z] = UtilsClass.CreateWorldText(gridArray[x, z].ToString(), null, GetWorldPosition(x, z) + new Vector3(cellSize, cellSize) * 0.5f, 30, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z), Color.white, 100f);
                }
            }
            Debug.DrawLine(GetWorlPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetWorlPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

            OnGridObjectChaned += (object sender, OnGridObjectChangedEventArgs eventArgs) =>
            {
                debugTextArray[eventArgs.x, Event.z].text = gridArray[eventArgs.x, eventArgs.z]?.ToString();
            };
        }
    }

    public int GetWidth()
    {
        return width;
    }*/
}

