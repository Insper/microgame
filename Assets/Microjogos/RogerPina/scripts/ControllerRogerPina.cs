using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Controller principal do jogo
public class ControllerRogerPina : BaseMGController
{

    // Objetos a serem gerenciados
    public GameObject block;

    public GameObject plataformTop;

    private float velocity;

    private Vector3 direcao;

    private float time;

    private bool pressed;

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
        GameManager.Text.text = "Não deixe os blocos cairem!";
        
        // Raquete é escalada conforme o nível
        if(GameData.level > 4)
        {
            // raquete.transform.localScale = new Vector3(1, 1, 1);
            velocity = 6.0f;
        }
        else if(GameData.level > 2)
        {
            // raquete.transform.localScale = new Vector3(2, 1, 1);
            velocity = 4.0f;
        }
        else 
        {
            // raquete.transform.localScale = new Vector3(4, 1, 1);
            velocity = 2.0f;
        }

        // Bola é desativada enquanto partida não começa
        block.SetActive(false);

        direcao = new Vector3(3, 0, 0);

        time = GameData.GetTime();
    }

    // Exemplo de jogo principal
    protected override void Microgame()
    {
        // Bola é ativada em posição aleatória e gravidade faz ela cair
        float pos = Random.Range(-0.5f, 0.5f);
        block.transform.position += new Vector3(pos, 0, 0);

        block.SetActive(true);

        time = GameData.GetTime();
    }

    // Método chamado continuamente a cada quadro
    private void Update()
    {

        block.transform.position += direcao * Time.deltaTime * velocity;

        if (block.transform.position.x < -7.1f || block.transform.position.x > 7.1f )
        {
            direcao = new Vector3(-(direcao.x + 0.1f), direcao.y);
        }

        if (time >= 0.0f) time -= Time.deltaTime;

        // Se coleta as teclas pressionadas e se posiciona a raquete
        bool input = Input.GetKeyDown(KeyCode.Space);

        if (input || time <= 0) {
            block.GetComponent<Rigidbody2D>().gravityScale = 1;
            direcao = new Vector3(0,0);
            pressed = true;
        }

        // Caso a bola passe a raquete é considerado que se perdeu a partida
        if(block.transform.position.y < plataformTop.transform.position.y)
        {
            // Se a bola está perdida é pintada de vermelho
            block.GetComponent<SpriteRenderer>().color = Color.red;
            
            // Por padrão se supoões que jogador ganho, caso contrário se informa que perdeu.
            GameData.lost = true;
        }

        if (!pressed && time <= 0.1)
        {
            GameData.lost = true;
        }

    }
    
}
