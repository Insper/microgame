using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : SteerableBehaviour, IDamageable
{
    // GameManager gm;

    // private void Start()
    // {
    //     gm = GameManager.GetInstance();
    // }
    
    
    public void TakeDamage()
    {
        Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    // void Update()
    // {
    //     if (gm.gameState != GameManager.GameState.GAME) return;

    //     if (gm.pontos >= 3 && gm.gameState == GameManager.GameState.GAME)
    //     {
    //         gm.ChangeState(GameManager.GameState.ENDGAME);
    //     }
    // }

    
}
