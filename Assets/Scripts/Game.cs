using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;
    public ReadOuts ReadOuts;
    public Paddle Paddle;
    public Ball Ball;

    private Levels Levels;
    private int ballsRemaining = 3;
    private int score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
        Levels = gameObject.GetComponent<Levels>();
    }

    private void Start()
    {
        Reset();
    }

    public void LoseBall()
    {
        Ball.CreateDeathEffect();
        Sounds.Instance.PlayLoseBall();
        DisableGameplay();
        UpdateNumberOfBalls(ballsRemaining -= 1);
        CheckForGameOver();
    }

    public void DisableGameplay()
    {
        Paddle.Disable();
        Ball.Disable();
    }
    public void BrickBreak()
    {
        UpdateScore(score + 10);
        CheckIfWon();
    }

    private void CheckIfWon()
    {
        if (CountBricks() == 0)
        {
            DisableGameplay();
            Levels.GoToNextLevel();
            if (Levels.IsGameOver())
                WinGame();
            else
                ResetAfterBallLoss();
        }
    }

    private void WinGame()
    {
        ReadOuts.ShowWinResult();
    }

    private void CheckForGameOver()
    {
        if (ballsRemaining == 0)
            LoseGame();
        else
            ResetAfterBallLoss();
    }

    private void LoseGame()
    {
        ReadOuts.ShowLoseResult();
        Sounds.Instance.PlayGameOver();
    }

    private void Reset()
    {
        ballsRemaining = 3;
        score = 0;
        ReadOuts.Reset(ballsRemaining);
        Sounds.Instance.PlayStart();
    }

    private void ResetAfterBallLoss()
    {
        Paddle.Reset();
        Ball.Reset();
    }

    private void UpdateNumberOfBalls(int numberOfBalls)
    {
        ballsRemaining = numberOfBalls;
        ReadOuts.ShowBallsRemaining(ballsRemaining);
    }
    private void UpdateScore(int newScore)
    {
        score = newScore;
        ReadOuts.ShowScore(score);
    }

    private int CountBricks()
    {
        return GameObject.FindGameObjectsWithTag("Brick").Length - 1;
    }
}
