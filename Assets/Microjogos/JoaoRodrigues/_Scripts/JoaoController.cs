// Arquitetura de código baseada no exemplo do professosr Luciano Soares.
// Disponível em https://github.com/Insper/microgame/tree/main/Assets/Microjogos/LucianoSoares/scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JoaoController : BaseMGController
{
    public GameObject cabeca;
    public GameObject maca;

    [Range(1, 20)]
    public float velocidade;

    // Exemplo de inicialização de jogo
    protected override void StartMicrogame()
    {
        // Mensagem inicial
        GameManager.Text.text = "Ajude Newton a descobrir a gravidade!";

        //Maçã é desativada enquanto partida não começa
        maca.SetActive(false);
    }
    
    // Exemplo de jogo principal
    protected override void Microgame(){
        // maca é ativada em posição aleatória e gravidade faz ela cair
        float pos = Random.Range(-6.0f, 6.0f);
        float alt = Random.Range(2.0f, 5.0f);
        maca.transform.position += new Vector3(pos, alt, 0);

        maca.SetActive(true);
        
    }

    protected override void EndMicrogame()
    {
        // Mensagens de vitória ou derrota
        if(GameData.lost)
        {
            GameManager.Text.text = "O que faremos sem a gravidade?";
        }
        else
        {
            GameManager.Text.text = "Agora a gravidade existe!!";
        }
        
    }

    private void Update()
    {

        // Se coleta as teclas pressionadas e se posiciona a cabeca
    	float inputX = Input.GetAxis("Horizontal");
    	cabeca.transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;;

        // Caso a maca passe a cabeca é considerado que se perdeu a partida
        if(maca.transform.position.y < cabeca.transform.position.y)
        {
            // Se a maca está perdida é pintada de vermelho
            maca.GetComponent<SpriteRenderer>().color = Color.red;
            
            // Por padrão se supoões que jogador ganho, caso contrário se informa que perdeu.
            GameData.lost = true;
        }

    }
}
