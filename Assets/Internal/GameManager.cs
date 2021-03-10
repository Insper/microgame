using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    #region GameManagement

        // Delegate que será usado quando jogador ganhar partida
        public delegate void WinMicrogameDelegate();
        public static WinMicrogameDelegate winMicrogameDelegate;

        // Delegate que será usado quando jogador perder partida
        public delegate void LoseMicrogameDelegate();
        public static LoseMicrogameDelegate loseMicrogameDelegate;
        
    #endregion

    public enum UILocation { UP, DOWN, LEFT, RIGHT};

    [SerializeField] private GameObject _up = default;
    [SerializeField] private GameObject _down = default;
    [SerializeField] private GameObject _right = default;
    [SerializeField] private GameObject _left = default;


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

    }

    // carrega a próxima cena
    IEnumerator LoadNext()
    {
        GameData.DebugLog("[GameManager] LoadNext() Started");
        yield return new WaitForSecondsRealtime(GameData.GetTime());

        // caso as vidas tenham acabado, termina o jogo
        if (GameData.lost)
        {
            StartCoroutine(EndMicrogame());
            yield break;
        }

        int nextScene;
        GameData.DebugLog("[GameManager] Will call WinMicrogameDelegate()");
        winMicrogameDelegate();
        yield return new WaitForSecondsRealtime(1.0f);
        
        do
        {
            int max = SceneManager.sceneCountInBuildSettings;
            nextScene = Random.Range(2, max);
        } while (!GameData.CanLoadScene(nextScene));

        GameData.DebugLog("[GameManager] Will load next scene");
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator EndMicrogame()
    {
        GameData.DebugLog("[Game Manager] EndMicrogame() Started");
        GameData.DebugLog("[GameManager] Will call EndMicrogameDelegate()");
        loseMicrogameDelegate();
        yield return new WaitForSecondsRealtime(1.0f);
        GameData.DebugLog("[GameManager] Will load end game scene");
        SceneManager.LoadScene(1);
    }


}
