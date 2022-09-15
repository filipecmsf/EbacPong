using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public BaseBallController ball;

    public static GameManager instance;

    public GameObject introduction;
    public GameObject welcomeGameObject;
    public TextMeshProUGUI endGameObject;
    public GameObject gameElements;

    private Game game;

    [Header("Game Variables")]
    public int maxScore;

    [Header("Player Variables")]
    public PlayerController player1;
    public Player player1Entity;
    public TextMeshProUGUI player1Score;

    public PlayerController player2;
    public Player player2Entity;
    public TextMeshProUGUI player2Score;

    [Header("Settings Variables")]
    public PlayerSettingsController player1Settings;
    public PlayerSettingsController player2Settings;
    public GameObject startGameButton;
    public GameObject resetGameButton;
    public StateMachine stateMachine;

    [Header("Trigger Variables")]
    public TriggerController player1Trigger;
    public TriggerController player2Trigger;

    // setup functions
    private void Awake()
    {
        instance = this;
        InitialState();
    }

    private void SetupGameModel()
    {
        game = new Game(maxScore: maxScore, stateMachine: stateMachine);
        game.shouldUpdatePlayer1Score = UpdatePlayer1Score;
        game.shouldUpdatePlayer2Score = UpdatePlayer2Score;

        game.player1Won = Player1Won;
        game.player2Won = Player2Won;
    }

    private void InitialState()
    {
        ShowMenu(show: true);
        introduction.SetActive(true);
        welcomeGameObject.SetActive(true);
        startGameButton.SetActive(true);

        endGameObject.gameObject.SetActive(false);
        resetGameButton.SetActive(false);

        SetupGameModel();
    }

    // state functions
    public void ResetBallPosition()
    {
        ball.ResetBall();
    }

    public void StartGame()
    {
        player1.UpdateColor(player1Settings.GetCustomColor());
        player2.UpdateColor(player2Settings.GetCustomColor());

        ShowMenu(show: false);
        ball.CanMode(state: true);
    }

    public void ResetGame()
    {
        SetupGameModel();
        ResetBallPosition();
        InitialState();
    }

    public void EndGameSetup()
    {
        ball.CanMode(state: false);
        ShowMenu(show: true);
        startGameButton.SetActive(false);
        resetGameButton.SetActive(true);
        welcomeGameObject.SetActive(false);
        endGameObject.text = PlayerPrefs.GetString(Constants.lastPlayerWhoWon, "");
        endGameObject.gameObject.SetActive(true);

    }

    private void ShowMenu(bool show)
    {
        introduction.SetActive(show);
        gameElements.SetActive(!show);
    }

    // Score functions
    public void UpdateScore(bool player1Scored)
    {
        if (player1Scored)
        {
            game.Player1Score();
        } else
        {
            game.Player2Score();
        }
    }

    public void UpdatePlayer1Score()
    {
        player1Score.text = game.getPlayer1Score().ToString();
    }

    public void UpdatePlayer2Score()
    {
        player2Score.text = game.getPlayer2Score().ToString();
    }

    public void Player1Won()
    {
        PlayerPrefs.SetString(Constants.lastPlayerWhoWon, player1Settings.GetName());
    }

    public void Player2Won()
    {
        PlayerPrefs.SetString(Constants.lastPlayerWhoWon, player2Settings.GetName());
    }
}
