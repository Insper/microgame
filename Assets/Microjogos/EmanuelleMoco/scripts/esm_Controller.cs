using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class esm_Controller : BaseMGController
{
    public GameObject player;
    // public GameObject playerWin;
    public GameObject snkr;
    
    bool isPressed = false;

    float velocidadeEasy = 0.08f;
    float velocidadeMedium = 0.15f;
    float velocidadeHard = 0.29f;
    float velocidade;

    Vector3 playerPosition; 
    Vector3 snkrPosition; 

    Animator animator; 

    protected override void StartMicrogame()
    { 
        // Mensagem inicial
        GameManager.Text.text = "Calce o tenis!";
        if (GameObject.FindGameObjectWithTag("Jordan") != null){
            snkrPosition = GameObject.FindGameObjectWithTag("Jordan").transform.position;
            float posX = Random.Range(0f, 4f);
            Debug.Log(posX); 
            snkr.transform.position = new Vector3(posX, snkrPosition.y, 0); 

        }
        animator = GetComponent<Animator>();
        animator.SetBool("GameLost", false);
        animator.SetBool("GameWin", false);

        // Velocidade muda conforme o nivel
        if(GameData.level > 4)
        {
            velocidade = velocidadeHard;
            player.transform.position = new Vector3(-20, -1.84f, 0);
        }
        else if(GameData.level > 2)
        {
            velocidade = velocidadeMedium;
            player.transform.position = new Vector3(-17, -1.84f, 0);
        }
        else 
        {
            velocidade = velocidadeEasy;
        }

    }

    protected override void Microgame()
    {
        player.SetActive(true);
        snkr.SetActive(true);
        // playerWin.SetActive(false);
        Debug.Log("Jogo Principal");
    }


    protected override void EndMicrogame()
    {
        Debug.Log("Jogo Acabou");
        if (! isPressed){
            GameData.lost = true;
                player.SetActive(true);
                snkr.SetActive(true);
        }

        // Mensagens de vítoria ou derrota
        if(GameData.lost)
        {
            GameManager.Text.text = "Você perdeu!";
        }
        else
        {
            GameManager.Text.text = "Você ganhou!";
            // playerWin.SetActive(true);
            player.SetActive(false);
            // snkr.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        if ( GameObject.FindGameObjectWithTag("Player") != null){
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        //Logica do seu jogo
        if(Input.GetKeyDown(KeyCode.Space)) {
            isPressed = true;
            // Debug.Log($"SNKR: {snkrPosition.x}");
            if (playerPosition.x >= (snkrPosition.x - 1.4f) && playerPosition.x <= playerPosition.x + 0.1f){
                animator.SetBool("GameWin", true);
                velocidade = 0;
                snkr.transform.position = new Vector3( snkrPosition.x, snkrPosition.y - 10, 0); 
            }
            else{
                Debug.Log("Errou");
                GameData.lost = true;

                animator.SetBool("GameLost", true);
                velocidade = 0;
            }
        }
    } 

    private void FixedUpdate()  
    {
        // Debug.Log($"velocidadeEasy: {velocidadeEasy}");
        //Movimento do player
        if (! GameData.lost  ){
            player.transform.position += new Vector3(velocidade, 0, 0); 
            // Debug.Log($"player: {playerPosition.x}");
        }
    }
}