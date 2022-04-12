using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Vergara{
    public class GameManager : MonoBehaviour{

        private MicrogameInternal.GameManager gm;
        private int[] _progression = {2, 3, 5, 4, 3, 2}; 
        // Start is called before the first frame update
        void Start(){
            gm = MicrogameInternal.GameManager.GetInstance();    
            //spawna os dinos
            // spawna o ovo da vez        
        }

        // Update is called once per frame
        void Update(){
        }
        void Begin() {
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer(); 
        }

        void EndCheck() {
          gm.GameLost(); 
        }
    }
}