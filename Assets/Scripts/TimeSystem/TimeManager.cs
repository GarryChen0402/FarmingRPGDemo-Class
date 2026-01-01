using UnityEngine;

public class TimeManager : SingletonMonoBehaviour<TimeManager>
{
    private int gameYear = 1;
    private Season gameSeason = Season.Spring;
    private int gameDay = 1;
    private int gameHour = 6;
    private int gameMinute = 30;
    private int gameSecond = 0;
    private string gameDayOfWeek = "Mon";

    private bool gameClockPaused = false;

    private float gameTick = 0f;

    private void Start()
    {
        EventHandler.CallAdvanceGameMinuteEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
    }

    private void Update()
    {
        if (!gameClockPaused) GameTick();
    }

    private void GameTick()
    {
        gameTick += Time.deltaTime;
        if(gameTick >= Settings.secondsPerGameSecond)
        {
            gameTick -= Settings.secondsPerGameSecond;
            UpdateGameSecond();
        }
    }

    private void UpdateGameSecond()
    {
        gameSecond++;

        if(gameSecond > 59)
        {
            gameSecond = 0;
            gameMinute++;

            if(gameMinute > 59)
            {
                gameMinute = 0;
                gameHour++;

                if(gameHour > 23)
                {
                    gameHour = 0;
                    gameDay++;

                    if (gameDay > 30)
                    {
                        gameDay = 1;
                        int gs = (int)gameSeason;
                        gs++;
                        gameSeason = (Season)gs;

                        if(gs > 3)
                        {
                            gs = 0;
                            gameSeason = (Season)gs;

                            gameYear++;
                            EventHandler.CallAdvanceGameYearEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
                        }

                        EventHandler.CallAdvanceGameSeasonEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
                    }
                    gameDayOfWeek = GetDayOfWeek();
                    EventHandler.CallAdvanceGameDayEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
                }
                EventHandler.CallAdvanceGameHourEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
            }
            EventHandler.CallAdvanceGameMinuteEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
            Debug.Log("Game Year: " + gameYear + "  Game Season: " + gameSeason + "  Game Day: " + gameDay + "  GameHour: " + gameHour +
                "  Game Minute: " + gameMinute);
        }
    }

    private string GetDayOfWeek()
    {
        //throw new System.NotImplementedException();
        int dayOfWeek = ((((int)gameSeason) * 30) + gameDay) % 7;
        string ans = null;
        switch (dayOfWeek)
        {
            case 0:
                ans = "Sun";
                break;
            case 1:
                ans = "Mon";
                break;
            case 2:
                ans = "Tue";
                break;
            case 3:
                ans = "Wed";
                break;
            case 4:
                ans = "Thu";
                break;
            case 5:
                ans = "Fri";
                break;
            case 6:
                ans = "Sat";
                break;
            default:
                ans = "Error day";
                break;
        }
        return ans;
    }
}
