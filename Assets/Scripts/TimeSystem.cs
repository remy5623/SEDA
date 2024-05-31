using TMPro;
using UnityEngine;

enum Month
{
    January,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December
}

public class TimeSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dayDisplay;
    [SerializeField] TextMeshProUGUI monthDisplay;

    int day = 1;
    float timeElapsed = 0f;

    Month month = Month.January;
    float numOfDaysInMonth = 30;

    int year = 1;

    // Update is called once per frame
    void Update()
    {
        // Timer
        timeElapsed += Time.deltaTime * 20;

        // Set day
        day = Mathf.FloorToInt(timeElapsed) + 1;    // Day starts at 1
        dayDisplay.text = day.ToString();

        // Set month
        SetMonth();
        monthDisplay.text = month.ToString();
    }

    /** Set month based on numofDaysInMonth */
    void SetMonth()
    {
        if (day > numOfDaysInMonth)
        {
            timeElapsed -= (day - 1);
            IncrementMonth();
        }
    }

    /** Increment month (and year), rolling over from December to January */
    void IncrementMonth()
    {
        month++;

        if (month > Month.December)
        {
            year++;
            month = Month.January;
        }

        AssignDaysInMonth();
    }


    /** Change the number of days per month */
    void AssignDaysInMonth()
    {
        if (month == Month.February)
        {
            if (year % 4 == 0) 
                numOfDaysInMonth = 29;
            else numOfDaysInMonth = 28;
        }
        else if (month == Month.January || month == Month.April || month == Month.June || month == Month.September || month == Month.November)
        {
            numOfDaysInMonth = 30;
        }
        else
        {
            numOfDaysInMonth = 31;
        }
    }
}
