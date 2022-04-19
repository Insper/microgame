using System;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gabrielamb2 {
    public class GameManager : MonoBehaviour {

        public AudioSource theMusic;
        public bool startPlaying;
        public BeatScroller theBS;
        [SerializeField]private GameObject _instructions;
        private MicrogameInternal.GameManager gm;
        public static GameManager instance;
        public int i;
        void Start() {
            instance = this;
            gm = MicrogameInternal.GameManager.GetInstance();
           Invoke(nameof(Begin), 0.5f);
            i = 0;
            
        }

        void Begin() {
            _instructions.SetActive(false);
            Invoke(nameof(NoteMissed), gm.MaxTime-0.1f);
            gm.StartTimer(); 
            startPlaying = true;
            theBS.hasStarted = true;

            theMusic.Play();
        }
        
        public void NoteHit(){
           
            if(i == 1){
              i = 0;
            }
        }

        public void NoteMissed(){

            if(i == 1){
              gm.GameLost(); 

            }
            i = 1;
            
        }
    
    }
}
