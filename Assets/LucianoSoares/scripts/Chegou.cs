using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LucianoSoares {

    // Classe usada para identificar se bolinha chegou no buraco
    public class Chegou : MonoBehaviour
    {

        public bool chegou = false;  // por padrão assume que não chegou

        void OnTriggerEnter2D(Collider2D col)
        {
            chegou = true;  // set a flag para chegou
            Destroy(col.gameObject);  // destroi a bolinha quando chega
        }
        
    }

}