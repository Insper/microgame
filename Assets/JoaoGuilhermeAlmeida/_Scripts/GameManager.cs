using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace JoaoGuilhermeAlmeida
{
    public class GameManager : MonoBehaviour
    {

        public GameObject instructions;  // Textou das instruçõees

        public GameObject ArmSpawner;

        private int _level;

        public int handSaveds;

        private MicrogameInternal.GameManager gm;


        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;
            ArmSpawner = GameObject.Find("ArmSpawner");
            Invoke(nameof(Begin), 0.5f);
        }

        void Begin()
        {
            instructions.SetActive(false);  // Tira tela de instruções
            Invoke(nameof(EndCheck), gm.MaxTime - 0.1f);


            gm.StartTimer();
        }

        void EndCheck()
        {

            // Se não salvou todas as maos, perdeu
            if (!ArmSpawner.GetComponent<ArmSpawner>().win)
            {
                print(handSaveds);
                gm.GameLost();
            }

        }
    }
}