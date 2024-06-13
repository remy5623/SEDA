using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    // The grid object that this PlaceableObject has been placed on
    protected GridObject owningGridObject;

    public virtual void SetGridObject(GridObject gridObject)
    {
        owningGridObject = gridObject;
    }
}
