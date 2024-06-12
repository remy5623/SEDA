// Remy Pijuan 2024

using System.Collections;
using System.Collections.Generic;
using TMPro;
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

public class Inventory : MonoBehaviour
{
    private static Inventory instance;

    public static int overworldTime;
    public static int levelTime;

    public static int food;
    public static int constructionMaterials;

    [SerializeField]
    [InspectorName("Initial Overworld Time (years)")]
    private int initialOverworldTime;

    [SerializeField] TextMeshProUGUI foodDisplay;
    [SerializeField] TextMeshProUGUI constructionMaterialDisplay;


    /** The Inventory is a singleton
     *  There is only one Inventory active at any given time
     */
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            overworldTime = initialOverworldTime;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        foodDisplay.text = "Food: " + food;
        constructionMaterialDisplay.text = "Construction Materials: " + constructionMaterials;
    }

    public static void SpendFood(int foodSpent)
    {
        food -= foodSpent;
        
        if (food < 0)
        {
            food = 0;
        }
    }

    public static void SpendMaterials(int materialSpent)
    {
        constructionMaterials -= materialSpent;

        if (constructionMaterials < 0)
        {
            constructionMaterials = 0;
        }
    }
}
