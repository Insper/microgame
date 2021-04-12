using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerGabrielNoal : BaseMGController
{

    // Objetos a serem gerenciados
    public GameObject player;
    public GameObject target;


    // Exemplo de finalização de jogo
    protected override void EndMicrogame()
    {
        TargetController targetScript = target.GetComponent<TargetController>();

        GameData.lost = targetScript.gotHit ? false : true;
        // Mensagens de vítoria ou derrota
        if(GameData.lost)
        {
            GameManager.Text.text = "Você perdeu!";
        }
        else
        {
            GameManager.Text.text = "Você ganhou!";
        }
         
    }

    // Exemplo de inicialização de jogo
    protected override void StartMicrogame()
    {
        PlayerController PlayerScript = player.GetComponent<PlayerController>();

        // Mensagem inicial
        GameManager.Text.text = "Acerte o alvo!";

        if(GameData.level > 4)
        {
            PlayerScript.speed = 11.0f;

        }
        else if(GameData.level > 2)
        {
            PlayerScript.speed = 9.0f;

        }
        else if(GameData.level > 1) {
            PlayerScript.speed = 7.0f;
        }

        player.SetActive(false);
        target.SetActive(false);
    }

    // Exemplo de jogo principal
    protected override void Microgame()
    {
        player.SetActive(true);
        target.SetActive(true);
    }

    // Método chamado continuamente a cada quadro
    private void Update()
    {

    }
    
}
