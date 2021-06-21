using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    
    // GameManager gm;
    void Start()
    {
        
        // gm = GameManager.GetInstance();
        // GameManager.changeStateDelegate += Construir;
        Construir();
    }

    void Construir()
    {
        // if (gm.gameState == GameManager.GameState.GAME)
        // {
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
            for(int i = 0; i < 3; i++)
            {
                int num = Random.Range(-8, 8);
                Vector3 posicao = new Vector3(num, 5);

                Instantiate(Enemy, posicao, Quaternion.identity, transform);
            
            }
        // }
    }

    // void Update()
    // {
    //     if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
    //     {
    //         gm.ChangeState(GameManager.GameState.ENDGAME);
    //     }
    // }
}
