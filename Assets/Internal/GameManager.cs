using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* ----------------------------------------------------------------- //
// Esse código não deve ser alterado, caso precise ser feito algum   //
// ajuste, entrar em contato com o professor da disciplina.          //
// ----------------------------------------------------------------- */

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
    public delegate void MicrogameDelegate();
    public static MicrogameDelegate microgameDelegate;

    // Delegate que será usado quando jogador perder partida
    public delegate void EndMicrogameDelegate();
    public static EndMicrogameDelegate endMicrogameDelegate;

    public static Text Text;    // Texto central no Canvas principal

    #endregion

    #region Master UI Controlls
    public enum UILocation { UP, DOWN, LEFT, RIGHT};

    [SerializeField] private GameObject _up = default;
    [SerializeField] private GameObject _down = default;
    [SerializeField] private GameObject _right = default;
    [SerializeField] private GameObject _left = default;

    private Slider slider;
    private float startTime;

    private int vidas = 3;  // Número de vidas do jogador

    // ativa e reseta a barra de tempo
    public void SetUI(UILocation location)
    {

        GameObject barra;

        switch (location)
        {
            case UILocation.DOWN:
                barra = _down;
                break;
            case UILocation.LEFT:
                barra = _left;
                break;
            case UILocation.RIGHT:
                barra = _right;
                break;
            default: //case UILocation.UP:
                barra = _up;
                break;
        }

        barra.SetActive(true);
        barra.GetComponentInChildren<Text>().text = "Vidas\n" + GameData.lives;
        slider = barra.GetComponentInChildren<Slider>();

        slider.maxValue = 1;
        slider.minValue = 0;
        slider.gameObject.SetActive(false);

    }

    #endregion

    #region UnityScriptLifecycle

    // Quando o GameManager inicia
    private void Start()
    {
        GameData.DebugLog("[Game Manager] OnEnable");
        GameData.lost = false;
        
        startTime = Time.time;

        Text = gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Text>();
        Button btn = gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Button>();
        
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        // Caso seja a cena principal (aquela que chama os microgames)
    	if (buildIndex==0) {
            btn.gameObject.SetActive(true);
            if (GameData.lives > 0) {
                Text.text = "Microjogos";
                btn.GetComponentInChildren<Text>().text = "Começar";
                btn.onClick.AddListener(StartGame);
            } else {
                Text.text = "Fim";
                btn.GetComponentInChildren<Text>().text = "Reiniciar";
                btn.onClick.AddListener(ResetGame);
            }
        } else {
            btn.gameObject.SetActive(false);
            StartCoroutine(TimeControl());
        }
    }

    // Inicia e define o número de vidas do jogador
    private void StartGame() {
        GameData.reset(vidas);
        LoadNext();
    }

    // Reinicia o número de vidas do jogador
    void ResetGame()
    {
        GameData.reset(vidas);
        SceneManager.LoadScene(0);
    }

    // Ao fim do quadro preparado
    private void LateUpdate()
    {
        // Atualiza a barra de tempo
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        if (buildIndex>0 && slider.gameObject.activeSelf) {
            float timeLeft = (Time.time - startTime) / GameData.GetTime();
            slider.value = timeLeft;
        }
    }
    #endregion

    // Assim que carregado, inicializa esta corrotina para controlar o tempos dos microjogos
    // Introdução (2s)> Jogo (5s max) > Ganhar ou Perder(3s)
    IEnumerator TimeControl()
    {        

        //Chama implementação do início do jogo.
        GameData.DebugLog($"[GameManager] TimeControl() Will Call StartMicrogameDelegate()");
        GameManager.Text.text = "";
        startMicrogameDelegate();
        yield return new WaitForSecondsRealtime(introTime);
        
        GameManager.Text.text = "";
        microgameDelegate();
        ShowTimer();
        GameData.DebugLog($"[GameManager] TimeControl() Waiting game time {GameData.GetTime()}s");
        yield return new WaitForSecondsRealtime(GameData.GetTime());

        GameManager.Text.text = "";
        endMicrogameDelegate();
        yield return new WaitForSecondsRealtime(outroTime);
        if (GameData.lost)
        {
            LostMicrogame();
        }
        else
        {
            LoadNext();
        }

    }

    // Mostra o slider de tempo
    void ShowTimer()
    {
        slider.gameObject.SetActive(true);
        startTime = Time.time;
    }  

    // Carrega o próximo microjogo
    void LoadNext()
    {
        int nextScene;
        do
        {
            int max = SceneManager.sceneCountInBuildSettings;
            nextScene = Random.Range(1, max);
        } while (!GameData.CanLoadScene(nextScene));

        GameData.DebugLog("[GameManager] Will load next scene");
        SceneManager.LoadScene(nextScene);
    }

    // Caso o jogador tenha perdido a partida
    void LostMicrogame()
    {
        GameData.lives--;
        if (GameData.lives <= 0)
        {
            EndGame();
            return;
        }
        LoadNext();
    }

    // Caso o número de vidas tenha acabado
    void EndGame()
    {
        GameData.DebugLog("[GameManager] Will load end game scene");
        SceneManager.LoadScene(0); //Cena para o fim do jogo deve ter id 0 no build settings
    }

}
