using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GabriellaCukier {

    public class EnemySpawner : MonoBehaviour
    {
        public GameObject Cloud;
        public GameObject Sun;
        public GameObject Fish;
        public GameObject GO;
        private MicrogameInternal.GameManager gm;

        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            Construir();  
        }



        void Construir() {
                foreach (Transform child in transform) {
                    GameObject.Destroy(child.gameObject);
                }

                int j=4;

                if (gm.ActiveLevel < 3){
                    for(int i = 0; i < 6; i++) {
                        if (i!=4){
                            Vector3 posicao = new Vector3(-7 +3* i,j);
                            GO = Instantiate (Cloud, posicao, Quaternion.identity, transform) as GameObject ;
                        }else{
                            Vector3 posicao = new Vector3(-7 +3* i,j);
                            GO = Instantiate (Sun, posicao, Quaternion.identity, transform) as GameObject ;
                        }
                    }
                }else{
                    for(int i = 0; i < 6; i++) {
                        if (i!=1){
                            Vector3 posicao = new Vector3(-7 +3* i,j);
                            GO = Instantiate (Cloud, posicao, Quaternion.identity, transform) as GameObject ;
                        }else{
                            Vector3 posicao = new Vector3(-7 +3* i,j);
                            GO = Instantiate (Sun, posicao, Quaternion.identity, transform) as GameObject ;
                        }
                    }
                }


            // Obstáculos em níveis diferentes
                if (gm.ActiveLevel == 3){
                    Vector3 posicaoFish = new Vector3((float)8.25, (float)-4.5);
                    GO = Instantiate (Fish, posicaoFish, Quaternion.identity, transform) as GameObject ;
                }else if (gm.ActiveLevel == 4){
                    Vector3 posicaoFish = new Vector3((float)8.25, (float)-4.5);
                    GO = Instantiate (Fish, posicaoFish, Quaternion.identity, transform) as GameObject ;
                    Vector3 posicaoFish2 = new Vector3((float)20, (float)-3);
                    GO = Instantiate (Fish, posicaoFish2, Quaternion.identity, transform) as GameObject ;
                } else if (gm.ActiveLevel == 5){
                    Vector3 posicaoFish = new Vector3((float)12, (float)-4.5);
                    GO = Instantiate (Fish, posicaoFish, Quaternion.identity, transform) as GameObject ;
                    Vector3 posicaoFish2 = new Vector3((float)16, (float)-3);
                    GO = Instantiate (Fish, posicaoFish2, Quaternion.identity, transform) as GameObject ;
                    Vector3 posicaoFish3 = new Vector3((float)2.5, (float)-3.5);
                    GO = Instantiate (Fish, posicaoFish3, Quaternion.identity, transform) as GameObject ;
                }
        }


    }
}