using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GabriellaCukier {

    public class EnemySpawner : MonoBehaviour
    {
    public GameObject Cloud;
    public GameObject Sun;

    public GameObject GO;
    //   GameManager gm;

    private MicrogameInternal.GameManager gm;

            // [SerializeField]private GameObject _instructions;



    void Start()
    {
        //   gm = GameManager.GetInstance();
        //   GameManager.changeStateDelegate += Construir;
        // gm = MicrogameInternal.GameManager.GetInstance();
        // Invoke(nameof(Begin), 0.5f);
        Construir();  
        Debug.Log("start");
    }



    void Construir() {
        Debug.Log("Construir");
        //    Debug.Log($"waspaused{gm.waspaused}");

        
        //    if (gm.gameState == GameManager.GameState.GAME && !(gm.waspaused)) {

            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }

            //   if (gm.level == 1){
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
            //   }else if (gm.level ==2){
                    
            //   }else {
                
            //   }
        
        //   gm.waspaused=false;
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