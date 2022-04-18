using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MarceloMiguel {
    public class GameManager : MonoBehaviour {

        public GameObject instructions;  // Textou das instruçõees


        public GameObject EnemyPool;  // Prefab do buraco
        private int _level;
        
        private MicrogameInternal.GameManager gm;


        void Start() {
            gm = MicrogameInternal.GameManager.GetInstance();
            _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;
            EnemyPool.GetComponent<EnemyPool>().Construir(_level);
            Invoke(nameof(Begin), 0.5f);                         
        }

        void Begin() {
            instructions.SetActive(false);
            // instructions.SetActive(false);  // Tira tela de instruções
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);

            // // Cria objetos na cena
            // Instantiate(bola);
            // _buraco = Instantiate(buraco);
            // Instantiate(paredes[_level]);

            gm.StartTimer(); 
        }

        void EndCheck() {
            if(EnemyPool.transform.childCount > 0) {
                gm.GameLost();
            } 
            // Se não chegou, perdeu
            // if(_dotHolder.transform.childCount > 0) gm.GameLost();

        }
    }
}
