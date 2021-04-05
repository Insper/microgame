using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoTiroGabrielZanetti : MonoBehaviour
{
    public float angulo;
    private Vector3 direcao;

    private float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find ("Main Camera");
        ControllerGabrielZanetti controller = camera.GetComponent <ControllerGabrielZanetti> ();

        direcao = controller.direcao_arma.normalized;
        velocidade = 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direcao * Time.deltaTime * velocidade;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {   
        Destroy(gameObject);
    }
}
