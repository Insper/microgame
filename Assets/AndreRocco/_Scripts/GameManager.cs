using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace AndreRocco
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameState GameState;
        private MicrogameInternal.GameManager gm;
        public Text WL;
        public GameObject EnemyGun;
        public bool Failed = false;
        public static float shootWindow;



        void Awake()
        { 
            gm = MicrogameInternal.GameManager.GetInstance();
            Instance = this;
            ChangeState(GameState.Countdown);

            Countdown.minRandom = (gm.MaxTime - 1) / 6;
            Countdown.maxRandom = (gm.MaxTime - 1) / 3;

            if (gm.ActiveLevel <= 2)
            {
                shootWindow = 1f;
            }
            else if (gm.ActiveLevel > 2 && gm.ActiveLevel <= 4)
            {
                shootWindow = 0.5f;
            }
            else if (gm.ActiveLevel > 4)
            {
                shootWindow = 0.25f;
            }
            Debug.Log(Countdown.minRandom);
            Debug.Log(Countdown.maxRandom);

            ChangeState(GameState.Countdown);
        }

        void Start()
        {
            //ChangeState(GameState.Countdown);
        }

        IEnumerator Fail()
        {
            yield return new WaitForSeconds(shootWindow);
            if (GameManager.Instance.GameState == GameState.Shoot)
            {
                GameManager.Instance.ChangeState(GameState.Fail);
            }
        }

        public void ChangeState(GameState newState)
        {
            GameState = newState;
            switch (newState)
            {
                case GameState.Countdown:
                    gm.StartTimer();
                    break;
                case GameState.Shoot:
                    WL.text = "";
                    StartCoroutine(Fail());
                    break;
                case GameState.Fail:
                    EnemyGun.SetActive(true);
                    Failed = true;
                    WL.text = "FAIL!!";
                    gm.GameLost();
                    break;
                case GameState.Win:
                    WL.text = "WIN!!";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
        }
    }
}

namespace AndreRocco
{
    public enum GameState
    {
        Countdown = 0,
        Shoot = 1,
        Fail = 2,
        Win = 3
    }
}