using UnityEngine;

[ExecuteAlways]
public class GridSystem : MonoBehaviour
{
    [SerializeField] int gridLength = 1;
    [SerializeField] int gridWidth = 1;
    [SerializeField] int gridHeight = 0;
    [SerializeField] int cellSize = 1;

    [SerializeField] GridObject gridObjectPrefab;

    private GridObject[,] gridTiles;

    public void MakeItWork()
    {
        ClearGrid();
        gridTiles = new GridObject[gridLength, gridWidth];
        CreateGrid();
    }

    private void ClearGrid()
    {
        if (gridTiles != null)
        {
            foreach (GridObject gridTile in gridTiles)
            {
                DestroyImmediate(gridTile.gameObject);
            }
            gridTiles = null;
        }
    }

    private void CreateGrid()
    {
        Vector3 tileRotation = new Vector3(90, 0, 0);
        

        for (int x = 0; x < gridLength; x++)
        {
            for (int y = 0;  y < gridWidth; y++)
            {
                gridTiles[x, y] = Instantiate(gridObjectPrefab, new Vector3(x * cellSize, gridHeight, y * cellSize), Quaternion.Euler(tileRotation));
                gridTiles[x, y].transform.localScale = new Vector3(cellSize, cellSize, cellSize);
                gridTiles[x, y].transform.parent = gameObject.transform;
            }
        }
    }

    private void OnDestroy()
    {
        ClearGrid();
    }
}
