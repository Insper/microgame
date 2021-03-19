using UnityEngine;

/* ----------------------------------------------------------------- //
// Esse código não deve ser alterado, caso precise ser feito algum   //
// ajuste, entrar em contato com o professor da disciplina.          //
// ----------------------------------------------------------------- */

// Classe base para os microjogos
public abstract class BaseMGController : MonoBehaviour
{

    // para definir a posição da barra de tempo
    [SerializeField] GameManager.UILocation uiLocation = default;

    protected GameManager gameManager;

    // Chamado quando método inicia no ciclo de vida do Unity
    protected virtual void Awake()
    {
        GameData.DebugLog("[BageMGController] Awake()");
        GameData.DebugLog("[BageMGController] Instantiating GameManager");

        // Ajustando o GameManager
        GameObject gm = Resources.Load("GameManager") as GameObject;
        gameManager = Instantiate(gm).GetComponent<GameManager>();
        gameManager.SetUI(uiLocation);
        
        GameData.DebugLog("[BageMGController] Registering delagates");

        // Registra métodos de derrota e vitória
        GameManager.startMicrogameDelegate += StartMicrogame;
        GameManager.microgameDelegate += Microgame;
        GameManager.endMicrogameDelegate += EndMicrogame;
    }

    // Chamado quando método finaliza no ciclo de vida do Unity
    private void OnDisable()
    {

        GameData.DebugLog("[BageMGController] OnDisable()");
        GameData.DebugLog("[BageMGController] De-registering delegates");

        // Tirando o registo dos métodos do microjogo
        GameManager.startMicrogameDelegate -= StartMicrogame;
        GameManager.microgameDelegate -= Microgame;
        GameManager.endMicrogameDelegate -= EndMicrogame;

    }
    
    // Métodos abstrados que devem ser implementados
    protected abstract void StartMicrogame();
    protected abstract void Microgame();
    protected abstract void EndMicrogame();

}
