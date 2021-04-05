using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedroCostaFNController : BaseMGController
{
    public GameObject Bola;
    float spawn_timer;
    int n_bolas;
    int total_bolas = 3;
    private GameObject bola;
    private Vector3 posicao;
    private Color[] colors = new Color[] { new Color(0, 1, 0, 1), new Color(0, 0, 1, 1), new Color(0, 1, 1, 1), new Color(1, 0, 1, 1) };
    protected override void EndMicrogame()
    {
        if(GameData.lost)
        {
            GameManager.Text.text = "Você perdeu!";
        }
        else
        {
            GameManager.Text.text = "Você ganhou!";
        }
        
    }

    protected override void StartMicrogame()
    {
        GameManager.Text.text = "Colete todo o lixo!";
        GameData.lost = true;
    }

    protected override void Microgame()
    {
        posicao = new Vector3(Random.Range(-8, 8), Random.Range(4.0f, 4.5f), 1);
        bola =  Instantiate(Bola, posicao, Quaternion.identity, transform);
        bola.GetComponent<PedroCostaBolaController>().setVel((Random.Range(6, 10)));
        n_bolas = 1;
    }

    private void Update()
    {
        spawn_timer += Time.deltaTime;
        if(spawn_timer > 0.8 && n_bolas <= total_bolas)
        {
            spawn_timer = 0;
            n_bolas ++;
            posicao = new Vector3(Random.Range(-8, 8), Random.Range(4.0f, 4.5f), 1);
            bola =  Instantiate(Bola, posicao, Quaternion.identity, transform);
            bola.GetComponent<PedroCostaBolaController>().setVel((Random.Range(5, 9)));
        }
        if(n_bolas == total_bolas){
            GameObject[] objs = GameObject.FindGameObjectsWithTag("bola");
            if(objs.Length == 0){
                GameData.lost = false;
                total_bolas ++;
            } 
        }
    }
}
