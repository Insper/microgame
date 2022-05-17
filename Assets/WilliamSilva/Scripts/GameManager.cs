using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WilliamSilva {
    public class GameManager : MonoBehaviour
    {
        private MicrogameInternal.GameManager gm;

        // Start is called before the first frame update
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}