using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{


    List<Scores> highscore;
    GUIStyle headerStyle = new GUIStyle();
    GUIStyle contentStyle = new GUIStyle();

    public static bool displayScore;

    void Start()
    {
        highscore = new List<Scores>();
        highscore = HighScoreManager._instance.GetHighScore();

        headerStyle.fontSize = 65;
        headerStyle.normal.textColor = Color.white;

        contentStyle.fontSize = 50;
        contentStyle.normal.textColor = Color.yellow;

        displayScore = false;
    }


    public void DisplayScoreToggle()
    {
        displayScore = !displayScore;
    }

    void OnGUI()
    {
        if (displayScore)
        {
            //change the font size
            //GUILayout.Label("Write your text here.", guiStyle);

            //GUILayout.BeginHorizontal();
            //GUILayout.Label("Name :");
            //name = GUILayout.TextField(name);
            //GUILayout.EndHorizontal();

            //GUILayout.BeginHorizontal();
            //GUILayout.Label("Score :");
            //score = GUILayout.TextField(score);
            //GUILayout.EndHorizontal();

            //if (GUILayout.Button("Add Score"))
            //{
            //    HighScoreManager._instance.SaveHighScore(name, "time", 25, System.Int32.Parse(score));
            //    highscore = HighScoreManager._instance.GetHighScore();
            //}

            //if (GUILayout.Button("Get LeaderBoard"))
            //{
            //    highscore = HighScoreManager._instance.GetHighScore();
            //}

            //if (GUILayout.Button("Clear Leaderboard"))
            //{
            //    HighScoreManager._instance.ClearLeaderBoard();
            //}

            GUILayout.Space(250);


            GUILayout.BeginHorizontal();
            GUILayout.Label("", headerStyle, GUILayout.Width(Screen.width / 5));
            GUILayout.Label("Name", headerStyle, GUILayout.Width(Screen.width / 5));
            GUILayout.Label("Time", headerStyle, GUILayout.Width(Screen.width / 5));
            GUILayout.Label("Coins", headerStyle, GUILayout.Width(Screen.width / 8));
            GUILayout.Label("Scores", headerStyle, GUILayout.Width(Screen.width / 6));
            GUILayout.EndHorizontal();

            GUILayout.Space(25);

            foreach (Scores _score in highscore)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("", headerStyle, GUILayout.Width(Screen.width / 5));
                GUILayout.Label(_score.name, contentStyle, GUILayout.Width(Screen.width / 5));
                GUILayout.Label("" + _score.time, contentStyle, GUILayout.Width(Screen.width / 5));
                GUILayout.Label(" " + _score.coins, contentStyle, GUILayout.Width(Screen.width / 8));
                GUILayout.Label(" " + _score.score, contentStyle, GUILayout.Width(Screen.width / 6));
                GUILayout.EndHorizontal();
            }
        }
    }
}
