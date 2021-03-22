using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hr_GameController : BaseMGController
{
    protected override void StartMicrogame()
    {
        Debug.Log("Inicio do Jogo");
    }

    protected override void Microgame()
    {
        // Make the default state.
        GameData.lost = true;
        Debug.Log("Jogo Principal");
    }

    // protected override void EndMicrogame()
    // {
    //     Debug.Log("Jogo Acabou");
    // }

    protected override void EndMicrogame()
    {
        if(GameData.lost)
        {
            GameManager.Text.text = "Você perdeu!";
        }
        else
        {
            GameManager.Text.text = "Você ganhou!";
        }
    }

    public void SetGameDataLost(bool lost) {
        GameData.lost = lost;
    }

    public int GetLevel() {
        return GameData.level;
    }

    private void LateUpdate()
    {
        // Logica do seu jogo
    }
}
