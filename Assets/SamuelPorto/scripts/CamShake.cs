using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SamuelPorto
{
    public class CamShake : MonoBehaviour
    {
        public float poder = 0.7f;
        public float duracao = 1.0f;
        public Transform CameraPrincipal;
        public float diminuindoTotal = 1.0f;
        public bool deveMexer = false;

        private Vector3 posicaoInicial;
        private float duracaoInicial;

        // Start is called before the first frame update
        void Start()
        {
            CameraPrincipal = Camera.main.transform;
            posicaoInicial = CameraPrincipal.localPosition;
            duracaoInicial = duracao;
        }

        // Update is called once per frame
        void Update()
        {
            if(deveMexer)
            {
                if(duracao > 0)
                {
                    CameraPrincipal.localPosition = posicaoInicial + Random.insideUnitSphere * poder;
                    duracao -= Time.deltaTime * diminuindoTotal;
                }
                else
                {
                    deveMexer = false;
                    duracao = duracaoInicial;
                    CameraPrincipal.localPosition = posicaoInicial;
                }
            }
        }
    }
}
