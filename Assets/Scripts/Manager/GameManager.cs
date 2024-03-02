using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private ScriptableEvent stateChange;
    [SerializeField] private ScriptableEvent OnGamePaused;
    [SerializeField] private ScriptableEvent OnGameUnpaused;

    private  enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }

    private State state;
    private float waitingToStartTimer = 1f;
    private float countdownToStartTimer = 3f;
    private float gameplayingTimer = 300;
    private bool isGamePaused = false;

    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }

    private void Update()
    {
        // Game is divided into different states
        // depending on the state, different events are called, such as hiding or showing different UI elements
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime; 
                if (waitingToStartTimer < 0f)
                {
                    state = State.CountdownToStart;
                    stateChange.RaiseEvent();
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                    stateChange.RaiseEvent();
                }
                break;
            case State.GamePlaying:
                gameplayingTimer -= Time.deltaTime;
                if (gameplayingTimer < 0f)
                {
                    state = State.GameOver;
                    stateChange.RaiseEvent();
                }
                break;
            case State.GameOver:
                break;
        }
    }

    public void TogglePause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // can pause/unpause, because the state gets flipped with the same input
            isGamePaused = !isGamePaused;
            if (isGamePaused)
            {
                // Game is frozen while Game is Paused
                Time.timeScale = 0f;
                OnGamePaused.RaiseEvent();
            }
            else
            {
                // Game continues when game is unpaused 
                Time.timeScale = 1f;
                OnGameUnpaused.RaiseEvent();
            }
        }
    }

    public bool isGameInPlayingState()
    {
        return state == State.GamePlaying;
    }

    public bool isGameInCountdownState() 
    {
        return state == State.CountdownToStart;
    }

    public bool isGameInGameOverState() 
    {
        return state == State.GameOver;
    }

    public float GetCountdownToStartTimer()
    {
        return countdownToStartTimer;
    }

    public float GetGamePlayingTimer()
    {
        return gameplayingTimer;
    }

    public void SetGamePlayingTimer(float timer)
    {
        gameplayingTimer = timer;
    }
}
