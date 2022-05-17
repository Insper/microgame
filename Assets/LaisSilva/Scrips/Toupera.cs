using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace LaisSilva{
    public class Toupera : MonoBehaviour
    {
        private Animator anim;

        public CapsuleCollider2D colliderToupera;

        
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            colliderToupera = GetComponent<CapsuleCollider2D>();
            colliderToupera.enabled = false;
            
        }


    
        public void Animacao()
        {
            anim = GetComponent<Animator>();
            
            anim.SetTrigger("a");     
            colliderToupera.enabled = true;     
   
            
        }


        
    }
}