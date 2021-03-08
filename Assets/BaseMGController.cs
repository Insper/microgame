using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public abstract class BaseMGController : MonoBehaviour
{

    protected void Awake()
    {
        Instantiate(Resources.Load("GameManager"));
        GameManager.loseGameDelegate += EndGame;
        GameManager.winGameDelegate += WinGame;
    }

    private void OnDisable()
    {
        //SceneManager.sceneLoaded -= GameManager.Initialize;
        GameManager.loseGameDelegate -= EndGame;
        GameManager.winGameDelegate -= WinGame;
    }


    protected abstract void WinGame();
    protected abstract void EndGame();
}
