using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BeatrizBernardino
{
    public class GameManager : MonoBehaviour
    {

        public GameObject instructions;  // Textou das instruçõees


        public GameObject surfer;  // Prefab do surfer
        public GameObject _surfer;  // objeto do surfer

        public GameObject prancha;  // Prefab da prancha
        private GameObject _prancha;  // objeto instanciado de buraco


        private int _level;

        private MicrogameInternal.GameManager gm;



        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;
            Invoke(nameof(Begin), 0.5f);
        }

        void Begin()
        {
            instructions.SetActive(false);  // Tira tela de instruções
            Invoke(nameof(EndCheck), gm.MaxTime - 0.1f);


            // // Cria objetos na cena
            _surfer = Instantiate(surfer);
            _prancha = Instantiate(prancha);


            if (_level == 0)
            {
                _prancha.GetComponent<boardBehaviour>().speed = 100;
            }
            else if (_level == 1)
            {
                _prancha.GetComponent<boardBehaviour>().speed = 200;
            }
            else
            {
                _prancha.GetComponent<boardBehaviour>().speed = 270;

            }

            gm.StartTimer();
        }

        void OnBecameInvisible()
        {
            gm.GameLost();
        }

        void EndCheck()
        {
            // Se caiu, perdeu
            OnBecameInvisible();

        }
    }
}

