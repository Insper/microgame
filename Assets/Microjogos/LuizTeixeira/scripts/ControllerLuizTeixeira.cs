using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Controller principal do jogo
public class ControllerLuizTeixeira : BaseMGController
{

    // Objetos a serem gerenciados
    public Rigidbody2D bird;
    public float velocity;


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
        GameManager.Text.text = "Não encoste nos tubos!";

    }

    // Exemplo de jogo principal
    protected override void Microgame()
    {

    }

    // Método chamado continuamente a cada quadro
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            bird.velocity = Vector2.up * velocity;
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameData.lost = true;
    }

}
