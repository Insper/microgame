using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dip {
    public class GameManager : MonoBehaviour {
        private MicrogameInternal.GameManager gm;
        
        void Start() {
            gm = MicrogameInternal.GameManager.GetInstance();
            // Invoke(nameof(Begin), 0.5f);            
        }

        void Begin() {
            gm.StartTimer(); 
        }

        void EndCheck() {
        }
        
    }
}
