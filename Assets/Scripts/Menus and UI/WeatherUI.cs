using TMPro;
using UnityEngine;

public class WeatherUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tornadoText;
    [SerializeField] TextMeshProUGUI thunderstormText;
    [SerializeField] TextMeshProUGUI floodText;

    private void Update()
    {
        switch(Inventory.GetCurrentWeather())
        {
            case WeatherTypes.Tornado:
                tornadoText.gameObject.SetActive(true);
                thunderstormText.gameObject.SetActive(false);
                floodText.gameObject.SetActive(false);
                break;
            case WeatherTypes.Thunderstorm:
                tornadoText.gameObject.SetActive(false);
                thunderstormText.gameObject.SetActive(true);
                floodText.gameObject.SetActive(false);
                break;
            case WeatherTypes.Flood:
                tornadoText.gameObject.SetActive(false);
                thunderstormText.gameObject.SetActive(false);
                floodText.gameObject.SetActive(true);
                break;
            case WeatherTypes.Fair:
                tornadoText.gameObject.SetActive(false);
                thunderstormText.gameObject.SetActive(false);
                floodText.gameObject.SetActive(false);
                break;
        }
    }
}
