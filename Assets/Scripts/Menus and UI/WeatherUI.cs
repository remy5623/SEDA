using TMPro;
using UnityEngine;

public class WeatherUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tornadoText;
    [SerializeField] TextMeshProUGUI thunderstormText;
    [SerializeField] TextMeshProUGUI floodText;

    private void Update()
    {
        if (Inventory.IsTornadoActive())
        {
            tornadoText.enabled = true;
            thunderstormText.enabled = true;
            floodText.enabled = true;
        }
        else if (Inventory.IsThunderstormActive())
        {
            tornadoText.enabled = false;
            thunderstormText.enabled = true;
            floodText.enabled = false;
        }
        else if (Inventory.IsFloodActive())
        {
            tornadoText.enabled = false;
            thunderstormText.enabled = false;
            floodText.enabled = true;
        }
        else
        {
            tornadoText.enabled = false;
            thunderstormText.enabled = false;
            floodText.enabled= false;
        }
    }
}
