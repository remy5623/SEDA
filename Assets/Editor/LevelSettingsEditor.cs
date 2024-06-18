// Remy Pijuan, 2024

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelSettings))]
public class LevelSettingsEditor : Editor
{
    SerializedProperty levelTime;

    private void OnEnable()
    {
        levelTime = serializedObject.FindProperty("levelTimeStore");
    }

    public override void OnInspectorGUI()
    {
        EditorGUIUtility.labelWidth = 300;
        EditorGUILayout.PropertyField(levelTime, new GUIContent("Time Taken By Level (months)"));
        serializedObject.ApplyModifiedProperties();
    }
}