using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GabriellaCukier {

    public class PlayerBehaviour : MonoBehaviour
    {
        public GameObject instructions;  // Textou das instruçõees        public float velocidade;
        private Animator anim;
        public float velocidade;
        private MicrogameInternal.GameManager gm;
        private GabriellaCukier.LightBorders lb;
        void Start()
        {
            gm = MicrogameInternal.GameManager.GetInstance();
            lb =  GameObject.FindObjectOfType<GabriellaCukier.LightBorders>();
            anim = GetComponent<Animator>();


            // aumenta a velocidade conforme avançam os níveis
            if (gm.ActiveLevel >=4){
                velocidade = 8;  
            }else if (gm.ActiveLevel >= 1){
                velocidade = 7;  
            }else{
                velocidade = 6;  
            }
            // Debug.Log($"Velocidade Player: {velocidade}");

            Invoke(nameof(Begin), 0.5f);
        }

            void Begin() {
                instructions.SetActive(false);  // Tira tela de instruções
                gm.StartTimer(); 
            }

        void Update()
        {

            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");
            transform.position += new Vector3(inputX, inputY, 0) * Time.deltaTime * velocidade;

            if (transform.position.y <= -4.5)
                transform.position = new Vector3(transform.position.x, (float)-4.5, transform.position.z);
            else if (transform.position.y >=-2.75)
                transform.position = new Vector3(transform.position.x, (float)-2.75, transform.position.z);

            Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
            pos.x = Mathf.Clamp((float)pos.x, (float)0.04, (float)0.96);
            transform.position = Camera.main.ViewportToWorldPoint(pos);

        }


        private void OnParticleCollision(GameObject other){
            // Debug.Log("Choveu");
            if (!(transform.position.x > lb.m_Min.x && transform.position.x < lb.m_Max.x))
                gm.GameLost();
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy")){
                gm.GameLost();
            }
        }

    }
}
