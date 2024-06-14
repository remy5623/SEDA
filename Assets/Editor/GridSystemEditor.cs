using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(GridSystem))]
[CanEditMultipleObjects]
public class GridSystemEditor : Editor
{
    GridSystem _target;

    SerializedProperty gridLength;
    SerializedProperty gridWidth;
    SerializedProperty gridHeight;
    SerializedProperty cellSize;
    SerializedProperty gridObjectPrefab;

    void OnEnable()
    {
        _target = (GridSystem)target;

        gridLength = serializedObject.FindProperty("gridLength");
        gridWidth = serializedObject.FindProperty("gridWidth");
        gridHeight = serializedObject.FindProperty("gridHeight");
        cellSize = serializedObject.FindProperty("cellSize");
        gridObjectPrefab = serializedObject.FindProperty("gridObjectPrefab");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if(GUILayout.Button("Generate Grid"))
        {
            _target.GenerateGrid();
        }

    }
}
