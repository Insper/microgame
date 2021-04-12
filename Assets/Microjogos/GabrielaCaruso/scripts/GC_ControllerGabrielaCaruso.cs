using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GC_ControllerGabrielaCaruso : BaseMGController
{
    // Objetos a serem gerenciados
    public GameObject bola;
    public List<GameObject> bloco;

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
    }

    // Exemplo de inicialização de jogo
    protected override void StartMicrogame()
    {
        // Mensagem inicial
        GameManager.Text.text = "Chegue no sol!";

        // Status inicial do jogo
        GameData.lost = true;
        
        // Blocos são escalados conforme o nível
        if(GameData.level > 4)
        {
            for(int i = 0; i < 7; i++){
                bloco[i].transform.localScale = new Vector3(7, 1, 0);
            }
        }
        else if(GameData.level > 2)
        {
            for(int i = 0; i < 7; i++){
                bloco[i].transform.localScale = new Vector3(5.5f, 1, 0);
            }
        }
        else 
        {
            for(int i = 0; i < 7; i++){
                bloco[i].transform.localScale = new Vector3(4, 1, 0);
            }
        }

        // Bola é desativada enquanto partida não começa
        bola.SetActive(false);
    }

    // Exemplo de jogo principal
    protected override void Microgame()
    {
        // A bola é ativada quando a partida começa
        bola.SetActive(true);        
    }

    public bool GetGameData() {
        return GameData.lost;
    }
}
