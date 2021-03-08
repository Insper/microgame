using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    #region GameManagement
    public delegate void WinGameDelegate();
    public static WinGameDelegate winGameDelegate;

    public delegate void LoseGameDelegate();
    public static LoseGameDelegate loseGameDelegate;
    #endregion

    public enum UILocation { UP, DOWN, LEFT, RIGHT};

    [SerializeField] private GameObject _up;
    [SerializeField] private GameObject _down;
    [SerializeField] private GameObject _right;
    [SerializeField] private GameObject _left;

    private Slider slider;

    private float startTime;

    private void OnEnable()
    {
        GameData.DebugLog("[Game Manager] OnEnable");
        GameData.lost = false;
        GetComponentInChildren<Text>().text = GameData.GetTime().ToString();
        startTime = Time.time;
        StartCoroutine(LoadNext());
    }

    private void LateUpdate()
    {
        float timeLeft = (Time.time - startTime) / GameData.GetTime();
        slider.value = timeLeft;
        Debug.Log(slider.gameObject.transform.parent.name);
        Debug.Log(timeLeft);
    }

    public void SetUI(UILocation location)
    {
        switch (location)
        {
            case UILocation.UP:
                _up.SetActive(true);
                slider = _up.GetComponentInChildren<Slider>();
                break;
            case UILocation.DOWN:
                _down.SetActive(true);
                slider = _down.GetComponentInChildren<Slider>();
                break;
            case UILocation.LEFT:
                _left.SetActive(true);
                slider = _left.GetComponentInChildren<Slider>();
                break;
            case UILocation.RIGHT:
                _right.SetActive(true);
                slider = _right.GetComponentInChildren<Slider>();
                break;
        }
        slider.maxValue = 1;
        slider.minValue = 0;
    }

   IEnumerator LoadNext()
    {
        GameData.DebugLog("[GameManager] LoadNext() Started");
        yield return new WaitForSecondsRealtime(GameData.GetTime());
        if (GameData.lost)
        {
            StartCoroutine(EndGame());
            yield break;
        }
        int nextScene;
        GameData.DebugLog("[GameManager] Will call WinGameDelegate()");
        winGameDelegate();
        yield return new WaitForSecondsRealtime(1.0f);
        
        do
        {
            int max = SceneManager.sceneCountInBuildSettings;
            nextScene = Random.Range(2, max);
        } while (!GameData.CanLoadScene(nextScene));

        GameData.DebugLog("[GameManager] Will load next scene");
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator EndGame()
    {
        GameData.DebugLog("[Game Manager] EndGame() Started");
        GameData.DebugLog("[GameManager] Will call EndGameDelegate()");
        loseGameDelegate();
        yield return new WaitForSecondsRealtime(1.0f);
        GameData.DebugLog("[GameManager] Will load end game scene");
        SceneManager.LoadScene(1);
    }


}
