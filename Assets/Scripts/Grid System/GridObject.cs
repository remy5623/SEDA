using UnityEngine;

[ExecuteAlways]
public class GridObject : MonoBehaviour
{
    [SerializeField] Terrainsystem terrainType;
    [SerializeField] PlaceableObject building;

    private void Update()
    {
        
    }

    public bool CanBuildOnTile()
    {
        return true;
    }
}
