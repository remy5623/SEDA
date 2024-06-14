using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(GridObject))]
[CanEditMultipleObjects]
public class GridObjectEditor : Editor
{
    GridObject _target;

    SerializedProperty terrainPrefab;
    SerializedProperty buildingPrefab;

    void OnEnable()
    {
        _target = (GridObject)target;

        terrainPrefab = serializedObject.FindProperty("terrainPrefab");
        buildingPrefab = serializedObject.FindProperty("buildingPrefab");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if(GUILayout.Button("Generate Child Objects"))
        {
            //_target.GenerateChildObjects();
        }

    }
}
