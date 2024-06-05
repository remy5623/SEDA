// Remy Pijuan 2024

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
    }
}

public class Inventory : MonoBehaviour
{
    private static Inventory instance;

    public static int overworldTime;

    public static int food;
    public static int constructionMaterials;

    [SerializeField]
    [InspectorName("Initial Overworld Time (years)")]
    private int initialOverworldTime;

    /** The Inventory is a singleton
     *  There is only one Inventory active at any given time
     */
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            overworldTime = initialOverworldTime;
        }
        else
        {
            Destroy(this);
        }
    }
}
