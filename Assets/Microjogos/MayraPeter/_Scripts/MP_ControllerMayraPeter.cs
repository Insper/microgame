using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MP_ControllerMayraPeter : BaseMGController
{

    public GameObject cannon;
    public GameObject bullet;
    public GameObject object1;


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
        GameManager.Text.text = "Não deixe os objetos cairem!";
        
        // Raquete é escalada conforme o nível
        if(GameData.level > 4)
        {
            bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0);
        }
        else if(GameData.level > 2)
        {
            bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        }
        else 
        {
            bullet.transform.localScale = new Vector3(1, 1, 0);
        }

        // Bola é desativada enquanto partida não começa
        object1.SetActive(false);

    }

    // Exemplo de jogo principal
    protected override void Microgame()
    {
        // Bola é ativada em posição aleatória e gravidade faz ela cair
        float pos = Random.Range(-6.0f, 6.0f);
        object1.transform.position += new Vector3(pos, 3, 0);
        object1.SetActive(true);
        
    }

    void Update()
    {

        if(object1.transform.position.y < cannon.transform.position.y)
        {
            // Se a bola está perdida é pintada de vermelho
            object1.GetComponent<SpriteRenderer>().color = Color.white;
            
            // Por padrão se supoões que jogador ganho, caso contrário se informa que perdeu.
            GameData.lost = true;
        }
    }
}
