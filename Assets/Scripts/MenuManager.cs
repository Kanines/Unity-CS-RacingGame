using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public Canvas BackgroundCanvas;
    public Canvas MainMenuCanvas;
    public Canvas StartMenuCanvas;
    public Canvas HighScoreCanvas;
    public Canvas GameCanvas;
    public Slider SteeringHelper;
    public Slider TractionControl;
    public Slider Acceleration;
    public Slider TopSpeed;
    public InputField PlayerName;

    public string sPlayerName;

    public GameObject TestLeaderboard;

    public void HighScore_Click()
    {
        HighScoreCanvas.enabled = true;
        HighScoreDisplay.displayScore = true;
        MainMenuCanvas.enabled = false;
    }

    public void HighScoreBack_Click()
    {
        HighScoreCanvas.enabled = false;
        HighScoreDisplay.displayScore = false;
        MainMenuCanvas.enabled = true;
    }

    public void StartMenu_Click()
    {
        StartMenuCanvas.enabled = true;
        MainMenuCanvas.enabled = false;
    }

    public void StartMenuBack_Click()
    {
        MainMenuCanvas.enabled = true;
        StartMenuCanvas.enabled = false;
    }

    public void StartMenuStartGame_Click()
    {
        StartMenuCanvas.enabled = false;
        BackgroundCanvas.enabled = false;
        GameCanvas.enabled = true;

        GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().SetParams(
            SteeringHelper.value, TractionControl.value, (int)Acceleration.value, (int)TopSpeed.value);

        //GameObject.Find("FinishLapTrigger").GetComponent<LapFinish>().SetPlayerName(PlayerName.text);
        GameObject.Find("Cameras").GetComponent<CameraStable>().StartDefaultCamera();
        GameObject.Find("LapTimerManager").GetComponent<LapTimerManager>().TimerToggle();

    }

    public void ExitGame_Click()
    {
        Application.Quit();
    }

    public string GetPlayerName()
    {
        return PlayerName.text;
    }

    public void ToggleLeaderboard()
    {
        TestLeaderboard.SetActive(!TestLeaderboard.activeSelf);
    }

    public void SetPlayerName()
    {
        //sPlayerName = PlayerName.text;
        LapFinish.PlayerName = PlayerName.text;
    }
}
