using UnityEngine;

namespace MicrogameInternal {
    public class Teste : MonoBehaviour
    {
        [ContextMenu("TesteInicio")]
        public void TesteInicio() {
            GameManager gm = GameManager.GetInstance();
            gm.StartTimer();
        }

        [ContextMenu("Teste Jogo Perdido")]
        public void TesteGameOver() {
            GameManager gm = GameManager.GetInstance();
            gm.GameLost();
        }
    }
}
