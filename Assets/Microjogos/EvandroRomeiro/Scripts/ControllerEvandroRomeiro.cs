using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerEvandroRomeiro : BaseMGController{

    public GameObject player;
    public GameObject wall;
    public GameObject wall2;
    public GameObject wall3;
    public float screenBorder;
    [Range(0,10)]
    public float speed;
    // Exemplo de finalização de jogo
    protected override void EndMicrogame(){
        // Mensagens de vítoria ou derrota
        if(GameData.lost){
            GameManager.Text.text = "Você perdeu!";
        } else {
            GameManager.Text.text = "Você ganhou!";
        }
        
    }

    // Exemplo de inicialização de jogo
    protected override void StartMicrogame(){
        GameData.lost = true;
        // Mensagem inicial
        GameManager.Text.text = "Chegue até o outro lado";

                // Raquete é escalada conforme o nível
        if(GameData.level > 8){
            Instantiate(wall3);
        }
        else if(GameData.level > 4){
            Instantiate(wall2);
        }
        else {
            Instantiate(wall);
        }

        
    }

    // Exemplo de jogo principal
    protected override void Microgame(){

        
    }

    // Método chamado continuamente a cada quadro
    private void Update(){

        // Se coleta as teclas pressionadas e se posiciona a raquete
    	float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
    	player.transform.position += new Vector3(inputX, inputY, 0)*Time.deltaTime*speed;

        if(player.transform.position.x > screenBorder){
            GameData.lost = false;
        } else {
            GameData.lost = true;
        }


    }

}
