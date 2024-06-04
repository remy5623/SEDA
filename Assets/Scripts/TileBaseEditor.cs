using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
[CustomEditor(typeof(TileBase))]
public class TileBaseEditor : Editor
{
    //general
    SerializedProperty iD;
    SerializedProperty names;
    SerializedProperty icon;
    SerializedProperty mesh;
    SerializedProperty sizeWidth;
    SerializedProperty sizeLength;
    SerializedProperty structureTypes;
    SerializedProperty tileUnder;
    SerializedProperty biomesTypes;
    SerializedProperty tileTerrainTypes;

    //buildSection
    SerializedProperty canBuild;
    SerializedProperty buildTime;
    SerializedProperty buildingCostEnergy;
    SerializedProperty buildingCostFood;
    SerializedProperty buildingCostConstruction;
    SerializedProperty buildingUpgradeCostEnergy;
    SerializedProperty buildingUpgradeCostFood;
    SerializedProperty buildingUpgradeCostConstruction;
    SerializedProperty buildingUpgradeCostMulti;
    SerializedProperty buildingLevelIcon;
    SerializedProperty buildingCurrentLevel;
    SerializedProperty buildingLevelMax;

    //Resource
    SerializedProperty hasResourceOutput;
    SerializedProperty isResourceTapped;
    SerializedProperty baseOutputEnergy;

    SerializedProperty baseOutputFood;
    SerializedProperty baseOutputConstruction;
    SerializedProperty upKeepCostEnergy;
    SerializedProperty upKeepCostFood;
    SerializedProperty upKeepCostConstruction;
    SerializedProperty hasTileImpact;
    SerializedProperty impactRadiusTiles;
    SerializedProperty structureOfTypeInRadius;
    SerializedProperty transferResources;
    SerializedProperty buildingOutputMulti;
    SerializedProperty buildingLevelMulti;
    SerializedProperty buildingOutputStage;
    SerializedProperty buildingCalcOutput;
    
    //Impact
    SerializedProperty impactSource;
    SerializedProperty buffAmount;
    SerializedProperty nerfAmount;
    SerializedProperty tileImpactBuff;
    SerializedProperty tileImpactNerf;
    

    private void OnEnable()
    {
        //pre-loading the properties
        //General
        iD = serializedObject.FindProperty("iD");
        names = serializedObject.FindProperty("names");
        icon = serializedObject.FindProperty("icon");
        mesh = serializedObject.FindProperty("mesh");
        sizeWidth = serializedObject.FindProperty("sizeWidth");
        sizeLength = serializedObject.FindProperty("sizeLength");
        structureTypes = serializedObject.FindProperty("structureTypes");
        tileUnder = serializedObject.FindProperty("tileUnder");
        biomesTypes = serializedObject.FindProperty("biomesTypes");
        tileTerrainTypes = serializedObject.FindProperty("tileTerrainTypes");
        //Build
        canBuild = serializedObject.FindProperty("canBuild");
        buildTime = serializedObject.FindProperty("buildTime");
        buildingCostEnergy = serializedObject.FindProperty("buildingCostEnergy");
        buildingCostFood= serializedObject.FindProperty("buildingCostFood");
        buildingCostConstruction = serializedObject.FindProperty("buildingCostConstruction");
        buildingUpgradeCostEnergy= serializedObject.FindProperty("buildingUpgradeCostEnergy");
        buildingUpgradeCostFood= serializedObject.FindProperty("buildingUpgradeCostFood");
        buildingUpgradeCostConstruction = serializedObject.FindProperty("buildingUpgradeCostConstruction");
        buildingUpgradeCostMulti = serializedObject.FindProperty("buildingUpgradeCostMulti");
        buildingLevelIcon = serializedObject.FindProperty("buildingLevelIcon");
        buildingCurrentLevel = serializedObject.FindProperty("buildingCurrentlevel");
        buildingLevelMax = serializedObject.FindProperty("buildingLevelMax");
        //Resource
        hasResourceOutput = serializedObject.FindProperty("hasResourceOutput");
        hasTileImpact = serializedObject.FindProperty("hasTileImpact");
        isResourceTapped = serializedObject.FindProperty("isResourceTapped");
        baseOutputEnergy = serializedObject.FindProperty("baseOutputEnergy");
        baseOutputFood = serializedObject.FindProperty("baseOutputFood");
        baseOutputConstruction = serializedObject.FindProperty("baseOutputConstruction");
        upKeepCostEnergy = serializedObject.FindProperty("upKeepCostEnergy");
        upKeepCostFood = serializedObject.FindProperty("upKeepCostFood");
        upKeepCostConstruction = serializedObject.FindProperty("upKeepCostConstruction");
        impactRadiusTiles = serializedObject.FindProperty("impactRadiusTiles");
        structureOfTypeInRadius = serializedObject.FindProperty("structureOfTypeInRadius");
        transferResources = serializedObject.FindProperty("transferResources");
        buildingOutputMulti = serializedObject.FindProperty("buildingOutputMulti");
        buildingLevelMulti = serializedObject.FindProperty("buildingLevelMulti");
        buildingOutputStage = serializedObject.FindProperty("buildingOutputStage");
        buildingCalcOutput = serializedObject.FindProperty("buildingCalcOutput");
        //Impact
        impactSource = serializedObject.FindProperty("impactSource");
        buffAmount = serializedObject.FindProperty("buffAmount");
        nerfAmount = serializedObject.FindProperty("nerfAmount");
        tileImpactBuff = serializedObject.FindProperty("tileImpactBuff");
        tileImpactNerf = serializedObject.FindProperty("tileImpactNerf");

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        // Always visible properties
        EditorGUILayout.PropertyField(iD);
        EditorGUILayout.PropertyField(names);
        EditorGUILayout.PropertyField(icon);
        EditorGUILayout.PropertyField(mesh);
        EditorGUILayout.PropertyField(sizeWidth);
        EditorGUILayout.PropertyField(sizeLength);
        EditorGUILayout.PropertyField(structureTypes);
        EditorGUILayout.PropertyField(tileUnder);
        EditorGUILayout.PropertyField(biomesTypes);
        EditorGUILayout.PropertyField(tileTerrainTypes);
        //BoolValue
        EditorGUILayout.PropertyField(canBuild);

        // Conditional visible properties
        if (canBuild.boolValue)
        {
            //build
            EditorGUILayout.PropertyField(buildTime,true);
            EditorGUILayout.PropertyField(buildingCostEnergy,true);
            EditorGUILayout.PropertyField(buildingCostFood,true);
            EditorGUILayout.PropertyField(buildingCostConstruction,true);
            EditorGUILayout.PropertyField(buildingUpgradeCostEnergy,true);
            EditorGUILayout.PropertyField(buildingUpgradeCostFood,true);
            EditorGUILayout.PropertyField(buildingUpgradeCostConstruction,true);
            EditorGUILayout.PropertyField(buildingUpgradeCostMulti,true);
            EditorGUILayout.PropertyField(buildingLevelIcon,true);
            EditorGUILayout.PropertyField(buildingCurrentLevel,true);
            EditorGUILayout.PropertyField(buildingLevelMax,true);            
        }

        EditorGUILayout.PropertyField(hasResourceOutput);

        //Resource
        if (hasResourceOutput.boolValue)
        {
            EditorGUILayout.PropertyField(isResourceTapped,true);
            EditorGUILayout.PropertyField(baseOutputEnergy,true);
            EditorGUILayout.PropertyField(baseOutputFood,true);
            EditorGUILayout.PropertyField(baseOutputConstruction,true);
            EditorGUILayout.PropertyField(upKeepCostEnergy,true);
            EditorGUILayout.PropertyField(upKeepCostFood,true);
            EditorGUILayout.PropertyField(upKeepCostConstruction,true);
            EditorGUILayout.PropertyField(buildingOutputMulti,true);
            EditorGUILayout.PropertyField(buildingLevelMulti,true);
            EditorGUILayout.PropertyField(buildingOutputStage,true);
            EditorGUILayout.PropertyField(buildingCalcOutput,true);
        }

        EditorGUILayout.PropertyField(hasTileImpact);

        if (hasTileImpact.boolValue)
        {
            EditorGUILayout.PropertyField(impactRadiusTiles,true);
            EditorGUILayout.PropertyField(structureOfTypeInRadius,true);
            EditorGUILayout.PropertyField(transferResources,true);
            EditorGUILayout.PropertyField(impactSource,true);
            if(impactSource.boolValue)
            {
                EditorGUILayout.PropertyField(buffAmount,true);
                EditorGUILayout.PropertyField(nerfAmount,true);
                EditorGUILayout.PropertyField(tileImpactBuff,true);
                EditorGUILayout.PropertyField(tileImpactNerf,true);
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
}
