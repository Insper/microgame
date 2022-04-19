using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MuriloMenezes {
    public class GameManager : MonoBehaviour {

        private MicrogameInternal.GameManager gm;
        public GameObject player;
    
        void Start() {
            gm = MicrogameInternal.GameManager.GetInstance();
            Invoke(nameof(Begin), 0.5f);
        }


        void Begin() {
            // instructions.SetActive(false);
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer(); 
        }

        void EndCheck() {

            if(player.GetComponent<Player>().Fail)
            {
                gm.GameLost(); 
            }

            
        }
    }
}
