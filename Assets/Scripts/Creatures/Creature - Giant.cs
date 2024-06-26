using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Giant : Building
{
    Terrainsystem ts1;
    Terrainsystem ts2;

    [SerializeField] GameObject endpoint1;
    [SerializeField] GameObject endpoint2;


    private void Start()
    {
        RaycastHit hit;
        if (Physics.Raycast(endpoint1.transform.position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Terrain")))
        {
            
            Debug.DrawLine(endpoint1.transform.position, endpoint1.transform.position + Vector3.down *100, Color.red, 500);
            ts1 = hit.transform.gameObject.GetComponent<Terrainsystem>();
        }
        
        if (Physics.Raycast(endpoint2.transform.position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Terrain")))
        {
            Debug.DrawLine(endpoint2.transform.position, endpoint2.transform.position + Vector3.down * 100, Color.yellow, 500);
            ts2 = hit.transform.gameObject.GetComponent<Terrainsystem>();
        }
        ts1.creaturetype = CreatureTypes.Giant;
        ts2.creaturetype = CreatureTypes.Giant;
    }

    public void Interact()
    {
        Debug.Log("click works");
        //UIpopup.SetActive(true);

        if (Inventory.food >= resourceData.bribeCostFood && Inventory.constructionMaterials >= resourceData.bribeCostConstruction)
        {
            //uibutton.SetActive(true);
        }
    }

    public void SetCreatureGone(Building creature)
    {
        Inventory.food -= creature.resourceData.bribeCostFood;
        Inventory.constructionMaterials -= creature.resourceData.bribeCostConstruction;
        Destroy(creature.gameObject);
        ts1.creaturetype = CreatureTypes.None; 
        ts2.creaturetype = CreatureTypes.None;
    }
}
