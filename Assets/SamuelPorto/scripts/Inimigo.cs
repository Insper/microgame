using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SamuelPorto
{
    public class Inimigo : MonoBehaviour
    {
        public string nivelAtual;
        public ParticleSystem particula;
        public GameObject inimigos;
        public CamShake cameraMexendo;

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                Destroy(col.gameObject);
                StartCoroutine(EsperaCarregarCena());
                Instantiate(particula, inimigos.transform.position, Quaternion.identity);
                cameraMexendo.deveMexer = true;

            }
        }

        IEnumerator EsperaCarregarCena(){
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(nivelAtual);
        }
    }
}
