using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Controller principal do jogo
public class ControllerLucasMuchaluat : BaseMGController
{

    // Objetos a serem gerenciados
    public GameObject bird;
    public GameObject chao;
    public GameObject spikes;
    public GameObject limiar;

    // Exemplo de inicialização de jogo
    protected override void StartMicrogame()
    {
        Debug.Log("Inicio do Jogo");

        // Mensagem inicial
        GameManager.Text.text = "Proteja o passaro dos espinhos!";
        
        // Raquete é escalada conforme o nível
        if(GameData.level > 4)
        {
            Debug.Log("LEVEL MAIOR QUE 4");
            bird.GetComponent<Rigidbody2D>().gravityScale = 4.0f;
        }
        else if(GameData.level > 2)
        {
            Debug.Log("LEVEL MAIOR QUE 2");
            bird.GetComponent<Rigidbody2D>().gravityScale = 3.0f;
        }
        else 
        {
            Debug.Log("LEVEL MENOR QUE 2");
            bird.GetComponent<Rigidbody2D>().gravityScale = 2.0f;
        }

        // bird é desativada enquanto partida não começa
        bird.SetActive(false);
        chao.SetActive(false);
        spikes.SetActive(false);

    }    

    // Exemplo de jogo principal
    protected override void Microgame()
    {
        Debug.Log("Jogo Principal");

        bird.SetActive(true);
        chao.SetActive(true);
        spikes.SetActive(true);
        
    }

    // Exemplo de finalização de jogo
    protected override void EndMicrogame()
    {
        Debug.Log("Jogo Acabou");

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

    // Método chamado continuamente a cada quadro
    void FixedUpdate()
    {

        if(Input.GetAxisRaw("Jump") != 0)
        {
            bird.GetComponent<Rigidbody2D>().velocity = Vector2.up * 4.0f;
        }

        // Caso a bird passe a raquete é considerado que se perdeu a partida
        if(bird.transform.position.y <= limiar.transform.position.y)
        {            
            // Por padrão se supoões que jogador ganho, caso contrário se informa que perdeu.
            GameData.lost = true;
        }

    }
    
}
