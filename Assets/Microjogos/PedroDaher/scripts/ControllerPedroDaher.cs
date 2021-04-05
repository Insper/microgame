using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Controller principal do jogo
public class ControllerPedroDaher : BaseMGController
{

    // Objetos a serem gerenciados
    public GameObject raquete;
    public GameObject bola;

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
        GameManager.Text.text = "Acerte a cesta!";
        float inputX = Input.GetAxis("Horizontal");
        
        // Dificulade de manusear a bola aumenta conforme o nível
        
        if(GameData.level > 4)
        {
            bola.transform.position += new Vector3(inputX*2f, 0, 0);
        }
        else if(GameData.level > 2)
        {
            bola.transform.position += new Vector3(inputX*0.5f, 0, 0);
        }
        else 
        {
            bola.transform.position += new Vector3(inputX*0.1f, 0, 0);
        }
        
        // Bola é desativada enquanto partida não começa
        bola.SetActive(false);

    }

    // Exemplo de jogo principal
    protected override void Microgame()
    {
        // Bola é ativada em posição aleatória e gravidade faz ela cair
        float pos = Random.Range(-6.0f, 6.0f);
        bola.transform.position += new Vector3(pos, 0, 0);

        bola.SetActive(true);
        
    }

    // Método chamado continuamente a cada quadro
    private void Update()
    {

        // Se coleta as teclas pressionadas e se posiciona a raquete
    	float inputX = Input.GetAxis("Horizontal");
    	
    	bola.transform.position += new Vector3(inputX*0.1f, 0, 0);

        // Caso a bola passe a raquete é considerado que se perdeu a partida
        if(bola.transform.position.y < raquete.transform.position.y)
        {
            // Por padrão se supoões que jogador ganho, caso contrário se informa que perdeu.
            GameData.lost = true;
        }

    }
    
}
