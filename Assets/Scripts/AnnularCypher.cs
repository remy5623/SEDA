using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnularCypher : MonoBehaviour
{
    public int rotateSpeed;
    public float stopThreshold = 1f; // Threshold to consider the disk as stopped

    private Rigidbody2D rbody;
    public bool inRotate;

    public List<GameObject> cypherDisks;

    public GameObject objectToRotate;

    private bool spinning;

    public enum WaterGradeLocationsToStop
    {
        A,
        B,
        C,
        D,
        E
    }

    private Dictionary<WaterGradeLocationsToStop, float> waterGradeLocationAngles = new Dictionary<WaterGradeLocationsToStop, float>
    {
        { WaterGradeLocationsToStop.A, 0f },
        { WaterGradeLocationsToStop.B, 72f },
        { WaterGradeLocationsToStop.C, 144f },
        { WaterGradeLocationsToStop.D, 216f },
        { WaterGradeLocationsToStop.E, 288f }
    };

    public enum LandGradeLocationsToStop
    {
        A,
        B,
        C,
        D,
        E
    }

    private Dictionary<LandGradeLocationsToStop, float> landGradeLocationAngles = new Dictionary<LandGradeLocationsToStop, float>
    {
        { LandGradeLocationsToStop.A, 0f },
        { LandGradeLocationsToStop.B, 72f },
        { LandGradeLocationsToStop.C, 144f },
        { LandGradeLocationsToStop.D, 216f },
        { LandGradeLocationsToStop.E, 288f }
    };


    public enum MonthLocationToStop
    {
        Jan,
        Feb,
        Mar,
        Apr,
        May,
        Jun,
        Jul,
        Aug,
        Sept,
        Oct,
        Nov,
        Dec
    }

    private Dictionary<MonthLocationToStop, float> monthLocationAngles = new Dictionary<MonthLocationToStop, float>
    {
        { MonthLocationToStop.Jan, 0f - 15f},
        { MonthLocationToStop.Feb, 30f - 15f},
        { MonthLocationToStop.Mar, 60f - 15f },
        { MonthLocationToStop.Apr, 90f - 15f },
        { MonthLocationToStop.May, 120f - 15f },
        { MonthLocationToStop.Jun, 150f - 15f },
        { MonthLocationToStop.Jul, 180f - 15f },
        { MonthLocationToStop.Aug, 210f - 15f },
        { MonthLocationToStop.Sept, 240f - 15f },
        { MonthLocationToStop.Oct, 270f - 15f },
        { MonthLocationToStop.Nov, 300f - 15f },
        { MonthLocationToStop.Dec, 330f - 15f }
    };

    public enum OutputDiskLocationsToStop
    {
        O10,
        O20,
        O30,
        O40,
        O50,
        O60,
        O70,
        O80,
        O90,
        O100,
        O110,
        O120,
        O130,
        O140,
        O150,
        O160,
        O170,
        O180,
        O190,
        O200
    }

    private Dictionary<OutputDiskLocationsToStop, float> outputDiskLocationAngles = new Dictionary<OutputDiskLocationsToStop, float>
    {
        { OutputDiskLocationsToStop.O10, 18f - 8f },
        { OutputDiskLocationsToStop.O20, 36f - 8f },
        { OutputDiskLocationsToStop.O30, 54f - 8f },
        { OutputDiskLocationsToStop.O40, 72f - 8f },
        { OutputDiskLocationsToStop.O50, 90f - 8f },
        { OutputDiskLocationsToStop.O60, 108f - 8f },
        { OutputDiskLocationsToStop.O70, 126f - 8f },
        { OutputDiskLocationsToStop.O80, 144f - 8f },
        { OutputDiskLocationsToStop.O90, 162f - 8f },
        { OutputDiskLocationsToStop.O100, 180f - 8f },
        { OutputDiskLocationsToStop.O110, 198f - 8f },
        { OutputDiskLocationsToStop.O120, 216f - 8f },
        { OutputDiskLocationsToStop.O130, 234f - 8f },
        { OutputDiskLocationsToStop.O140, 252f - 8f },
        { OutputDiskLocationsToStop.O150, 270f - 8f },
        { OutputDiskLocationsToStop.O160, 288f - 8f },
        { OutputDiskLocationsToStop.O170, 306f - 8f },
        { OutputDiskLocationsToStop.O180, 324f - 8f },
        { OutputDiskLocationsToStop.O190, 342f - 8f },
        { OutputDiskLocationsToStop.O200, 360f - 8f }
    };

 

    private void Update()
    {
        if (inRotate)
        {
            float currentAngle = objectToRotate.transform.eulerAngles.z;
            float targetAngle = GetTargetAngle(objectToRotate);

            // Rotate the disk at a constant speed
            rbody.angularVelocity = rotateSpeed;

            // Check if the disk has reached the target angle within the threshold
            if (Mathf.Abs(Mathf.DeltaAngle(currentAngle, targetAngle)) < stopThreshold)
            {
                // Stop the rotation
                rbody.angularVelocity = 0;
                inRotate = false;
                GetReward();
                spinning = false;
            }
        }
    }

    private IEnumerator SpinDisks()
    {
        foreach (var disk in cypherDisks)
        {
            objectToRotate = disk;
            rbody = objectToRotate.GetComponent<Rigidbody2D>();
            yield return StartCoroutine(SpinAndStopAtLocation());
        }
    }

    private IEnumerator SpinAndStopAtLocation()
    {
        Rotate();

        while (inRotate)
        {
            yield return null;
        }

        // Ensure the disk stops exactly at the target angle
        float targetAngle = GetTargetAngle(objectToRotate);
        objectToRotate.transform.eulerAngles = new Vector3(0, 0, targetAngle);
    }

    private float GetTargetAngle(GameObject disk)
    {
        string diskName = disk.name;

        // Determine the target angle based on the disk's name
        if (diskName.Contains("Land"))
        {
            LandGradeLocationsToStop targetLocation = DetermineLandGradeLocation(diskName);
            return landGradeLocationAngles[targetLocation];
        }
        if (diskName.Contains("Water"))
        {
            WaterGradeLocationsToStop targetLocation = DetermineWaterGradeLocation(diskName);
            return waterGradeLocationAngles[targetLocation];
        }
        else if (diskName.Contains("Month"))
        {
            MonthLocationToStop targetLocation = DetermineMonthLocation(diskName);
            return monthLocationAngles[targetLocation];
        }
        else if (diskName.Contains("Output"))
        {
            
            OutputDiskLocationsToStop targetLocation = DetermineOutputLocation(diskName);
            return outputDiskLocationAngles[targetLocation];
            
        }

        return 0f; // Default angle if no match found
    }

    private LandGradeLocationsToStop DetermineLandGradeLocation(string diskName)
    {
        // Implement logic to determine the grade location based on the disk's name
        return LandGradeLocationsToStop.C; // Example, change this to your logic
    }

    private WaterGradeLocationsToStop DetermineWaterGradeLocation(string diskName)
    {
        // Implement logic to determine the grade location based on the disk's name
        return WaterGradeLocationsToStop.B; // Example, change this to your logic
    }

    private MonthLocationToStop DetermineMonthLocation(string diskName)
    {
        // Implement logic to determine the month location based on the disk's name
        return MonthLocationToStop.Apr; // Example, change this to your logic
    }

    private OutputDiskLocationsToStop DetermineOutputLocation(string diskName)
    {
        // Implement logic to determine the output location based on the disk's name
        return OutputDiskLocationsToStop.O120;// Example, change this to your logic
    }

    public void Rotate()
    {
        if (!inRotate)
        {
            inRotate = true;
        }
    }

    public void GetReward()
    {
        float rot = objectToRotate.transform.eulerAngles.z;
        string diskName = objectToRotate.name;

        if (diskName.Contains("Land"))
        {
            LandGradeLocationsToStop targetLocation = DetermineLandGradeLocation(diskName);
            Debug.Log($"Land Disk stopped at: {targetLocation}");
        }
        if (diskName.Contains("Grade"))
        {
            WaterGradeLocationsToStop targetLocation = DetermineWaterGradeLocation(diskName);
            Debug.Log($"Water Disk stopped at: {targetLocation}");
        }
        else if (diskName.Contains("Month"))
        {
            MonthLocationToStop targetLocation = DetermineMonthLocation(diskName);
            Debug.Log($"Month Disk stopped at: {targetLocation}");
        }
        else if (diskName.Contains("Output"))
        {
            OutputDiskLocationsToStop targetLocation = DetermineOutputLocation(diskName);
            Debug.Log($"Output Disk stopped at: {targetLocation}");
        }
    }

    public void RotateAll()
    {
        if (!spinning)
        {
            spinning = true;
            StartCoroutine(SpinDisks());
            spinning = false;
        }
    }
}