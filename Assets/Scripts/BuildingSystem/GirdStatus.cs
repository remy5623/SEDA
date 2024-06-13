using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirdStatus : MonoBehaviour
{
    public bool canBuild = false;
    public bool canBuildStatus = false;
    void Start()
    {
        canBuild = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(canBuild&&canBuildStatus)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (canBuild && !canBuildStatus)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
