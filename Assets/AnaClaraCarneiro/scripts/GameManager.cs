using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnaClaraCarneiro {
    public class GameManager : MonoBehaviour
    {
        public GameObject instructions;  // Textou das instruçõees
        private MicrogameInternal.GameManager gm;
        private int _level;


        // Start is called before the first frame update
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            _level = gm.ActiveLevel <= 2 ? gm.ActiveLevel : 2;
            Invoke(nameof(Begin), 0.5f);
        }

        void Begin() {
            instructions.SetActive(false);
            // Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer(); 
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
