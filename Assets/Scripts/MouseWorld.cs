using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;

    private GridPosition gridPosition;
    [SerializeField] private LayerMask mousePlaneLayerMask;

    private void Awake() 
    {
        instance = this;
    }
    private void Update()
    {
        transform.position = MouseWorld.GetPostion();

        DebugMouseClick();
    }
    //
    public static Vector3 GetPostion()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return raycastHit.point;
    }

    //Once mouse clicked, return value based on where the mouse is.
    public void DebugMouseClick()
    {
        if(Mouse.current.leftButton.isPressed)
        {
            gridPosition= GridSystemTest.Instance.GetGridPosition(MouseWorld.GetPostion());
            Debug.Log(gridPosition);
        }
    
    }
}
