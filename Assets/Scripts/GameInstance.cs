/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public static GameInstance instance { get; set; }
    //Test
    [SerializeField] private GameObject Test;
    //GridSystem
    public  GridSystem gridSystem;
    public  Transform[,] gridGameObjectsArray;
    public  GridObject[,] gridObjectsArray;




    public void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        GridSystemTest gridSystemTestInstance = GridSystemTest.Instance;

        gridSystem = gridSystemTestInstance.gridSystem;

        Debug.Log(gridSystem);

        //this.gridGameObjectsArray = gridSystemTest.gridSystem.GetGridGameObjectsArray();

        //this.gridObjectsArray = gridSystemTest.gridSystem.GetGridObjectArray();
    }

    public void Update()
    {
        *//*
       if(gridSystem.gridObjectsArray != gridObjectsArray)
        {
            this.gridObjectsArray = gridSystem.GetGridObjectArray();
        }
        if (gridSystem.gridGameObjectsArray != gridGameObjectsArray)
        {
            this.gridGameObjectsArray = gridSystem.GetGridGameObjectsArray();
        }
        *//*
    }
}
*/