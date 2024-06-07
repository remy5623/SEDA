using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    //The gameInstance should be connected to all the independent systems aothernd store their meaningful variables
    //so that each system can easily read variables ​​they need in other systems.

    public static GameInstance instance { get; set; }
    
    [Header("Systems")]
    [SerializeField] private GameObject gridSystemInGame;
    [SerializeField] private GameObject BuildSystemInGame;
    //GridSystem
    public  GridSystem gridSystem;
    public  Transform[,] gridGameObjectsArray;
    public  GridObject[,] gridObjectsArray;




    public void Start()
    {
        //singleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        
        //gridSystem
        gridSystem = gridSystemInGame.GetComponent<GridSystemTest>().GetGridSystem();

        gridObjectsArray = gridSystem.GetGridObjectArray();
        gridGameObjectsArray = gridSystem.GetGridGameObjectsArray();
        //every time gridsystem changed, refresh.
        gridSystem.OnGridSystemChanged += OnGridSystemChanged_UpdateGridSystem;
        

        //Debug.Log(gridGameObjectsArray[1,1].GetComponent<GridDebugObject>().GetGridObject());
        //Debug.Log(gridObjectsArray[1,1]);

    }


    private void OnGridSystemChanged_UpdateGridSystem(object sender,EventArgs e)
    {
        this.gridObjectsArray = gridSystemInGame.GetComponent<GridSystemTest>().GetGridSystem().GetGridObjectArray();
        this.gridGameObjectsArray = gridSystemInGame.GetComponent<GridSystemTest>().GetGridSystem().GetGridGameObjectsArray();
    }
}
