using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Controller principal do jogo
public class ControllerLucianoSoares : BaseMGController
{


    // Objetos a serem gerenciados
    public GameObject raquete;
    public GameObject bola;

    // Exemplo de finalização de jogo
    protected override void EndMicrogame() {
        // Mensagens de vítoria ou derrota
        if (GameData.lost) {
            GameManager.Text.text = "Você perdeu!";
        }
        else {
            GameManager.Text.text = "Você ganhou!";
        }

    }

    // Exemplo de inicialização de jogo
    protected override void StartMicrogame() {
        // Mensagem inicial
        GameManager.Text.text = "Não deixe a bola cair!";

        // Raquete é escalada conforme o nível

        if(GameData.level > 4)
        {
            raquete.transform.localScale = new Vector3(1, 1, 1); // pequena
        }
        else if(GameData.level > 2)
        {
            raquete.transform.localScale = new Vector3(2, 1, 1); // média
        }
        else 
        {
            raquete.transform.localScale = new Vector3(4, 1, 1); //grande

        }

        // Bola é desativada enquanto partida não começa
        bola.SetActive(false);

    }

    // Exemplo de jogo principal
    protected override void Microgame() {
        // Bola é ativada em posição aleatória e gravidade faz ela cair
        float pos = Random.Range(-6.0f , 6.0f);
        bola.transform.position += new Vector3(pos , 0 , 0);

        bola.SetActive(true);

    }

    // Método chamado continuamente a cada quadro
    private void Update() {

        // Se coleta as teclas pressionadas e se posiciona a raquete
        float inputX = Input.GetAxis("Horizontal");
        raquete.transform.position += new Vector3(inputX , 0 , 0);

        // Caso a bola passe a raquete é considerado que se perdeu a partida
        if (bola.transform.position.y < raquete.transform.position.y) {
            // Se a bola está perdida é pintada de vermelho
            bola.GetComponent<SpriteRenderer>().color = Color.red;

            // Por padrão se supoões que jogador ganho, caso contrário se informa que perdeu.
            GameData.lost = true;
        }

    }

}