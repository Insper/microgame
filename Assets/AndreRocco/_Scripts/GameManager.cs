using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;
    public Text WL;
    public GameObject EnemyGun;
    public bool Failed = false;

    void Awake()
    {
        Instance = this;
        ChangeState(GameState.Countdown);
    }

    void Start()
    {
        ChangeState(GameState.Countdown);
    }

    IEnumerator Fail()
    {
        yield return new WaitForSeconds(0.5f);
        if (GameManager.Instance.GameState == GameState.Shoot)
        {
            GameManager.Instance.ChangeState(GameState.Fail);
        }
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
                WL.text = "";
                StartCoroutine(Fail());
                break;
            case GameState.Fail:
                EnemyGun.SetActive(true);
                Failed = true;
                WL.text = "FAIL!!";
                break;
            case GameState.Win:
                WL.text = "WIN!!";
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
