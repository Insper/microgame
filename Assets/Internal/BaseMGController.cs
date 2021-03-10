using UnityEngine;

// Classe base para os microjogos
public abstract class BaseMGController : MonoBehaviour
{

    // para definir a posição da barra de tempo
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

        GameManager.startMicrogameDelegate += StartMicrogame;

        // Registra métodos de derrota e vitória
        GameManager.loseMicrogameDelegate += EndMicrogame;
        GameManager.winMicrogameDelegate += WinMicrogame;
    }

    private void OnDisable()
    {
        GameData.DebugLog("[BageMGController] OnDisable()");

        GameData.DebugLog("[BageMGController] De-registering delegates");
        GameManager.startMicrogameDelegate -= StartMicrogame;
        GameManager.loseMicrogameDelegate -= EndMicrogame;
        GameManager.winMicrogameDelegate -= WinMicrogame;
    }
    
    protected abstract void StartMicrogame();
    protected abstract void WinMicrogame();
    protected abstract void EndMicrogame();

}
