using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private TextMeshProUGUI seasonText;
    [SerializeField] private TextMeshProUGUI yearText;

    private void OnEnable()
    {
        EventHandler.AdvanceGameMinuteEvent += UpdateGameTime;
    }

    private void OnDisable()
    {
        EventHandler.AdvanceGameMinuteEvent -= UpdateGameTime;
    }

    private void UpdateGameTime(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        //throw new System.NotImplementedException();
        gameMinute = gameMinute - (gameMinute % 10);
        string ampm = "am";
        string minute = gameMinute.ToString();  
        if (gameHour >= 12)ampm = "pm";

        if (gameHour >= 13) gameHour -= 12;
        if (gameMinute == 0)minute = "00";

        string time = gameHour.ToString() + " : " + minute + ampm;

        if (gameHour < 10) time = "0" + time;


        timeText.SetText(time);
        dateText.SetText(gameDayOfWeek + ". " + gameDay.ToString());
        seasonText.SetText(gameSeason.ToString());
        yearText.SetText("Year: " + gameYear);
    }


}