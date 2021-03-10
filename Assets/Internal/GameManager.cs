using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    #region Times
    int introTime = 1;
    int outroTime = 1;
    #endregion

    #region GameManagement
    // Delegate que será usado quando o jogo começar
    public delegate void StartMicrogame();
    public static StartMicrogame startMicrogameDelegate;

    // Delegate que será usado quando jogador ganhar partida
    public delegate void WinMicrogameDelegate();
    public static WinMicrogameDelegate winMicrogameDelegate;

    // Delegate que será usado quando jogador perder partida
    public delegate void LoseMicrogameDelegate();
    public static LoseMicrogameDelegate loseMicrogameDelegate;

    #endregion

    #region Master UI Controlls
    public enum UILocation { UP, DOWN, LEFT, RIGHT};

    [SerializeField] private GameObject _up = default;
    [SerializeField] private GameObject _down = default;
    [SerializeField] private GameObject _right = default;
    [SerializeField] private GameObject _left = default;

    private Slider slider;
    private float startTime;

    // ativa e reseta a barra de tempo
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
        slider.gameObject.SetActive(false);

    }

    #endregion

    #region UnityScriptLifecycle
    private void OnEnable()
    {
        GameData.DebugLog("[Game Manager] OnEnable");
        GameData.lost = false;
        GetComponentInChildren<Text>().text = GameData.GetTime().ToString();
        startTime = Time.time;
        StartCoroutine(TimeControl());
    }

    private void LateUpdate()
    {
        float timeLeft = (Time.time - startTime) / GameData.GetTime();
        slider.value = timeLeft;
    }
    #endregion

    // Assim que carregado, inicializa esta corrotina para controlar o tempos dos microjogos
    // Introdução (2s)> Jogo (5s max) > Ganhar ou Perder(3s)
    IEnumerator TimeControl()
    {
        GameData.DebugLog($"[GameManager] TimeControll() waiting Intro time {introTime}s");
        yield return new WaitForSecondsRealtime(introTime);

        //Chama implementação do início do jogo.
        GameData.DebugLog($"[GameManager] TimeControl() Will Call StartMicrogameDelegate()");
        startMicrogameDelegate();
        ShowTimer();
        
        GameData.DebugLog($"[GameManager] TimeControl() Waiting game time {GameData.GetTime()}s");
        yield return new WaitForSecondsRealtime(GameData.GetTime());

        if (GameData.lost)
        {
            GameData.DebugLog("[GameManager] TimeControll() Will call EndMicrogameDelegate()");
            loseMicrogameDelegate();
            yield return new WaitForSecondsRealtime(outroTime);
            LostMicrogame();
        }
        else
        {
            GameData.DebugLog("[GameManager] Will call WinMicrogameDelegate()");
            winMicrogameDelegate();
            yield return new WaitForSecondsRealtime(outroTime);
            LoadNext();

        }

    }

    void ShowTimer()
    {
        startTime = Time.time;
        slider.gameObject.SetActive(true);
    }

    void LoadNext()
    {
        int nextScene;
        do
        {
            int max = SceneManager.sceneCountInBuildSettings;
            nextScene = Random.Range(2, max);
        } while (!GameData.CanLoadScene(nextScene));

        GameData.DebugLog("[GameManager] Will load next scene");
        SceneManager.LoadScene(nextScene);
    }

    void LostMicrogame()
    {
        GameData.lives--;
        if (GameData.lives < 0)
        {
            EndGame();
            return;
        }
        LoadNext();
    }

    void EndGame()
    {
        GameData.DebugLog("[GameManager] Will load end game scene");
        SceneManager.LoadScene(1); //Cena EndGame deve ter id 1 no build settings
    }


}
