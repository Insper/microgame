using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GabriellaCukier {
    public class CloudBehaviour : MonoBehaviour
    {

        public float velocidade;
        private Vector3 direcao;
        private MicrogameInternal.GameManager gm;
        void Start()
        {
            float dirX = Random.Range(-5.0f, 5.0f);
            direcao = new Vector3(dirX, 0).normalized;
            velocidade = (float)1.5;  

            gm = MicrogameInternal.GameManager.GetInstance(); 

            // níveis de dificuldade
            if (gm.ActiveLevel >=4){
                velocidade = 6;  
            }else if (gm.ActiveLevel >= 1){
                velocidade = (float)5;  
            }else{
                velocidade = (float)4;
            } 
        }

        void Update()
        {
            transform.position += direcao * Time.deltaTime * velocidade;
            int screen_width=8;
            if (transform.position.x <= -screen_width){
                transform.position = new Vector3(screen_width, transform.position.y, transform.position.z);
            } else if (transform.position.x >=screen_width){
                transform.position = new Vector3(-screen_width, transform.position.y, transform.position.z);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Sun")){
                direcao = new Vector3(-direcao.x, direcao.y);
            }

        }
    
    
    }
}
