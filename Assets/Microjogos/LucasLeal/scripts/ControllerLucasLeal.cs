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
    public GameObject RedbuttonBG;
    public GameObject GreenbuttonBG;
    
    private bool buttonPressed;
    private bool apertarFlag;
    private bool naoApertarFlag;
    
    public Camera cam;
    public Color colorRed = Color.red;
    public Color colorGreen = Color.green;

    // Exemplo de finalização de jogo
    protected override void EndMicrogame()
    {
        // Mensagens de vítoria ou derrota
        if(buttonPressed==true){
            if(naoApertarFlag==true){
                GameData.lost = true;
                }
            }
        if(apertarFlag==true){
            if(buttonPressed==false){
                GameData.lost = true;
                }
            } 
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

        RedbuttonBG.SetActive(false);
        GreenbuttonBG.SetActive(false);

        
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
            
        }else{
            button = Redbutton;
            Greenbutton.SetActive(false);
        };
        // Mensagem inicial
        GameManager.Text.text = "PRESS SPACE!";
        
        // Botao é escalado conforme o nível
        if(GameData.level > 4)
        {
            float corBG = Random.Range(0.0f,2.0f);
            Debug.Log("random");
            if(corBG>1){

                RedbuttonBG.SetActive(false);
                GreenbuttonBG.SetActive(true);
            }else{
                RedbuttonBG.SetActive(true);
                GreenbuttonBG.SetActive(false);
            }

        }
        else if(GameData.level > 2)
        {
            Debug.Log("fixedBG");

            if(tex>1){
                RedbuttonBG.SetActive(true);   
            }else{
                GreenbuttonBG.SetActive(true);
            }

        }
        else 
        {
            Debug.Log("normal");

            float cor = Random.Range(0.0f,2.0f);

            if(cor>1){
            cam.backgroundColor = colorRed;
        }else{
            cam.backgroundColor = colorGreen;
        }

        }

        // Botao é desativado enquanto partida não começa
        button.SetActive(false);
        text.SetActive(false);
        
      
    }

    // Exemplo de jogo principal
    protected override void Microgame()
    {
        // 10,6
        float posx = Random.Range(-7.0f, 7.0f);
        float posy = Random.Range(-4.0f, 4.0f);
        button.transform.position += new Vector3(posx, posy, 0);
        button.SetActive(true);
        text.transform.position += new Vector3(posx, posy, 0);
        text.SetActive(true);
    }


    // Método chamado continuamente a cada quadro
    private void Update()
    {
    	if(Input.GetAxisRaw("Jump") != 0)
       {
           buttonPressed = true;
       }
        
    }
}
