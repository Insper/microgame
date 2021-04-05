using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Controller principal do jogo
public class ControllerLuizaSilveira : BaseMGController
{

    // Objetos a serem gerenciados

    public Transform car;
    public float vel;

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
        GameManager.Text.text = "Não bata o carro!";

    }

    // Exemplo de jogo principal
    protected override void Microgame()
    {

    }

    // Método chamado continuamente a cada quadro
    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            Movment(-1);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)){
            Movment(1);
        }
        //Debug.Log(GameData.level);

    }

    public void Movment(float direction){
        car.Translate(direction * vel,0,0);
        Vector3 pos = car.position;
        pos.x = Mathf.Clamp(pos.x,-4,4);
        car.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.gameObject.CompareTag("obstacle"))
       {
           GameData.lost = true;
           EndMicrogame();
       }
   }
    
}
