// Remy Pijuan, 2024

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelManager))]
public class LevelManagerEditor : Editor
{
    SerializedProperty levelTime;

    // Level Success Conditions
    SerializedProperty successFoodAmount;
    SerializedProperty successConstructionMaterialsAmount;
    SerializedProperty successSoilHealth;

    private void OnEnable()
    {
        levelTime = serializedObject.FindProperty("levelTimeStore");

        successFoodAmount = serializedObject.FindProperty("successFoodAmount");
        successConstructionMaterialsAmount = serializedObject.FindProperty("successConstructionMaterialsAmount");
        successSoilHealth = serializedObject.FindProperty("successSoilHealth");
    }

    public override void OnInspectorGUI()
    {
        EditorGUIUtility.labelWidth = 300;
        EditorGUILayout.PropertyField(levelTime, new GUIContent("Time Taken By Level (months)"));

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Success Conditions", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(successFoodAmount);
        EditorGUILayout.PropertyField(successConstructionMaterialsAmount);
        EditorGUILayout.PropertyField(successSoilHealth);

        serializedObject.ApplyModifiedProperties();
    }
}
