using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoAlvoGabrielZanetti : MonoBehaviour
{
    private float velocidade;
    private float distancia;
    private float angulo;
    private bool way;
    ControllerGabrielZanetti controller;
    Vector3 posicao_arma;

    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find ("Main Camera");
        controller = camera.GetComponent <ControllerGabrielZanetti> ();
        angulo = controller.angulo;
        controller.angulo += controller.passo_angulo;
        
        if (controller.n_alvos_ativos % 2 == 0)
        {
            way = true;
        }
        else 
        {
            way = false;
        }

        controller.n_alvos_ativos++;

        distancia = controller.distancia;
        if (way)
        {
            distancia += 1.0f;
        }
        posicao_arma = controller.arma.transform.position;
        velocidade = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {   
        if (way)
        {
            angulo += velocidade * Time.deltaTime;
            if (angulo > 2*Mathf.PI)
            {
                angulo = 0.0f;
            }
        }
        else
        {
            angulo -= velocidade * Time.deltaTime;
            if (angulo < 0.0f)
            {
                angulo = 2*Mathf.PI;
            }
        }
        
        transform.position = posicao_arma + new Vector3(Mathf.Cos(angulo)*distancia, Mathf.Sin(angulo)*distancia, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {   
        Destroy(gameObject);
        controller.n_alvos--;
    }
}
