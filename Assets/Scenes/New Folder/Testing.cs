using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Testing : MonoBehaviour
{
    
    // The input action asset containing all actions related to interaction
    [SerializeField] InputActionAsset interactActions;

    //The actions to get the test buildings
    InputAction A;
    InputAction mousePos;


    private Grid grid;

    // Start is called before the first frame update
    private void Start()
    {
         grid = new Grid(4, 2, 10f);

        interactActions.FindActionMap("Interaction").Enable();
        interactActions.FindActionMap("Camera").Disable();

        A = interactActions.FindAction("A");
        mousePos = interactActions.FindAction("mousePos");

        if (A != null)
        {
            A.performed += ctx => Ainput();
        }

    }

    void Ainput()
    {
        mousePos.ReadValue<Vector2>();
        grid.SetValue(GetMouseWorldPosition(), 56);
    }

    public Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(mousePos.ReadValue<Vector2>(), Camera.main);
        vec.z = 0f;
        return vec;
    }

    public  Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(mousePos.ReadValue<Vector2>(), Camera.main);
    }

    

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

    public Vector3 GetDirToMouse(Vector3 fromPosition)
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        return (mouseWorldPosition - fromPosition).normalized;
    }



}
