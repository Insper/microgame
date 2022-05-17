using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GabriellaCukier {

    public class SunBehaviour : MonoBehaviour
    {
        public float velocidade;
        private Vector3 direcao;
        private MicrogameInternal.GameManager gm;
        void Start()
        {
            float dirX = -1;
            direcao = new Vector3(dirX, 0).normalized;
            gm = MicrogameInternal.GameManager.GetInstance();

            // níveis de dificuldade
            if (gm.ActiveLevel >=4){
                velocidade = 7;  
            }else if (gm.ActiveLevel >= 1){
                velocidade = 6;  
            }else{
                velocidade = 5;  
            }
              
        }

        void Update()
        {
            transform.position += direcao * Time.deltaTime * velocidade;

            Vector2 posicaoVP = Camera.main.WorldToViewportPoint(transform.position);

            if(posicaoVP.x < 0 || posicaoVP.x > 1)
            {
                direcao = new Vector3(-direcao.x, direcao.y);
            }
        }
    }
}