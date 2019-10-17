using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapFinish : MonoBehaviour
{

    public GameObject FinishLapTrigger;
    public GameObject HalfLapTrigger;

    public GameObject BestMinutesDisplay;
    public GameObject BestSecondsDisplay;
    public GameObject BestMilisDisplay;

    public static string PlayerName = "Anonymous";


    private void OnTriggerEnter(Collider other)
    {
        int currentBest = LapTimerManager.BestMinutes * 10000 + LapTimerManager.BestSeconds * 100 + (int)LapTimerManager.BestMilis;
        int newTime = LapTimerManager.Minutes * 10000 + LapTimerManager.Seconds * 100 + (int)LapTimerManager.Milis;

        if (newTime < currentBest || currentBest == 0)
        {
            if (LapTimerManager.Seconds <= 9)
            {
                BestSecondsDisplay.GetComponent<Text>().text = "0" + LapTimerManager.Seconds + ".";
            }
            else
            {
                BestSecondsDisplay.GetComponent<Text>().text = "" + LapTimerManager.Seconds + ".";
            }

            if (LapTimerManager.Minutes <= 9)
            {
                BestMinutesDisplay.GetComponent<Text>().text = "0" + LapTimerManager.Minutes + ":";
            }
            else
            {
                BestMinutesDisplay.GetComponent<Text>().text = "" + LapTimerManager.Minutes + ":";
            }

            if (LapTimerManager.Milis <= 9)
            {
                BestMilisDisplay.GetComponent<Text>().text = "0" + LapTimerManager.Milis;
            }
            else
            {
                BestMilisDisplay.GetComponent<Text>().text = "" + LapTimerManager.Milis;
            }

            LapTimerManager.BestMinutes = LapTimerManager.Minutes;
            LapTimerManager.BestSeconds = LapTimerManager.Seconds;
            LapTimerManager.BestMilis = LapTimerManager.Milis;

        }

        if (LapTimerManager.Coins > LapTimerManager.BestScore)
            LapTimerManager.BestScore = LapTimerManager.Coins;


        int score = (50000000 / newTime) + LapTimerManager.Coins * 10;
        string time = LapTimerManager.Minutes.ToString() + ":" + LapTimerManager.Seconds.ToString()
            + "." + ((int)LapTimerManager.Milis).ToString();

        HighScoreManager._instance.SaveHighScore(PlayerName, time, LapTimerManager.Coins, score);


        LapTimerManager.Minutes = 0;
        LapTimerManager.Seconds = 0;
        LapTimerManager.Milis = 0;
        LapTimerManager.Coins = 0;


        HalfLapTrigger.SetActive(true);
        FinishLapTrigger.SetActive(false);
    }

    void Start()
    {
        //this.PlayerName = GameObject.Find("EventSystem").GetComponent<MenuManager>().GetPlayerName();
    }

    public void SetPlayerName (string name)
    {
        PlayerName = name;
    }
}
