using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Build : MonoBehaviour
{
    public GameObject ab;
    public GameObject aa;
    public GameObject bb;
    private void Start()
    {
      
    }
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {      
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)&&hit.collider.gameObject.tag == "Gird"&& GameObject.Find("Canvas").GetComponent<Gied>().isSetB1)
            {
                if(hit.collider.gameObject.GetComponent<GirdStatus>().canBuild)
                {
                    GameObject build1 = Instantiate(ab, hit.collider.gameObject.transform);
                    build1.transform.localPosition = new UnityEngine.Vector3(0, 0, 0);
                    hit.collider.gameObject.GetComponent<GirdStatus>().canBuild = false;
                }
            }
           else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Gird" && GameObject.Find("Canvas").GetComponent<Gied>().isSetB2)
            {
                if (hit.collider.gameObject.GetComponent<GirdStatus>().canBuild)
                {

                    GameObject build2 = Instantiate(aa, hit.collider.gameObject.transform);
                    build2.transform.localPosition = new UnityEngine.Vector3(0, 0, 0);
                    hit.collider.gameObject.GetComponent<GirdStatus>().canBuild = false;
                }
            }
           else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Gird" && GameObject.Find("Canvas").GetComponent<Gied>().isSetB3)
            {
                if (hit.collider.gameObject.GetComponent<GirdStatus>().canBuild)
                {

                    GameObject build3 = Instantiate(bb, hit.collider.gameObject.transform);
                    build3.transform.localPosition = new UnityEngine.Vector3(0, 0, 0);
                    hit.collider.gameObject.GetComponent<GirdStatus>().canBuild = false;
                }
            }

        }
    }



}
