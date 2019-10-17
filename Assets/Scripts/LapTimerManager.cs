using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimerManager : MonoBehaviour
{

    public static int Minutes;
    public static int Seconds;
    public static float Milis;

    public static int BestMinutes = 0;
    public static int BestSeconds = 0;
    public static float BestMilis = 0;

    public static string MilisDisplay;

    public static int Coins;
    public static int BestScore = 0;
    public GameObject MinutesBox;
    public GameObject SecondsBox;
    public GameObject MilisBox;
    public GameObject ScoreDisplay;
    public GameObject BestScoreDisplay;

    public bool isActive;


    void Start()
    {
        isActive = false;
    }

    void Update()
    {
        if (isActive)
        {

            Milis += Time.deltaTime * 100;
            MilisDisplay = Milis.ToString("F0");
            MilisBox.GetComponent<Text>().text = "" + MilisDisplay;

            if (Milis >= 100)
            {
                Milis = 0;
                Seconds++;
            }

            if (Seconds <= 9)
            {
                SecondsBox.GetComponent<Text>().text = "0" + Seconds + ".";

            }
            else
            {
                SecondsBox.GetComponent<Text>().text = "" + Seconds + ".";
            }

            if (Seconds >= 60)
            {
                Seconds = 0;
                Minutes++;
            }

            if (Minutes <= 9)
            {
                MinutesBox.GetComponent<Text>().text = "0" + Minutes + ":";

            }
            else
            {
                MinutesBox.GetComponent<Text>().text = "" + Minutes + ":";
            }

            ScoreDisplay.GetComponent<Text>().text = "" + Coins;
            BestScoreDisplay.GetComponent<Text>().text = "" + BestScore;
        }
    }

    public void TimerToggle()
    {
        isActive = !isActive;
    }

    public void ResetTimer()
    {
        Minutes = 0;
        Seconds = 0;
        Milis = 0;
        Coins = 0;
    }
}
