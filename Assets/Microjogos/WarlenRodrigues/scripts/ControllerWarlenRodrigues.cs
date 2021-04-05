using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Controller principal do jogo
public class ControllerWarlenRodrigues : BaseMGController
{
    // Para gerar distancias aleatórias para os carros
    public System.Random random = new System.Random();


    // Objetos a serem gerenciados
    public GameObject chicken;
    public float velocidade;
    public GameObject enemy;


    // Exemplo de finalização de jogo
    protected override void EndMicrogame()
    {
        // Mensagens de vítoria ou derrota
        if (GameData.lost)
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
        GameManager.Text.text = "Alcance a área verde!";

        // Por default o player perde. Só ganha se chegar à safeZone
        GameData.lost = true;

        // Declarando variáveis de dificuldade
        int lines, randDistX;
        float yOffset, yInterval;
        int columns = 6;

        // Alterar a quantidade dos inimigos conforme o nível
        if (GameData.level > 4)
        {
            lines = 4;
            yOffset = -2.0f;
            yInterval = 1.5f;
        }
        else if (GameData.level > 2)
        {
            lines = 3;
            yOffset = -1.5f;
            yInterval = 1.5f;
        }
        else
        {
            lines = 2;
            yOffset = -1.5f;
            yInterval = 2.5f;
        }

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < lines; j++)
            {
                randDistX = random.Next(2, 4);
                Vector3 posicao = new Vector3(-8 + randDistX + 4f * i, yOffset + yInterval * j);
                Instantiate(enemy, posicao, Quaternion.identity, transform);
            }
        }


        // Inimigos desativados enquanto partida não começa
        enemy.SetActive(false);

    }

    // Exemplo de jogo principal
    protected override void Microgame()
    {
        // Ligar a velocidade dos inimigos
        enemy.SetActive(true);

    }

    // Verificar colisão com inimigos ou alcance do target
    private void Update()
    {
        // caso a galinha chegue à safeZone
        if (chicken.transform.position.y >= 3)
        {
            // Ganha o jogo
            GameData.lost = false;
        }

        if (chicken.transform.position.y < 4)
        {
            // Captura de telas para movimento do 'chicken'
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            chicken.transform.position += new Vector3(inputX, inputY, 0) * Time.deltaTime * velocidade;
        }

        // Velocidade dos inimigos

    }

}
