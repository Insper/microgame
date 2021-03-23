using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hr_GameController : BaseMGController
{
    protected override void StartMicrogame()
    {
        Debug.Log("Inicio do Jogo");

        // Mensagem inicial.
        GameManager.Text.text = "Chegue até a bola verde!";
    }

    protected override void Microgame()
    {
        Debug.Log("Jogo Principal");

        // Set the game's default state, which is to lose.
        GameData.lost = true;
    }

    protected override void EndMicrogame()
    {
        Debug.Log("Fim de Jogo.");
        
        if (GameData.lost)
        {
            GameManager.Text.text = "Você perdeu!";
        }
        else
        {
            GameManager.Text.text = "Você ganhou!";
        }
    }

    public bool GetGameData() {
        return GameData.lost;
    }

    public void SetGameDataLost(bool lost) {
        GameData.lost = lost;
    }

    public int GetLevel() {
        return GameData.level;
    }
}
