using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnaClaraCarneiro {
    public class GameManager : MonoBehaviour
    {
        public GameObject instructions;
        private MicrogameInternal.GameManager gm;
        private int _level;

        public GameObject dino;
        public GameObject meteoro;
        private GameObject _meteoro;
        public GameObject vulcao;


        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;
            Invoke(nameof(Begin), 0.5f);
        }

        void Begin() {
            instructions.SetActive(false);
            vulcao.SetActive(true);
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            Instantiate(dino);
            _meteoro = Instantiate(meteoro);

            gm.StartTimer(); 
        }

        void EndCheck() {
            if(_meteoro.GetComponent<Meteoros>().perdeu) {
                print("entrei");
                gm.GameLost(); 
            }    
        }
    }
}
