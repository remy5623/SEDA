using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridSystemTest : MonoBehaviour
{
    private GridSystem gridSystem;
    public Transform debugObject;
    public void Start()
    {
        gridSystem = new GridSystem(50,50,2);

        gridSystem.CreateDebugOjbects(debugObject);
        
    }
}
