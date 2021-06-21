using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : BaseMGController
{

    // Sprites a serem gerenciados
    // Crédito das imagens da roleta : https://urdutechtutorials.blogspot.com/2018/07/how-to-make-wheel-of-fortune-in-unity.html

    // Exemplo de finalização de jogo
    protected override void EndMicrogame()
    {
        // Mensagens de vítoria ou derrota
        if(GameData.lost)
        {
            GameManager.Text.text = "Você perdeu!";
        }
        else
        {
            GameManager.Text.text = "Você ganhou!";
        }
        GameManager.Text.color = Color.white;
        
    }

    // Exemplo de inicialização de jogo
    protected override void StartMicrogame()
    {   

        // Mensagem inicial
        GameManager.Text.color = Color.black;
        GameManager.Text.text = "Acerte o verde com a barra de espaço";

    }

    // Exemplo de jogo principal
    protected override void Microgame()
    {
        GameData.lost = true;
    }

    
}
