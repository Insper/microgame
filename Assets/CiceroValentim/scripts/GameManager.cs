using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.U2D;
using UnityEngine;

using Random = UnityEngine.Random;

namespace CiceroValentim
{
    public class GameManager : MonoBehaviour
    {
        public GameObject instructions;

        public GameObject[] ingredients;

        public Controller controller;

        private MicrogameInternal.GameManager gm;

        public List<GameObject> orderedBurger;

        // private GameObject _buraco; // objeto instanciado de buraco
        // public GameObject[] paredes; // Prefab das paredes
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            orderedBurger = BurgerFactory.GetBurger(ingredients, gm.ActiveLevel);
            InstantiateOrderedBurger();
            Invoke(nameof(Begin), 1.0f);
        }

        void Begin()
        {
            instructions.SetActive(false); // Tira tela de instruções
            Invoke(nameof(EndCheck), gm.MaxTime - 0.1f);

            gm.StartTimer();
        }

        void InstantiateOrderedBurger()
        {
            Vector3 initialPosition = new Vector3(-5, -2, 0);
            for (int i = 0; i < orderedBurger.Count; i++)
            {
                GameObject gameObject =
                    Instantiate(orderedBurger[i],
                    initialPosition,
                    Quaternion.identity);
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                initialPosition += new Vector3(0, 1, 0);
            }
        }

        public void GameLost()
        {
            gm.GameLost();
        }

        void EndCheck()
        {
            if (!controller.LastCheck())
            {
                gm.GameLost();
            }
        }
    }
}
