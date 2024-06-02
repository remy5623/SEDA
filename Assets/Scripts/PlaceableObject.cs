using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public bool Placed { get; private set; } 
    public Vector3Int Size { get; private set; }
    private Vector3[] vertices;

    private void GetColliderVertexPositionLocal()
    {
        BoxCollider b = gameObject.GetComponent<BoxCollider>();
        vertices = new Vector3[4];
        vertices[0] = b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f;
        vertices[1] = b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f;
        vertices[2] = b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f;
        vertices[3] = b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f;
    }

    private void CalculateSizeInCells()
    {
        Vector3Int[] Vertices = new Vector3Int[vertices.Length];

        for(int i=0; i < vertices.Length; i++)
        {
            Vector3 worldPos = transform.TransformPoint(vertices[i]);
            vertices[i] = BuildingSystem.instance.GridLayout.WorldToCell(worldPos);
        }
        Size = new Vector3Int((int)Math.Abs((vertices[0] - vertices[1]).x),
                              (int)Math.Abs((vertices[0] - vertices[3]).y), 
                              1);
    }

    public Vector3 GetStartPosition()
    {
        return transform.TransformPoint(vertices[0]);
    }

    private void Start()
    {
        GetColliderVertexPositionLocal();
        CalculateSizeInCells();
    }

    public virtual void Place()
    {
        ObjectDrop drop = gameObject.GetComponent<ObjectDrop>();
        Destroy(drop);

        Placed = true;

        //invoke events of placement
    }
}
