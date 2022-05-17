using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatheusFreitas {
    public class GameManager : MonoBehaviour {
        private MicrogameInternal.GameManager gm;
        public GameObject instructions;
        
        // Start is called before the first frame update
        void Start()
        {
            Invoke(nameof(Begin), 0.5f);
            gm = MicrogameInternal.GameManager.GetInstance();
        }

        void Begin() {
            instructions.SetActive(false);
            gm.StartTimer();   
        }

        // Update is called once per frame
        void Update()
        {
    
        }
    }
}
