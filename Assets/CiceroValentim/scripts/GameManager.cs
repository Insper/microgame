using System;
using UnityEditor.U2D;
using UnityEngine;

using Random = UnityEngine.Random;

namespace CiceroValentim
{
    public class GameManager : MonoBehaviour
    {
        public GameObject instructions; // Textou das instruçõees

        public GameObject ingredients; // ingredients factory?

        public GameObject burger; // Prefab da burger

        public GameObject lettuce; // Prefab da salada

        public GameObject tomato; // Prefab da salada

        public GameObject cheese; // Prefab da salada

        public GameObject upperBread; // Prefab do pão de cima

        public GameObject lowerBread; // Prefab do pão de baixo

        private int _level;

        private MicrogameInternal.GameManager gm;

        // private GameObject _buraco; // objeto instanciado de buraco
        // public GameObject[] paredes; // Prefab das paredes
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;
            Invoke(nameof(Begin), 0.5f);
        }

        void Begin()
        {
            instructions.SetActive(false); // Tira tela de instruções
            Invoke(nameof(EndCheck), gm.MaxTime - 0.1f);

            // Cria objetos na cena
            // Instantiate (bola);
            // _buraco = Instantiate(buraco);
            // Instantiate(paredes[_level]);
            gm.StartTimer();
        }

        void EndCheck()
        {
            // // Se não chegou, perdeu
            // if (!_buraco.GetComponent<Chegou>().chegou)
            // {
            gm.GameLost();
            // }
        }
    }
}
