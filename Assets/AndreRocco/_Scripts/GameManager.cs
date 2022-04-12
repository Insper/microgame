using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    void Awake()
    {
        Instance = this;
        ChangeState(GameState.Countdown);
    }

    void Start()
    {
        ChangeState(GameState.Countdown);
    }

    public void ChangeState(GameState newState)
    {
        //Debug.Log(newState);
        GameState = newState;
        switch (newState)
        {
            case GameState.Countdown:
                Debug.Log("countdown state");
                break;
            case GameState.Shoot:
                Debug.Log("shoot state");
                break;
            case GameState.Fail:
                Debug.Log("Fail state");
                break;
            case GameState.Win:
                Debug.Log("Win state");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}
public enum GameState
{
    Countdown = 0,
    Shoot = 1,
    Fail = 2,
    Win = 3
}
