using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirdStatus : MonoBehaviour
{

    public bool canBuild ;
    public bool canBuildStatus ;
    void Start()
    {
        
        canBuildStatus = false;

    }
    private void Awake()
    {
        //canBuild = GetComponentInParent<GridDebugObject>().tilebase.canBuild;
    }
    // Update is called once per frame
    void Update()
    {
        if (!canBuildStatus)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else if(canBuild&&canBuildStatus)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (!canBuild && canBuildStatus)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
