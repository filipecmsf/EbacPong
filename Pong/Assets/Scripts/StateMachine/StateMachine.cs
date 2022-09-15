using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        PLAYING,
        RESET_GAME,
        RESET_POSITION,
        END_GAME
    }

    public Dictionary<State, StateBase> dictState;
    private StateBase currentState;

    private void Awake()
    {
        dictState = new Dictionary<State, StateBase>();
        dictState.Add(State.PLAYING, new StatePlaying ());
        dictState.Add(State.RESET_GAME, new StateResetGame());
        dictState.Add(State.RESET_POSITION, new StateResetPosition());
        dictState.Add(State.END_GAME, new EndEnter());
    }

    public void SwitchState(State state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = dictState[state];
        currentState.OnStateEnter();
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.OnStateStay();
        }
    }

    public void StartGame()
    {
        SwitchState(state: State.PLAYING);
    }

    public void ResetGame()
    {
        SwitchState(state: State.RESET_GAME);
    }

    public void ResetPosition()
    {
        SwitchState(state: State.RESET_POSITION);
    }

    public void EndGame()
    {
        SwitchState(state: State.END_GAME);
    }
}
