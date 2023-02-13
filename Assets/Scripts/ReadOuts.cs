using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadOuts : MonoBehaviour
{
    public Text Score;
    public Text BallsRemaining;
    public Text Level;
    public Text GameResult;

    public void Reset(int startingNumberOfBalls)
    {
        ShowScore(0);
        ShowLevel(1);
        ShowBallsRemaining(startingNumberOfBalls);
        HideWinResult();
    }

    public void ShowScore(int score)
    {
        if (score < 0)
            score = 0;
        Score.text = "Score: " + score;
    }

    public void ShowLevel(int level)
    {
        if (level < 1)
            level = 1;
        Level.text = "Level: " + level;
    }

    public void ShowBallsRemaining(int ballsRemaining)
    {
        if (ballsRemaining < 0)
            ballsRemaining = 0;
        BallsRemaining.text = "Balls Remaining: " + ballsRemaining;
    }

    public void ShowLoseResult()
    {
        GameResult.text = "LOSE";
    }

    public void ShowWinResult()
    {
        GameResult.text = "WIN";
    }

    public void HideWinResult()
    {
        GameResult.text = "";
    }
}
