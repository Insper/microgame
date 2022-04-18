using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatheusFreitas {
    public class ControlPlayer : MonoBehaviour
    {
        MicrogameInternal.GameManager gm;
        float velocidade = 9.5f;

        // Start is called before the first frame update
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
        }

        // Update is called once per frame
        void Update()
        {
            float inputX = Input.GetAxis("Horizontal");
            Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);

            if(posicaoViewport.x < 0)
            {
                transform.position += new Vector3(0.5f, 0, 0) * Time.deltaTime * velocidade;
            } 
            else if(posicaoViewport.x > 1)
            {
                transform.position += new Vector3(-0.5f, 0, 0) * Time.deltaTime * velocidade;
            } 
            else
            {
                transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            gm.GameLost();
        }
    }
}