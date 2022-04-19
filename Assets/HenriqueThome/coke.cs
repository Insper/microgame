using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HenriqueThome {
    public class coke : MonoBehaviour
    {
        [Range(1, 15)]
        public float velocidade = 5.0f;

        private Vector3 direcao;
        private MicrogameInternal.GameManager gm;
        
        void Start(){
            gm = MicrogameInternal.GameManager.GetInstance();
            float dirX = Random.Range(-5.0f, 5.0f);
            float dirY = Random.Range(1.0f, 5.0f);

            direcao = new Vector3(dirX, dirY).normalized;

        }
        void Update(){
            transform.position += direcao * Time.deltaTime * velocidade * (gm.ActiveLevel + 1);
            Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);

            if( posicaoViewport.x < 0 || posicaoViewport.x > 1 )
            {
                    direcao = new Vector3(-direcao.x, direcao.y);
            }
            if( posicaoViewport.y < 0 || posicaoViewport.y > 1 )
            {
                    direcao = new Vector3(direcao.x, -direcao.y);
            }
        }
        private void OnMouseOver() {
            if (gm.ActiveLevel == 0){
                if (Input.GetMouseButton(0)) Destroy(gameObject);

            }
            else{
                int counter = 0;
                if (Input.GetMouseButton(0)){counter += 1;}
                if( counter == 2){Destroy(gameObject);}
                
            }
        }
}
}
