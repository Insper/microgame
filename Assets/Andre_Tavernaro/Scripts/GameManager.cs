using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Andre_Tavernaro {
    public class GameManager : MonoBehaviour
    {
        private MicrogameInternal.GameManager gm;
        public GameObject instructions;

        void Awake()
        {
            gm = MicrogameInternal.GameManager.GetInstance();

            if(gm.ActiveLevel <= 7){
                AlphaMaleBehavior.speed =  2f;
                UmbrellaBehavior.speed = 8f;
                UmbrellaBehavior.scale = new Vector3(1.2f,0.8f,1f);
            }
            else if(gm.ActiveLevel > 7 && gm.ActiveLevel <= 14){
                AlphaMaleBehavior.speed =  3f;
                UmbrellaBehavior.speed = 9f;
                UmbrellaBehavior.scale = new Vector3(1.1f,0.7f,1f);
            }
            else if(gm.ActiveLevel > 14){
                AlphaMaleBehavior.speed =  3.5f;
                UmbrellaBehavior.speed = 9.5f;
                UmbrellaBehavior.scale = new Vector3(1f,0.7f,1f);
            }

            Invoke(nameof(Begin), 0.7f);
        }

        void Begin() {
            instructions.SetActive(false);
            Invoke(nameof(EndCheck), gm.MaxTime-0.1f);
            gm.StartTimer(); 
        }

        void EndCheck() {
            if(!AlphaMaleBehavior.isAlive){
                gm.GameLost(); 
            }
        }
    }
}