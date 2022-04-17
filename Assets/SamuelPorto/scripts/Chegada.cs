using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SamuelPorto
{
    public class Chegada : MonoBehaviour
    {
        public string cenaCarregar;

        void OnTriggerEnter2D(Collider2D col)
        {

            if (col.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(cenaCarregar);
            }
        }
    }
}
