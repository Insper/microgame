using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerGabrielZanetti : BaseMGController
{

    // Objetos a serem gerenciados
    public GameObject arma;
    public GameObject cano;
    public GameObject fundo_cano;
    public GameObject tiro;
    public GameObject alvo;
    private GameObject alvo_;
    private List<GameObject> alvos;
    public GameObject bala;
    private GameObject bala_;
    private List<GameObject> balas;
    public Vector3 direcao_arma;

    private float velocidade_arma;
    private int n_tiros;
    public int n_alvos;
    public int n_alvos_ativos;
    public float angulo;
    public float passo_angulo;

    public AudioClip shootSFX;
    

    public float distancia;

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
        GameManager.Text.text = "Atire em todos os Alvos!";
        distancia = 2.0f;
        n_alvos_ativos = 0;

        // Por padrão se supõe que o jogador perdeu, ele só ganha se todos os alvos forem destruidos.
        GameData.lost = true;
        
        // Dificuldade é escalavel conforme o nível
        if(GameData.level > 4)
        {
            n_tiros = 8;
            n_alvos = 4;
            velocidade_arma = 350.0f;
        }
        else if(GameData.level > 2)
        {
            n_tiros = 8;
            n_alvos = 3;
            velocidade_arma = 350.0f;
        }
        else 
        {
            n_tiros = 8;
            n_alvos = 2;
            velocidade_arma = 350.0f;
        }
        alvos = new List<GameObject>();
        balas = new List<GameObject>();
        // Arma é desativada enquanto partida não começa
        arma.SetActive(false);
        passo_angulo = 2*Mathf.PI/n_alvos;
        angulo = 0.0f;

        for (int i = 0; i < n_alvos; i++)
        {
            alvo_ = Instantiate(alvo, cano.transform.position, Quaternion.identity);
            alvo_.SetActive(false);
            alvos.Add(alvo_);
        }

        for (int i = 0; i < n_tiros; i++)
        {
            Vector3 posicao = new Vector3(-7.5f + 0.5f * i, -4.0f);
            bala_ = Instantiate(bala, posicao, Quaternion.identity);
            // bala_.SetActive(false);
            balas.Add(bala_);
        }

    }

    // Exemplo de jogo principal
    protected override void Microgame()
    {
        // Arma é ativada em posição aleatória e gravidade faz ela cair

        arma.SetActive(true);

        for (int i = 0; i < n_alvos; i++)
        {
            alvos[i].SetActive(true);
        }
        
    }

    private void Atirar() 
    {   
        if (n_tiros > 0) 
        {
            n_tiros--;
            GZ_AudioManager.PlaySFX(shootSFX);
            Destroy(balas[n_tiros]);
            Instantiate(tiro, cano.transform.position, Quaternion.identity);
        }
    }

    // Método chamado continuamente a cada quadro
    private void Update()
    {
         

        float inputX = Input.GetAxis("Horizontal");

        arma.transform.Rotate(0, 0, inputX * Time.deltaTime * velocidade_arma * -1);

        direcao_arma = cano.transform.position - fundo_cano.transform.position;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Atirar();
        }

        if (n_alvos == 0)
        {
            GameData.lost = false;
        }

    }
    
}
