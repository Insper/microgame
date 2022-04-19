using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ThaliaLoiola {
    public class GameManager : MonoBehaviour {

        // public GameObject instructions;  // Textou das instruçõees
        [SerializeField]private GameObject _instructions;
        private GameObject _acabou;  // objeto instanciado de buraco
        int pontuacao = 0;
        private int _level;
        public GameObject bola1;  // Prefab do buraco
        private GameObject _bola1;
        private MicrogameInternal.GameManager gm;

        void Start() {
            gm = MicrogameInternal.GameManager.GetInstance();
            _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;
            Invoke(nameof(Begin), 0.5f);    
            // Debug.Log(GameObject.Find("Watermelon").transform.position);
        }

        void Begin() {
            _instructions.SetActive(false);  // Tira tela de instruções
            Debug.Log("begin");
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);

            _bola1 = Instantiate(bola1);

            gm.StartTimer(); 
        }

        // public void makePoint() {
        //     pontuacao++;
        //     Debug.Log(pontuacao);
        //     if (pontuacao == 5) {
        //         Debug.Log("acabou");
        //         acabou = true;
        //     }
        // }

        void EndCheck() {
            Debug.Log("game lost");

            Destroy(_bola1);
            if (!_bola1.GetComponent<Fruit>().cortou) {
                gm.GameLost();
            }
        }
    }
}
