using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;

    private GridPosition gridPosition;
    private Transform[,] grid;

    [SerializeField] private LayerMask mousePlaneLayerMask;

    private void Awake() 
    {
        instance = this;
    }
    private void Update()
    {
        transform.position = Mouse.current.position.ReadValue();

        DebugMouseClick();
    }
    //
    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return raycastHit.point;
    }

    //Once mouse clicked, return value based on where the mouse is.
    public void DebugMouseClick()
    {
        if(Mouse.current.leftButton.isPressed)
        {
            gridPosition= GridSystemTest.Instance.GetGridPosition(MouseWorld.GetPosition());
            grid = GridSystemTest.Instance.GetGridGameOjbectsArray();

            
            Debug.Log
            ( 
                "Grid:  " + grid[gridPosition.x,gridPosition.z] + "\n" + 
                "InArrayPosition: " + gridPosition
            );
        }
        else if(Mouse.current.rightButton.isPressed)
        {
            gridPosition= GridSystemTest.Instance.GetGridPosition(MouseWorld.GetPosition());
            grid = GridSystemTest.Instance.GetGridGameOjbectsArray();

            grid[1,1].name += "sss";

            GridSystemTest.Instance.GetGridSystem().SetGridGameObjectsArray(grid);
            
            Debug.Log(GridSystemTest.Instance.GetGridGameOjbectsArray()[1,1].ToString());
        }
    
    }
}
