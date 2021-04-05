using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Controller da bola
public class BolaController : MonoBehaviour
{
    public GameObject bola;
    public GameObject sol;
    private bool vida = true;

    // Definindo velocidade
    [Range(1, 50)]
    public float velocidade = 10;

    // Método chamado continuamente a cada quadro
    private void Update()
    {
        // Se coleta as teclas pressionadas e se posiciona a bolinha
    	float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        if (GameData.lost == true) {
            bola.transform.position += new Vector3(inputX, inputY, 0) * Time.deltaTime * velocidade;
        }
    }

    // Método chamado caso haja colisão
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Colisão com um bloco
        if (collision.gameObject.tag == "bloco"){
            if (vida == true){
                bola.GetComponent<SpriteRenderer>().color = Color.red;
                vida = false;
            }
            else {
                Destroy(this.gameObject);
            }
        }

        // Colisão com o diamante
        if (collision.gameObject.tag == "diamante")
        {
            bola.GetComponent<SpriteRenderer>().color = Color.white;
            Destroy(this.sol);
            GameData.lost = false;
        }
    }
}
