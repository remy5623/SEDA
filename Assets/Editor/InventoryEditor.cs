// Remy Pijuan, 2024

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{
    SerializedProperty overworldTime;

    private void OnEnable()
    {
        overworldTime = serializedObject.FindProperty("initialOverworldTime");
    }

    public override void OnInspectorGUI()
    {
        EditorGUIUtility.labelWidth = 200;
        EditorGUILayout.PropertyField(overworldTime, new GUIContent("Initial Overworld Time (years)"));
        serializedObject.ApplyModifiedProperties();
    }
}