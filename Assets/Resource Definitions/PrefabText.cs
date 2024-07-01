using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class PrefabText : MonoBehaviour
{

    [SerializeField] private TMP_Text nameText;
    // Start is called before the first frame update
    void Start()
    {

        if (nameText == null)
        {
            // Set text properties
            GameObject textObject = new GameObject("Nametext");
            textObject.transform.SetParent(this.transform);
            nameText = textObject.AddComponent<TextMeshPro>();

            nameText.fontSize = 3;
            nameText.color = Color.black;
            nameText.alignment = TextAlignmentOptions.Center;
            nameText.fontWeight = FontWeight.Bold;

            textObject.transform.rotation = Quaternion.Euler(45f, 0f, 45f);

            textObject.transform.localPosition = new Vector3(0f, 0f, -1f);


        }
        // Remove "(Clone)" from the name if it exists (not work , idk why)

        string objectNmae = RemoveCloneSuffix(this.gameObject.name);
        nameText.text = objectNmae;

    }
    private void Update()
    {

    }

    private string RemoveCloneSuffix(string name)
    {
        const string cloneSuffix = "Clone";
        if (name.EndsWith(cloneSuffix))
        {
            return name.Substring(0, name.Length - cloneSuffix.Length).Trim();
        }
        return name;
    }
}
