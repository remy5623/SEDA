using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnularCypher : MonoBehaviour
{
    public int rotateSpeed;
    public int stopSpeed;

    private Rigidbody2D rbody;
    public bool inRotate;

    float t;

    public enum locationsToStop
    {
        A,
        B,
        C,
        D,
        E
    }

    private Vector3 placeToStop;

    public List<GameObject> cypherDisks;
    public GameObject objectToRotate; 

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        rbody = objectToRotate.GetComponent<Rigidbody2D>();

        if (rbody.angularVelocity >0)
        {
            rbody.angularVelocity -= stopSpeed*Time.deltaTime;

            rbody.angularVelocity = Mathf.Clamp(rbody.angularVelocity, 0, 1440);
        }

        if(rbody.angularVelocity == 0 && inRotate)
        {
            t += 1 * Time.deltaTime;
            
            if(t >= 0.5f)
            {
                GetReward();

                inRotate = false;
                t = 0;
            }

        }
    }

    public void Rotate()
    {
        if(!inRotate)
        {
            rbody.AddTorque(rotateSpeed);
            inRotate = true;
        }
    }

    public void GetReward()
 
    {
        float rot = objectToRotate.transform.eulerAngles.z;

        if(rot > 0 && rot <= 120f)
        {
            Win(90);
        }
        else if(rot > 120 && rot <=240f)
        {
            Win(100);
        }
        else
        {
            Win(110);
        }
    }

    public void Win(int score)
    {
        print(score);
    }
}
