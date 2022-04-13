using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GabriellaCukier {

    public class EnemySpawner : MonoBehaviour
    {
    public GameObject Cloud;
    public GameObject Sun;
    public GameObject GO;
    private MicrogameInternal.GameManager gm;

    void Start()
    {
        Construir();  
        // Debug.Log("start");
    }



    void Construir() {
        // Debug.Log("Construir");
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
                int j=4;
                for(int i = 0; i < 6; i++) {
                    if (i!=4){
                        Vector3 posicao = new Vector3(-7 +3* i,j);
                        GO = Instantiate (Cloud, posicao, Quaternion.identity, transform) as GameObject ;
                    }else{
                        Vector3 posicao = new Vector3(-7 +3* i,j);
                        GO = Instantiate (Sun, posicao, Quaternion.identity, transform) as GameObject ;
                    }
                }
    }

    void Update()
    {
        //   if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
        //   {
        //      Debug.Log("update");
        //       if (gm.level == 1){
        //         gm.level += 1;
        //         gm.pontos *= 2;
                // Construir();
        //         gm.levelchange = true;
        //       }else if (gm.level == 2){
        //         gm.level += 1;
        //         gm.pontos *= 2;
        //         Construir();
        //         gm.levelchange = true;
        //       }
        //       else {
        //         gm.ChangeState(GameManager.GameState.ENDGAME);
        //         gm.level = 1;
        //         gm.levelchange = true;
        //       }   
        //   }
    }

    }
}