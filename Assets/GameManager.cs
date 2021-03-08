using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region GameData
    public static bool gameLost;// { get; private set; }
    #endregion

    #region GameManagement
    public delegate void WinGameDelegate();
    public static WinGameDelegate winGameDelegate;

    public delegate void LoseGameDelegate();
    public static LoseGameDelegate loseGameDelegate;
    #endregion

    private void OnEnable()
    {
        Debug.Log("Enable");
        GameData.lost = false;
        GetComponentInChildren<Text>().text = GameData.GetTime().ToString();
        StartCoroutine(LoadNext());
    }


   IEnumerator LoadNext()
    {
        yield return new WaitForSecondsRealtime(GameData.GetTime());
        if (GameData.lost)
        {
            StartCoroutine(EndGame());
            yield break;
        }
        int nextScene;
        winGameDelegate();
        yield return new WaitForSecondsRealtime(1.0f);
        
        do
        {
            int max = SceneManager.sceneCountInBuildSettings;
            nextScene = Random.Range(2, max);
        } while (!GameData.CanLoadScene(nextScene));
        
        GameData.level++;
        Debug.Log(GameData.level);
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator EndGame()
    {
        loseGameDelegate();
        yield return new WaitForSecondsRealtime(1.0f);
        SceneManager.LoadScene(1);
    }


}
