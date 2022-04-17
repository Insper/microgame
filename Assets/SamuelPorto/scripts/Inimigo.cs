using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SamuelPorto
{
    public class Inimigo : MonoBehaviour
    {
        public string nivelAtual;

        void OnCollisionEnter2D(Collision2D col)
        {

            if (col.gameObject.tag == "Player")
            {
                Destroy(col.gameObject);
            }
        }

        IEnumerator EsperaCarregarCena(){
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(nivelAtual);
        }
    }
}
