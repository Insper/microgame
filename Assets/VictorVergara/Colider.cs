using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace Vergara{
    public class Colider : MonoBehaviour{
        private MicrogameInternal.GameManager gm;
        public GameObject endgameObj;
        public Text endgame;  // Textou das instruçõees
        public bool CorrectPair;
        public bool win;
        // Start is called before the first frame update
        void Start(){
            gm = MicrogameInternal.GameManager.GetInstance();
            endgameObj = GameObject.Find("EndGame");
            endgame = endgameObj.GetComponent<Text>();
            endgame.text = "";
            
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Eggs")){
                
                if(CorrectPair){
                    Debug.Log("Certo Corno");
                    endgame.text = "Win!!";
                    win = true;
                }
                else{
                    endgame.text = "Volte para as aulas de Artes!!";
                    StartCoroutine(timerEndLost());
                    
                }
            }
        }
        IEnumerator timerEndLost(){

        yield return new WaitForSeconds(1);
        gm.GameLost(); 
        }
    }
}