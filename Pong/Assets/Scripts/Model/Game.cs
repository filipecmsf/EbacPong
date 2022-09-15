using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private int maxScore;
    private int player1Score;
    private int player2Score;

    public Action player1Won;
    public Action player2Won;

    public Action shouldUpdatePlayer1Score;
    public Action shouldUpdatePlayer2Score;

    public StateMachine stateMachine;

    public Game(int maxScore, StateMachine stateMachine)
    {
        this.maxScore = maxScore;
        this.stateMachine = stateMachine;
        player1Score = 0;
        player2Score = 0;
    }

    public int getPlayer1Score()
    {
        return player1Score;
    }

    public int getPlayer2Score()
    {
        return player2Score;
    }

    public void Player1Score()
    {

        player1Score++;
        
        if (player1Score >= maxScore)
        {
            player1Won?.Invoke();
            stateMachine.EndGame();
        } else
        {
            shouldUpdatePlayer1Score?.Invoke();
        }
    }

    public void Player2Score()
    {
        player2Score++;
        
        if (player2Score >= maxScore)
        {
            player2Won?.Invoke();
            stateMachine.EndGame();
        } else
        {
            shouldUpdatePlayer2Score?.Invoke();
        }
    }
}
