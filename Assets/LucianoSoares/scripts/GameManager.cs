using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LucianoSoares {
    public class GameManager : MonoBehaviour {

        public GameObject instructions;  // Textou das instruçõees


        public GameObject bola;  // Prefab da bola
        public GameObject buraco;  // Prefab do buraco
        private GameObject _buraco;  // objeto instanciado de buraco
        public GameObject[] paredes;  // Prefab das paredes

        private int _level;
        
        private MicrogameInternal.GameManager gm;


        void Start() {
            gm = MicrogameInternal.GameManager.GetInstance();
            _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;
            Invoke(nameof(Begin), 0.5f);                         
        }

        void Begin() {
            instructions.SetActive(false);  // Tira tela de instruções
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);

            // Cria objetos na cena
            Instantiate(bola);
            _buraco = Instantiate(buraco);
            Instantiate(paredes[_level]);

            gm.StartTimer(); 
        }

        void EndCheck() {

            // Se não chegou, perdeu
            if(!_buraco.GetComponent<Chegou>().chegou) {

                gm.GameLost(); 
            } 

        }
    }
}
