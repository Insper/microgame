using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerLucasLeal : BaseMGController
{

    // Objetos a serem gerenciados

    public GameObject Redbutton;
    public GameObject Greenbutton;
    public GameObject pressButton;
    public GameObject dontPressbutton;
    private GameObject button;
    private GameObject text;
    public Camera cam;
    private bool buttonPressed;
    private bool apertarFlag;
    private bool naoApertarFlag;
    public Color colorRed = Color.red;
    public Color colorGreen = Color.green;
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
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        
        float but = Random.Range(0.0f,2.0f);
        float tex = Random.Range(0.0f,2.0f);

        if(tex > 1){
            text = pressButton;
            dontPressbutton.SetActive(false);
            apertarFlag = true;
            naoApertarFlag = false ;
        }else{
            text = dontPressbutton;
            pressButton.SetActive(false);
            naoApertarFlag = true;
            apertarFlag = false ;
        };

        if(but > 1){
            button = Greenbutton;
            Redbutton.SetActive(false);
            cam.backgroundColor = colorRed;
        }else{
            button = Redbutton;
            Greenbutton.SetActive(false);
        };
        // Mensagem inicial
        GameManager.Text.text = "PRESS SPACE!";
        
        // Raquete é escalada conforme o nível
        if(GameData.level > 4)
        {
           button.transform.localScale = new Vector3(3.0f, 3.0f, 1);
           text.transform.localScale = new Vector3(2.7f, 2.7f, 1);
        }
        else if(GameData.level > 2)
        {
            button.transform.localScale = new Vector3(2.5f, 2.5f, 1);
            text.transform.localScale = new Vector3(2.2f, 2.2f, 1);
        }
        else 
        {
            button.transform.localScale = new Vector3(2, 2, 1);
            text.transform.localScale = new Vector3(1.7f, 1.7f, 1);
        }

        // Bola é desativada enquanto partida não começa
        button.SetActive(false);
        text.SetActive(false);
        
      
    }

    // Exemplo de jogo principal
    protected override void Microgame()
    {
        // Bola é ativada em posição aleatória e gravidade faz ela cair
        // float pos = Random.Range(-6.0f, 6.0f);

        // button.transform.position += new Vector3(pos, pos, 0);
        button.SetActive(true);
        // text.transform.position += new Vector3(pos, pos, 0);
        text.SetActive(true);
    }

   

    // Método chamado continuamente a cada quadro
    private void Update()
    {

    	if(Input.GetAxisRaw("Jump") != 0)
       {
           buttonPressed = true;
       }

        if(buttonPressed==true){
            if(naoApertarFlag==true){
                // Debug.Log($"BOTAO APERTADO E NAO DEVERIA APERTAR");
                GameData.lost = true;
        }
    }
        Debug.Log(GameData.GetTime());
        if(buttonPressed==false){
            if(apertarFlag==true){
                // Debug.Log($"BOTAO NAO APERTADO E DEVERIA APERTAR");
                GameData.lost = true;
            
            }
    }
    
}
}
