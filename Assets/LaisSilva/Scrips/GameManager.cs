using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.U2D;
using Random = UnityEngine.Random;
using System.Threading;



namespace LaisSilva{
    public class GameManager : MonoBehaviour
    {
    
        [SerializeField]private GameObject _instructions;
        private MicrogameInternal.GameManager gm;
        public Toupera[] touperas;
        public Martelo martelo;
        private int[] _progression = {4, 5, 6, 6, 7, 7, 8};
        
        
        
        void Start() {
            gm = MicrogameInternal.GameManager.GetInstance();
            
            Invoke(nameof(Begin), 0.5f);
            
            StartCoroutine(nameof(SelectNivel));
            
        }

        IEnumerator SelectNivel(){
            for (int i = 0; i < _progression[gm.ActiveLevel]; i++){

                SobeTouperaRandom();
                yield return new WaitForSeconds(1.2f/(gm.ActiveLevel+1));
            }

        }

        void SobeTouperaRandom() {
                int rand = Random.Range(0, 8);
                touperas[rand].Animacao();
                
                
                

        }

        void Begin() {
            _instructions.SetActive(false);
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer(); 
        }

        void EndCheck() {
            if (martelo.pontos<_progression[gm.ActiveLevel]){
                gm.GameLost(); 
            }
           
        }
    }


}
