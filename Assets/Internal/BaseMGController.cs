using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public abstract class BaseMGController : MonoBehaviour
{
    [SerializeField] GameManager.UILocation uiLocation = default;
    protected GameManager gameManager;

    protected virtual void Awake()
    {
        GameData.DebugLog("[BageMGController] Awake()");
        GameData.DebugLog("[BageMGController] Instantiating GameManager");
        GameObject gm = Resources.Load("GameManager") as GameObject;
        gameManager = Instantiate(gm).GetComponent<GameManager>();
        gameManager.SetUI(uiLocation);
        GameData.DebugLog("[BageMGController] Registering delagates");
        GameManager.loseGameDelegate += EndGame;
        GameManager.winGameDelegate += WinGame;
    }

    private void OnDisable()
    {
        GameData.DebugLog("[BageMGController] OnDisable()");
        //SceneManager.sceneLoaded -= GameManager.Initialize;
        GameData.DebugLog("[BageMGController] De-registering delegates");
        GameManager.loseGameDelegate -= EndGame;
        GameManager.winGameDelegate -= WinGame;
    }


    protected abstract void WinGame();
    protected abstract void EndGame();
}
