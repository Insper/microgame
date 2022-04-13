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
            float dirX = Random.Range(-5.0f, 5.0f);
            direcao = new Vector3(dirX, 0).normalized;
            gm = MicrogameInternal.GameManager.GetInstance();

            // níveis de dificuldade
            if (gm.ActiveLevel >=20){
                velocidade = 5;  
            }else if (gm.ActiveLevel >= 10){
                velocidade = 3;  
            }else{
                velocidade = 2;  
            }

            Debug.Log($"Velocidade Sun: {velocidade}");
              
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